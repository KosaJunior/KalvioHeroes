using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notka_script : MonoBehaviour {

    bool interact, goAway;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("e") && interact)
        {
            GetComponent<Animator>().SetBool("interact", true);
        } else
            GetComponent<Animator>().SetBool("interact", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        interact = true;
        GetComponent<Animator>().SetBool("goAway", false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        interact = false;
        GetComponent<Animator>().SetBool("goAway", true);
    }
}
