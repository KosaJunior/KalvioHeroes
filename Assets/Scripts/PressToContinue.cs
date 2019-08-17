using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PressToContinue : MonoBehaviour
{
    FadeOut fadeout;

    void Start()
    {
        fadeout = GetComponent<FadeOut>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            fadeout.enabled = true;
            StartCoroutine("waitFunction");
        }
    }
    

    IEnumerator waitFunction()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
}