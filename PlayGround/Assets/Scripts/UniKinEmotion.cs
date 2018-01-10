using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniKinEmotion : MonoBehaviour
{
    [SerializeField]
    GameObject[] tracker = new GameObject[6];
    float num;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            num = 0;
            for (int i = 0; i < 6; i++)
            {
                tracker[i].transform.rotation = Random.rotation;
            }
            num += DotComp(tracker[0], tracker[3]);
            num += DotComp(tracker[1], tracker[4]);
            num += DotComp(tracker[2], tracker[5]);
            num += PosComp(tracker[0], tracker[1], tracker[3], tracker[4]);
            num += PosComp(tracker[0], tracker[2], tracker[3], tracker[5]);
            num += RotComp(tracker[0], tracker[1], tracker[3], tracker[4]);
            num += RotComp(tracker[0], tracker[2], tracker[3], tracker[5]);
            Debug.Log("総合的に見てこの2つの姿勢の一致度は " + num / 7 + " です。");
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
        Debug.Log(go1.name + " はY軸に対して " + theta * Mathf.Rad2Deg + " 度傾いています。");
        float theta1 = Mathf.Acos(d2);
        Debug.Log(go2.name + " はY軸に対して " + theta1 * Mathf.Rad2Deg + " 度傾いています。");
        Vector2 v = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        Vector2 v1 = new Vector2(Mathf.Cos(theta1), Mathf.Sin(theta1));
        float dot = Vector2.Dot(v, v1);
        Debug.Log(go1.name + " と " + go2.name + " の一致度は　" + dot + " です...");
        return dot;
    }
    // 座標による一致度の比較
    float PosComp(GameObject goP, GameObject go, GameObject go1P, GameObject go1)
    {
        //Vector3 d = (goP.transform.position - go.transform.position).normalized;
        //Vector3 d1 = (go1P.transform.position - go1.transform.position).normalized;
        Vector3 d = goP.transform.InverseTransformPoint(go.transform.position).normalized;
        Vector3 d1 = go1P.transform.InverseTransformPoint(go1.transform.position).normalized;
        float dot = Vector3.Dot(d, d1);
        Debug.Log(go.name + " と " + go1.name + " の一致度は" + dot + " です...");
        return dot;
    }
    // Quaternionを使用した回転の一致度の比較
    float RotComp(GameObject goP, GameObject go, GameObject go1P, GameObject go1)
    {
        float rad = Quaternion.Dot(goP.transform.rotation, go.transform.rotation);
        float rad1 = Quaternion.Dot(go1P.transform.rotation, go1.transform.rotation);
        // 計算結果をそのままAcosに突っ込むと極稀にNaNを返すのでワンクッション置く
        float d1 = Mathf.Clamp(rad, -1.0f, 1.0f);
        float d2 = Mathf.Clamp(rad1, -1.0f, 1.0f);

        float theta = Mathf.Acos(d1);
        float theta1 = Mathf.Acos(d2);
        Vector2 v = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        Vector2 v1 = new Vector2(Mathf.Cos(theta1), Mathf.Sin(theta1));
        float dot = Vector2.Dot(v, v1);
        Debug.Log(go.name + " と " + go1.name + " の一致度は　" + dot + " です...");
        return dot;
    }
}
