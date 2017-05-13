using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krata2_script : MonoBehaviour {

    public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Argo")
        {
            obj.SetActive(true);
            Destroy(gameObject);
        }
    }
}
