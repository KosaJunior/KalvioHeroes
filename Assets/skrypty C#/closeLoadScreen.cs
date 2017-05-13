using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeLoadScreen : MonoBehaviour {

    public GameObject levelToLoad;
    public GameObject _camera;
    
    // Use this for initialization
	void Start () {
        StartCoroutine("splash_screen");
	}
    
    IEnumerator splash_screen()
    {
        yield return new WaitForSeconds(12);
        GetComponent<FadeOut>().enabled = true;
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        levelToLoad.SetActive(true);
    }
}
