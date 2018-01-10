using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniKinEmotion : MonoBehaviour
{
    [SerializeField]
    GameObject[] tracker = new GameObject[6];
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*// トラッカーの回転をランダムで決める
            for (int i = 0; i < 6; i++)
            {
                tracker[i].transform.rotation = Random.rotation;
            }
            */
            /*
            tracker[0].transform.position = new Vector3(0.4425054f, 1.544919f, -0.08702043f);
            tracker[1].transform.position = new Vector3(0.166019f, 1.273059f, 0.7097682f);
            tracker[2].transform.position = new Vector3(0.1483424f, 1.931006f, -0.272908f);
            tracker[0].transform.rotation = new Quaternion(-0.05034511f, -0.7215666f, -0.03058301f, 0.6898345f);
            tracker[1].transform.rotation = new Quaternion(0.01614239f, -0.1513656f, -0.0870238f, 0.9845074f);
            tracker[2].transform.rotation = new Quaternion(-0.2927287f, -0.6569949f, -0.4027115f, 0.5661193f);
            */
            /*
            tracker[0].transform.position = new Vector3(0.1229673f, 1.385701f, -0.1486931f);
            tracker[1].transform.position = new Vector3(0.01724792f, 1.546134f, -0.5169045f);
            tracker[2].transform.position = new Vector3(0.28672f, 1.097481f, -0.6608059f);
            tracker[0].transform.rotation = new Quaternion(0.2836013f, 0.6999962f, -0.4492946f, -0.4771898f);
            tracker[1].transform.rotation = new Quaternion(0.6678331f, 0.7295116f, 0.09463236f, 0.1133862f);
            tracker[2].transform.rotation = new Quaternion(0.6145408f, 0.7089332f, 0.2884371f, 0.1911999f);
            */

            tracker[0].transform.position = new Vector3(0.0114331f, 1.534791f, -0.2481484f);
            tracker[1].transform.position = new Vector3(-0.00540471f, 1.579925f, 0.4314362f);
            tracker[2].transform.position = new Vector3(-0.07416654f, 1.075773f, 0.3140358f);
            tracker[0].transform.rotation = new Quaternion(-0.03244916f, -0.3193404f, 0.005254f, 0.9470698f);
            tracker[1].transform.rotation = new Quaternion(-0.1716892f, -0.101217f, -0.03162187f, 0.9794274f);
            tracker[2].transform.rotation = new Quaternion(0.01933033f, -0.06700026f, -0.00635235f, 0.9975455f);

            tracker[3].transform.position = new Vector3(-0.3021786f, 1.581768f, 0.05476262f);
            tracker[4].transform.position = new Vector3(0.08580559f, 1.434746f, 0.5835893f);
            tracker[5].transform.position = new Vector3(-0.07190822f, 1.076666f, 0.5912223f);
            tracker[3].transform.rotation = new Quaternion(-0.04667161f, 0.1728307f, 0.02954336f, 0.9834015f);
            tracker[4].transform.rotation = new Quaternion(-0.05683314f, 0.2324244f, 0.09245229f, 0.966541f);
            tracker[5].transform.rotation = new Quaternion(-0.05363529f, 0.274513f, -0.08284044f, 0.9565058f);

            float dotNum = DotComp(tracker[0], tracker[3]) + DotComp(tracker[1], tracker[4]) + DotComp(tracker[2], tracker[5]);
            float posNum = PosComp(tracker[0], tracker[1], tracker[3], tracker[4]) + PosComp(tracker[0], tracker[2], tracker[3], tracker[5]);
            float rotNum = RotComp(tracker[0], tracker[1], tracker[3], tracker[4]) + RotComp(tracker[0], tracker[2], tracker[3], tracker[5]);
            float posNum2 = PosComp2(tracker[0], tracker[1], tracker[3], tracker[4]) + PosComp2(tracker[0], tracker[2], tracker[3], tracker[5]);
            float rotNum2 = RotComp2(tracker[0], tracker[1], tracker[3], tracker[4]) + RotComp2(tracker[0], tracker[2], tracker[3], tracker[5]);

            Debug.Log(dotNum / 3);
            Debug.Log(posNum / 2);
            Debug.Log(rotNum / 2);
            Debug.Log(posNum2 / 2);
            Debug.Log(rotNum2 / 2);

        }
    }
    // Y軸を基準にした回転の一致度の比較
    float DotComp(GameObject go1, GameObject go2)
    {
        // オブジェクトのY軸の向きとワールド座標のY軸の向きのなす角の内積を取得する
        float rad1 = Vector3.Dot((go1.transform.rotation * transform.up).normalized, Vector3.up);
        float rad2 = Vector3.Dot((go2.transform.rotation * transform.up).normalized, Vector3.up);
        // 計算結果をそのままAcosに突っ込むと極稀にNaNを返すのでワンクッション置く
        float d1 = Mathf.Clamp(rad1, -1.0f, 1.0f);
        float d2 = Mathf.Clamp(rad2, -1.0f, 1.0f);
        // 内積から角度を計算する
        float theta = Mathf.Acos(d1);
        //Debug.Log(go1.name + " はY軸に対して " + theta + " 度傾いています。");
        float theta1 = Mathf.Acos(d2);
        //Debug.Log(go2.name + " はY軸に対して " + theta1 + " 度傾いています。");
        Vector2 v = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        Vector2 v1 = new Vector2(Mathf.Cos(theta1), Mathf.Sin(theta1));
        float dot = Vector2.Dot(v, v1);
        //Debug.Log(go1.name + " から見た " + go2.name + " は　" + Mathf.Acos(dot) * Mathf.Rad2Deg + " 度傾いていると思われます...");
        return dot;
    }
    // 座標による一致度の比較
    float PosComp(GameObject goP, GameObject go, GameObject go1P, GameObject go1)
    {
        Vector3 d = (goP.transform.position - go.transform.position).normalized;
        Vector3 d1 = (go1P.transform.position - go1.transform.position).normalized;
        float dot = Vector3.Dot(d, d1);
        //Debug.Log(go.name + " と " + go1.name + " は" + Mathf.Acos(dot) * Mathf.Rad2Deg + " 度離れていると思われます...");
        return dot;
    }
    // Quaternionを使用した回転の一致度の比較
    float RotComp(GameObject goP, GameObject go, GameObject go1P, GameObject go1)
    {
        float rad = Quaternion.Dot(goP.transform.localRotation, go.transform.localRotation);
        float rad1 = Quaternion.Dot(go1P.transform.localRotation, go1.transform.localRotation);
        // 計算結果をそのままAcosに突っ込むと極稀にNaNを返すのでワンクッション置く
        float d1 = Mathf.Clamp(rad, -1.0f, 1.0f);
        float d2 = Mathf.Clamp(rad1, -1.0f, 1.0f);
        float theta = Mathf.Acos(d1);
        float theta1 = Mathf.Acos(d2);
        Vector2 v = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        Vector2 v1 = new Vector2(Mathf.Cos(theta1), Mathf.Sin(theta1));
        float dot = Vector2.Dot(v, v1);
        Debug.Log(dot);
        //Debug.Log(go.name + " から見た " + go1.name + " は　" + Mathf.Acos(dot) * Mathf.Rad2Deg + " 度傾いていると思われます...");
        return dot;
    }
    // 座標による一致度の比較
    float PosComp2(GameObject goP, GameObject go, GameObject go1P, GameObject go1)
    {
        Vector3 d = (goP.transform.InverseTransformPoint(go.transform.position)).normalized;
        Vector3 d1 = (go1P.transform.InverseTransformPoint(go1.transform.position)).normalized;
        float dot = Vector3.Dot(d, d1);
        Debug.Log(go.name + " と " + go1.name + " は" + Mathf.Acos(dot) * Mathf.Rad2Deg + " 度離れていると思われます...");
        return dot;
    }
    float RotComp2(GameObject goP, GameObject go, GameObject go1P, GameObject go1)
    {
        GameObject g = new GameObject();
        GameObject g1 = new GameObject();
        g.transform.SetPositionAndRotation(go.transform.position, go.transform.rotation);
        g1.transform.SetPositionAndRotation(go1.transform.position, go1.transform.rotation);

        g.transform.parent = goP.transform;
        g1.transform.parent = go1P.transform;

        Debug.Log(g.transform.localEulerAngles + " , " + g1.transform.localEulerAngles);
        Debug.Log(g.transform.localRotation + "," + g1.transform.localRotation);

        float dot = Quaternion.Dot(g.transform.localRotation, g1.transform.localRotation);
        return dot;
    }
}
