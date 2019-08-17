using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemys_script : MonoBehaviour {

    public GameObject[] go;
    public bool canDelete = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canDelete)
        {
            foreach (GameObject item in go)
                Destroy(item);

            Destroy(this);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Argo")
            GetComponent<Animator>().enabled = true;
    }
}
