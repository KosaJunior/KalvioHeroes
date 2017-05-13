using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {

    public int lives = 3;
    int livesMax = 3;
    public bool isBlocking;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        livesControl();
  	}

    public void livesControl()
    {
        if (Input.GetKeyDown("-"))
        {
            if (lives == 0)
                print("GAAAAME OVVERRRRR");
            else
                lives = lives - 1;
        }
        else if (Input.GetKeyDown("="))
        {
            if (lives == livesMax)
                print("nie mozesz miec więcej hp");
            else
                lives = lives + 1;
        }
    }

   void OnCollisionEnter2D(Collision2D coll)
   {
        if(!isBlocking)
        if(coll.collider.tag == "hit_object")
            lives--;
   }
}
