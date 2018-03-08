using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using UnityEngine.Windows.Speech;
using UnityEngine;

public class WinSpeech : MonoBehaviour
{
    public const int WM_SETTEXT = 0x000c;       // 
    public const int WM_LBUTTONDOWN = 0x201;    //
    public const int WM_LBUTTONUP = 0x202;      // 
    public const int MK_LBUTTON = 0x0001;       //
    public const int GWL_STYLE = -16;           //

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr ptr, byte[] lParam);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern IntPtr FindWindowEx(IntPtr hWand, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [System.Runtime.InteropServices.DllImport("user32")]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int GetWindowText(IntPtr hWnd, byte[] lpString, int nMaxCount);

    IntPtr edit;                    // テキストボックス
    IntPtr play;                    // 再生ボタン
    DictationRecognizer recognizer; // 音声認識

    private void Start()
    {
        // 起動時に一回全取得
        var all = GetAllChildWindows(GetWindow(IntPtr.Zero), new List<Window>());
        string log = "";
        for (int i = 0; i < all.Count; i++)
        {
            log += all[i].Title + "-" + all[i].ClassName + "(" + all[i].hWnd + ") [" + all[i].Style + "]\r\n";
        }
        Debug.Log("Check all window\r\n" + log);



        // 音声認識初期化
        recognizer = new DictationRecognizer();
        recognizer.InitialSilenceTimeoutSeconds = 10;
        recognizer.AutoSilenceTimeoutSeconds = 10;
        recognizer.DictationResult += OnResult;

        // ターゲットから取得
        int index = all.IndexOf(FindTarget("VOICEROID2", all));
        var allVoiRo = GetAllChildWindows(GetWindow(all[index].hWnd), new List<Window>());
        for (int i = 0; i < allVoiRo.Count; i++)
        {
            Debug.Log(allVoiRo[i].Title + "-" + allVoiRo[i].ClassName + "(" + allVoiRo[i].hWnd + ") [" + allVoiRo[i].Style + "]\r\n");
        }
        // ウィンドウハンドルを取得したい...
        //IntPtr handle=new WindowInteropHelper()
        //edit = all[index + 10].hWnd;
        //edit = FindTarget("", all, index).hWnd;
        //play = FindTarget("", all, index).hWnd;
    }
    private float timeleft;

    private void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 1.0f;

            // ここで処理
            if (recognizer.Status == SpeechSystemStatus.Stopped)
            {
                recognizer.Start();
            }
        }
    }
    private void OnDestroy()
    {
        recognizer.DictationResult -= OnResult;
        recognizer.Dispose();
    }

    // 音声認識の結果呼び出されるイベントハンドル
    void OnResult(string text, ConfidenceLevel confidence)
    {
        Debug.Log(confidence + "：" + text);

        // テキスト文字コード変換と送信
        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
        byte[] bytes = sjisEnc.GetBytes(text);
        SendMessage(edit, WM_SETTEXT, IntPtr.Zero, bytes);

        // 再生ボタン
        SendMessage(play, WM_LBUTTONDOWN, MK_LBUTTON, 0x000A000A);
        SendMessage(play, WM_LBUTTONUP, 0x00000000, 0x000A000A);
    }

    // 指定したタイトルのウィンドウを取得(indexをしていた場合は途中から)
    public static Window FindTarget(string title, List<Window> all, int index = 0)
    {
        for (int i = index; i < all.Count; i++)
        {
            if (all[i].Title == title)
            {
                Debug.Log(all[i].Title + "：" + all[i].ClassName + "(" + all[i].Style + ")");
                return all[i];
            }
        }
        return null;
    }

    // 指定したウィンドウのすべての子孫ウィンドウを取得し，リストに追加する
    public static List<Window> GetAllChildWindows(Window parent, List<Window> dest)
    {
        dest.Add(parent);
        EnumChildWindows(parent.hWnd).ToList().ForEach(x => GetAllChildWindows(x, dest));
        return dest;
    }

    // 与えた親ウィンドウの直下にある子ウィンドウを列挙する
    public static IEnumerable<Window> EnumChildWindows(IntPtr hParentWindow)
    {
        IntPtr hWnd = IntPtr.Zero;
        while ((hWnd = FindWindowEx(hParentWindow, hWnd, null, null)) != IntPtr.Zero)
        {
            yield return GetWindow(hWnd);
        }
    }

    // ウィンドウハンドルを渡すと，ウィンドウテキスト(ラベルなど)，クラス，スタイルを取得してWindowクラスに格納して返す．
    public static Window GetWindow(IntPtr hWnd)
    {
        int textLen = GetWindowTextLength(hWnd);
        string windowText = null;
        if (0 < textLen)
        {
            byte[] windowTextBuffer = new byte[textLen + 1];
            GetWindowText(hWnd, windowTextBuffer, textLen + 1);
            string text = Encoding.GetEncoding("Shift_JIS").GetString(windowTextBuffer);
            windowText = text.Substring(0, text.Length - 1);
        }
        // ウィンドウのクラス名を取得する
        StringBuilder classNameBuffer = new StringBuilder(256);
        GetClassName(hWnd, classNameBuffer, classNameBuffer.Capacity);

        // スタイルを取得する
        int style = GetWindowLong(hWnd, GWL_STYLE);
        return new Window()
        {
            hWnd = hWnd,
            Title = windowText,
            ClassName = classNameBuffer.ToString(),
            Style = style
        };
    }
}


public class Window
{
    public string ClassName;
    public string Title;
    public IntPtr hWnd;
    public int Style;
}

