using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcosTester : MonoBehaviour {
    float num =0;
    float hoge;

    Vector3 V1, V2;

    // Use this for initialization
    void Start () {

        while (!float.IsNaN(num))
        {
            V1 = new Vector3(Random.Range(0, 10f), Random.Range(0, 10f), Random.Range(0, 10f)).normalized;
            V2 = new Vector3(Random.Range(0, 10f), Random.Range(0, 10f), Random.Range(0, 10f)).normalized;
            hoge = Vector3.Dot(V1, V2);
            num = Mathf.Acos(Vector3.Dot(V1, V2));
        }
        Debug.Log(Mathf.Acos(hoge));
        //Debug.Log(V1.ToString("F8") + " , " + V2.ToString("F8") + " , " +Vector3.Dot(V1,V2).ToString("F20"));
	}
}
