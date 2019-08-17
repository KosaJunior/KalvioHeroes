using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour {

    public bool interact = false;
    public GameObject openDoor;
    public GameObject[] lightItems;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("e") && interact)
        {
            openDoor.SetActive(true);
            for(int i=0;i<lightItems.Length;i++)
                lightItems[i].GetComponent<SpriteRenderer>().color = new Color(0.57F, 0.57F, 0.57F);

            GameObject.Find("interest_point").GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);
        }
}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Argo")
            interact = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
            interact = false;
    }
}
