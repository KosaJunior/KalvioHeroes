using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pajak_script : MonoBehaviour {

    public bool interact;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("e") && interact)
        {
            Destroy(gameObject);
            GameObject.Find("_loch/drzwi").GetComponent<Drzwi_script>().getObj = true;
            GameObject.Find("interest_point").GetComponent<SpriteRenderer>().enabled = false;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        interact = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        interact = false;
    }
}
