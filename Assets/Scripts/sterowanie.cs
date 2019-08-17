using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sterowanie : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            gameObject.SetActive(false);
        }
        else return;
    }
}
