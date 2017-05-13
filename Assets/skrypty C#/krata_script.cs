using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krata_script : MonoBehaviour {

    public GameObject obj;
    private bool interact = false, keyPressed;
    public bool getKeys = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e") && interact)
        {
            GetComponent<Animator>().SetBool("action", true);
            if (getKeys)
            {
                obj.SetActive(true);
                GameObject.Find("interest_point").GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("action", false);
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
