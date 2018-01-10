using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Msoft12 : MonoBehaviour
{
    string[] Name = { "マリア", "レイラ", "サラ", "クラウディア", "アンナ" };
    string[] Material = { "牛", "鰐", "蛇", "馬", "羊" };
    string[] Tea = { "ダージリン", "アッサム", "ディンブラ", "キーマン", "ウバ" };
    string[] Cash = { "1", "2", "5", "8", "30" };
    string[,] Ans = new string[4, 5];// 名前、素材、買った紅茶、所持金
                                     // Use this for initialization
    void Start()
    {
        int count = 0;
        //　名前の書き出しここから
        #region
        for (int n = 0; n < 5; n++)
        {
            Ans[0, 0] = Name[n];
            for (int n1 = 0; n1 < 5; n1++)
            {
                if (Ans[0, 0] != Name[n1])
                {
                    Ans[0, 1] = Name[n1];

                    for (int n2 = 0; n2 < 5; n2++)
                    {
                        if (Ans[0, 0] != Name[n2] && Ans[0, 1] != Name[n2])
                        {
                            Ans[0, 2] = Name[n2];
                            for (int n3 = 0; n3 < 5; n3++)
                            {
                                if (Ans[0, 0] != Name[n3] && Ans[0, 1] != Name[n3] && Ans[0, 2] != Name[n3])
                                {
                                    Ans[0, 3] = Name[n3];
                                    for (int n4 = 0; n4 < 5; n4++)
                                    {
                                        if (Ans[0, 0] != Name[n4] && Ans[0, 1] != Name[n4] && Ans[0, 2] != Name[n4] && Ans[0, 3] != Name[n4])
                                        {
                                            Ans[0, 4] = Name[n4];
                                            #endregion
                                            // 名前のパターン書き出しここまで
                                            #region
                                            // 素材の書き出しここから
                                            for (int m = 0; m < 5; m++)
                                            {
                                                Ans[1, 0] = Material[m];
                                                for (int m1 = 0; m1 < 5; m1++)
                                                {
                                                    if (Ans[1, 0] != Material[m1])
                                                    {
                                                        Ans[1, 1] = Material[m1];
                                                        for (int m2 = 0; m2 < 5; m2++)
                                                        {
                                                            if (Ans[1, 0] != Material[m2] && Ans[1, 1] != Material[m2])
                                                            {
                                                                Ans[1, 2] = Material[m2];
                                                                for (int m3 = 0; m3 < 5; m3++)
                                                                {
                                                                    if (Ans[1, 0] != Material[m3] && Ans[1, 1] != Material[m3] && Ans[1, 2] != Material[m3])
                                                                    {
                                                                        Ans[1, 3] = Material[m3];
                                                                        for (int m4 = 0; m4 < 5; m4++)
                                                                        {
                                                                            if (Ans[1, 0] != Material[m4] && Ans[1, 1] != Material[m4] && Ans[1, 2] != Material[m4] && Ans[1, 3] != Material[m4])
                                                                            {
                                                                                Ans[1, 4] = Material[m4];
                                                                                #endregion
                                                                                // 素材の書き出しここまで
                                                                                #region
                                                                                // 紅茶の書き出しここから
                                                                                for (int t = 0; t < 5; t++)
                                                                                {
                                                                                    Ans[2, 0] = Tea[t];
                                                                                    for (int t1 = 0; t1 < 5; t1++)
                                                                                    {
                                                                                        if (Ans[2, 0] != Tea[t1])
                                                                                        {
                                                                                            Ans[2, 1] = Tea[t1];
                                                                                            for (int t2 = 0; t2 < 5; t2++)
                                                                                            {
                                                                                                if (Ans[2, 0] != Tea[t2] && Ans[2, 1] != Tea[t2])
                                                                                                {
                                                                                                    Ans[2, 2] = Tea[t1];
                                                                                                    for (int t3 = 0; t3 < 5; t3++)
                                                                                                    {
                                                                                                        if (Ans[2, 0] != Tea[t3] && Ans[2, 1] != Tea[t3] && Ans[2, 2] != Tea[t3])
                                                                                                        {
                                                                                                            Ans[2, 3] = Tea[t3];
                                                                                                            for (int t4 = 0; t4 < 5; t4++)
                                                                                                            {
                                                                                                                if (Ans[2, 0] != Tea[t4] && Ans[2, 1] != Tea[t4] && Ans[2, 2] != Tea[t4] && Ans[2, 3] != Tea[t4])
                                                                                                                {
                                                                                                                    Ans[2, 4] = Tea[t4];
                                                                                                                    #endregion
                                                                                                                    // 紅茶の書き出しここまで
                                                                                                                    // 所持金の書き出しここから
                                                                                                                    for (int c = 0; c < 5; c++)
                                                                                                                    {
                                                                                                                        Ans[3, 0] = Cash[c];
                                                                                                                        for (int c1 = 0; c1 < 5; c1++)
                                                                                                                        {
                                                                                                                            if (Ans[3, 0] != Cash[c1])
                                                                                                                            {
                                                                                                                                Ans[3, 1] = Cash[c1];
                                                                                                                                for (int c2 = 0; c2 < 5; c2++)
                                                                                                                                {
                                                                                                                                    if (Ans[3, 0] != Cash[c2] && Ans[3, 1] != Cash[c2])
                                                                                                                                    {
                                                                                                                                        Ans[3, 2] = Cash[c2];
                                                                                                                                        for (int c3 = 0; c3 < 5; c3++)
                                                                                                                                        {
                                                                                                                                            if (Ans[3, 0] != Cash[c3] && Ans[3, 1] != Cash[c3] && Ans[3, 2] != Cash[c3])
                                                                                                                                            {
                                                                                                                                                Ans[3, 3] = Cash[c3];
                                                                                                                                                for (int c4 = 0; c4 < 5; c4++)
                                                                                                                                                {
                                                                                                                                                    if (Ans[3, 0] != Cash[c4] && Ans[3, 1] != Cash[c4] && Ans[3, 2] != Cash[c4] && Ans[3, 3] != Cash[c4])
                                                                                                                                                    {
                                                                                                                                                        Ans[3, 4] = Cash[c4];
                                                                                                                                                        // 所持金の書き出しここまで
                                                                                                                                                        count++;
                                                                                                                                                        Prove(Ans);
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                    // 紅茶ループの｛
                                                                                                                    #region
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                #endregion
                                                                                //素材ループの｛
                                                                                #region
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                            // 名前ループの｛
                                            #region
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }
        #endregion
        Debug.Log(count);
    }

    void Prove(string[,] ans)
    {
        try {
            int count;
            //ダージリンを買った人は蛇革のかばんを持っている
            count = 0;
            while (ans[2, count] != "ダージリン")
            {
                count++;
            }
            if (ans[1, count] != "蛇")
            {
                return;
            }
            //鰐革の鞄の人は所持金1万円
            count = 0;
            while (ans[1, count] != "鰐")
            {
                count++;
            }
            if (ans[3, count] != "1")
            {
                return;
            }
            //マリアは所持金30万円の人の2つ右
            count = 0;
            while (ans[0, count] != "マリア")
            {
                count++;
            }
            if (count > 2 && ans[3, count] != "30")
            {
                return;
            }
            //アッサムを買った人はティンブラを買った人よりも左側にいる
            count = 0;
            while (ans[2, count] != "アッサム")
            {
                count++;
            }
            int count2 = 0;
            while (ans[2, count2] != "ディンブラ")
            {
                count2++;
            }
            if (count > count2)
            {
                return;
            }
            //レイラはサラの左隣にいる
            count = 0;
            while (ans[0, count] != "レイラ")
            {
                count++;
            }
            if (count == 0 || ans[0, count - 1] != "サラ")
            {
                return;
            }
            //牛革の鞄の人は所持金2万円の人の右隣にいる
            count = 0;
            while (ans[1, count] != "牛")
            {
                count++;
            }
            if (count == 5 || ans[3, count + 1] != "2")
            {
                return;
            }
            //馬革の鞄の人は羊革の鞄の人の左隣にいる
            count = 0;
            while (ans[1, count] != "馬")
            {
                count++;
            }
            if (count == 0 || ans[1, count - 1] != "羊")
            {
                return;
            }
            //クラウディアは所持金が5万円
            count = 0;
            while (ans[0, count] != "クラウディア")
            {
                count++;
            }
            if (ans[3, count] != "5")
            {
                return;
            }
            //アンナは所持金8万円で右から2番目
            if (ans[0, 3] != "アンナ")
            {
                return;
            }
            if (ans[3, 3] != "8")
            {
                return;
            }
            //キーマンを買った人はウバを買った人の3つ左
            count = 0;
            while (ans[2, count] != "キーマン")
            {
                count++;
            }
            if (count > 2 || ans[2, count + 3] != "ウバ")
            {
                return;
            }
            Debug.Log("成功!");
            Debug.Log(ans[0, 0] + " , " + ans[0, 1] + " , " + ans[0, 2] + " , " + ans[0, 3] + " , " + ans[0, 4] + " , ");
            Debug.Log(ans[1, 0] + " , " + ans[1, 1] + " , " + ans[1, 2] + " , " + ans[1, 3] + " , " + ans[1, 4] + " , ");
            Debug.Log(ans[2, 0] + " , " + ans[2, 1] + " , " + ans[2, 2] + " , " + ans[2, 3] + " , " + ans[2, 4] + " , ");
            Debug.Log(ans[3, 0] + " , " + ans[3, 1] + " , " + ans[3, 2] + " , " + ans[3, 3] + " , " + ans[3, 4] + " , ");
        }
        catch(Exception e)
        {
            Debug.Log("失敗");
            Debug.Log(ans[0, 0] + " , " + ans[0, 1] + " , " + ans[0, 2] + " , " + ans[0, 3] + " , " + ans[0, 4] + " , ");
            Debug.Log(ans[1, 0] + " , " + ans[1, 1] + " , " + ans[1, 2] + " , " + ans[1, 3] + " , " + ans[1, 4] + " , ");
            Debug.Log(ans[2, 0] + " , " + ans[2, 1] + " , " + ans[2, 2] + " , " + ans[2, 3] + " , " + ans[2, 4] + " , ");
            Debug.Log(ans[3, 0] + " , " + ans[3, 1] + " , " + ans[3, 2] + " , " + ans[3, 3] + " , " + ans[3, 4] + " , ");
        }
    }
}
