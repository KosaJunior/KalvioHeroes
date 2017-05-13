using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_floor : MonoBehaviour {

    bool interact;
    public SpriteRenderer[] player;
    public bool changeColors;
    public Vector3 destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("e") && interact)
        {
            GameObject.Find("Argo").GetComponent<Transform>().position = destination;
            if(changeColors)
                foreach (SpriteRenderer sprite in player)
                    sprite.color = new Color(1, 1, 1);
            GameObject.Find("interest_point").GetComponent<SpriteRenderer>().enabled = false;
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Argo")
            interact = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        interact = false;
    }
}
