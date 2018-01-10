using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World2LocalTester : MonoBehaviour {
    [SerializeField]
    GameObject Parent;
    [SerializeField]
    GameObject Child;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Process();
        }
	}
    void Process()
    {
        //Parent.transform.rotation = Random.rotation;
        //Parent.transform.position = Random.insideUnitSphere;
        Debug.Log(Parent.transform.worldToLocalMatrix);
        Debug.Log(Parent.transform.localToWorldMatrix);

    }
}
