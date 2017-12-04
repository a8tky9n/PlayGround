using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcosTester2 : MonoBehaviour {
    Vector3 V1, V2, V3, V4;
    // Use this for initialization
    void Start() {
        V1 = new Vector3(0, 0, 1);
        V2 = new Vector3(0, 0, 1);
        V3 = new Vector3(0, 0, -1);

        Debug.Log(Mathf.Acos(Vector3.Dot(V1, V2)));
        Debug.Log(Mathf.Acos(Vector3.Dot(V1, V3)));
        Debug.Log(Mathf.Acos(1f));
        Debug.Log(Mathf.Acos(0));
        //Debug.Log(Mathf.Acos(3.1415f));

    }
}
