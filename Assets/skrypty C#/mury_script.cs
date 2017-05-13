using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mury_script : MonoBehaviour {

    public bool interact;
    public bool cameraObjOff = false;
    public GameObject[] obj; // 0 - Argo, 1 - Argo2, 2 - MainCamera

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("e") && interact)
        {
            GameObject.Find("interest_point").GetComponent<SpriteRenderer>().enabled = false;
            //Argo set off
            obj[0].GetComponent<PlayerMovement>().canMove = false;
            obj[0].GetComponent<SpriteRenderer>().enabled = false;
            //Start cutscene
            GetComponent<Animator>().enabled = true;
            obj[2].GetComponent<CameraFollow>().m_Target = obj[1];
        }

        if (cameraObjOff)
            obj[2].GetComponent<CameraFollow>().enabled = false;
}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Argo")
            interact = true;
        else
            interact = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        interact = false;
    }
}
