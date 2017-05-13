using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {

    public float speed = -5;
    	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, 30);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "Argo")
            GameObject.Find("Argo").GetComponent<playerStats>().isBlocking = false;

        Destroy(gameObject);
    }
}
