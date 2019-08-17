using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class owocki_script : MonoBehaviour {

    public bool takeFruit = false;
    int amount = 1;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(amount > 0 && takeFruit && Input.GetKeyDown("e"))
        {
            if (GameObject.Find("Argo").GetComponent<playerStats>().lives < 3)
            {
                GameObject.Find("Argo").GetComponent<playerStats>().lives++;
                amount--;
            }
            if(amount == 0)
            {
                tag = "Untagged";
                GameObject.Find("interest_point").GetComponent<SpriteRenderer>().enabled = false;
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(this);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Argo")
            takeFruit = true;
        else
            takeFruit = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        takeFruit = false;
    }
}
