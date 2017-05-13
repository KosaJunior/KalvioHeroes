using System.Collections;
using UnityEngine;

public class exitGame : MonoBehaviour
{
    void Start()
    { 
        StartCoroutine("waitQuit");
    }

    IEnumerator waitQuit()
    {
        Destroy(GameObject.Find("EventSystem"));
        yield return new WaitForSeconds(1);
        Application.Quit();
        Debug.Log("App closed");
    }
}
