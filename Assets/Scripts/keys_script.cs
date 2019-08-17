using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keys_script : MonoBehaviour {

    bool canTake = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canTake && Input.GetKey("e"))
        {
            GameObject.Find("_przedsionek/krata").GetComponent<krata_script>().getKeys = true;
            GameObject.Find("interest_point").GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Argo")
            canTake = true;
        else
            canTake = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
            canTake = false;
    }
}
