using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad;

    void Update()
    {
        StartCoroutine("waitLoad");
        Time.timeScale = 1.0f;
    }

    IEnumerator waitLoad()
    {
        Destroy(GameObject.Find("EventSystem"));
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelToLoad);
    }
}
