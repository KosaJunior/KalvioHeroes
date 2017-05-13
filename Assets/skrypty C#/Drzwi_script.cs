using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drzwi_script : MonoBehaviour {

    public bool getObj = false, endScene = false;
    private bool interact = false, keyPressed;
    public GameObject[] akcja;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("e") && interact)
        {
            GetComponent<Animator>().SetBool("keyPressed", true);

            if (interact && getObj)
                akcja[1].GetComponent<Animator>().enabled = true;
            else if(interact && !getObj)
                GetComponent<Animator>().SetBool("state1", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("keyPressed", false);
            GetComponent<Animator>().SetBool("state1", false);
        }

        if (endScene)
        {
            akcja[1].GetComponent<Animator>().enabled = false;
            Destroy(akcja[2]);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Argo")
        {
            GetComponent<Animator>().SetBool("goAway", false);
            interact = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Argo")
        {
            interact = false;
            GetComponent<Animator>().SetBool("goAway", true);
        }
    }
}

