using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_loot : MonoBehaviour {

    public GameObject loot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<enemy>().enemyHP <= 0)
            ItemSpawn();
	}

    private void ItemSpawn()
    {
        Instantiate(loot, GetComponent<Transform>().position, Quaternion.identity);
    }
}
