using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneCamera : MonoBehaviour
{

    public GameObject[] Camera;
    public GameObject[] tekst;

    void Start()
    {
        Cursor.visible = false;
        StartCoroutine("playIntro");
    }

    IEnumerator playIntro()
    {
        yield return new WaitForSeconds(5);
        Destroy(Camera[0]);
        Camera[1].SetActive(true);
        yield return StartCoroutine(mainCamera());
        Destroy(Camera[1]);
        Camera[2].SetActive(true);
        yield return StartCoroutine(cameraScene2());
        Destroy(Camera[2]);
        Camera[3].SetActive(true);
        yield return StartCoroutine(cameraScene3());
        Destroy(Camera[3]);
        Camera[4].SetActive(true);
        yield return StartCoroutine(cameraScene4());
        Destroy(Camera[4]);
        SceneManager.LoadScene("level1");

    }

    IEnumerator mainCamera()
    {
        tekst[0].GetComponent<FadeMe>().enabled = true;
        yield return new WaitForSeconds(0.01f);
        tekst[0].GetComponent<SpriteRenderer>().enabled = true;             // Tajemniczy: Wój, medyk, mag... mamy wszystkich?       
        yield return new WaitForSeconds(4);
        tekst[0].GetComponent<FadeMeOut>().enabled = true;
        yield return new WaitForSeconds(2);

        tekst[1].GetComponent<FadeMe>().enabled = true;
        yield return new WaitForSeconds(0.01f);
        tekst[1].GetComponent<SpriteRenderer>().enabled = true;             // Miles: Prawie, brakuje...
        yield return new WaitForSeconds(4);
        tekst[1].GetComponent<FadeMeOut>().enabled = true;

        GameObject.Find("rękaw").GetComponent<Animator>().enabled = true;
        tekst[2].GetComponent<FadeMe>().enabled = true;
        yield return new WaitForSeconds(0.01f);
        tekst[2].GetComponent<SpriteRenderer>().enabled = true;              // Tajemniczy: Hmm...
        yield return new WaitForSeconds(2);
        tekst[2].GetComponent<FadeMeOut>().enabled = true;

        yield return new WaitForSeconds(1);
        tekst[3].GetComponent<FadeMe>().enabled = true;
        yield return new WaitForSeconds(0.01f);
        tekst[3].GetComponent<SpriteRenderer>().enabled = true;             // Miles:  Znalazłem kandydata...   
        yield return new WaitForSeconds(6);
    }
    IEnumerator cameraScene2()
    {
        tekst[4].GetComponent<FadeMe>().enabled = true;
        yield return new WaitForSeconds(0.01f);
        tekst[4].GetComponent<SpriteRenderer>().enabled = true;             // Tajemniczy: Jakie problemy?    
        yield return new WaitForSeconds(4);
        tekst[4].GetComponent<FadeMeOut>().enabled = true;
        yield return new WaitForSeconds(3);
    }
    IEnumerator cameraScene3()
    {          
        yield return new WaitForSeconds(4);
        tekst[5].GetComponent<FadeMeOut>().enabled = true;

        tekst[6].GetComponent<FadeMe>().enabled = true;
        yield return new WaitForSeconds(0.01f);
        tekst[6].GetComponent<SpriteRenderer>().enabled = true;             // Miles: Z subordynacją...
        yield return new WaitForSeconds(3);
        tekst[6].GetComponent<FadeMeOut>().enabled = true;

        tekst[7].GetComponent<FadeMe>().enabled = true;
        yield return new WaitForSeconds(0.01f);
        tekst[7].GetComponent<SpriteRenderer>().enabled = true;             // Miles: Ale podjąłem już pewne kroki...
        yield return new WaitForSeconds(4);
        tekst[7].GetComponent<FadeMeOut>().enabled = true;

        tekst[8].GetComponent<FadeMe>().enabled = true;
        yield return new WaitForSeconds(0.01f);
        tekst[8].GetComponent<SpriteRenderer>().enabled = true;             // Tajemniczy: Mam nadzieję...
        yield return new WaitForSeconds(3);
        tekst[8].GetComponent<FadeMeOut>().enabled = true;
        yield return new WaitForSeconds(2);

        GameObject.Find("/CameraScene4/Canvas/scena4/BACH").SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Argo głowa 1").SetActive(false);
        GameObject.Find("/CameraScene4/Canvas/scena4/znaki").SetActive(true);
        GameObject.Find("/CameraScene4/Canvas/scena4/Argo/Argo głowa 2").SetActive(true);
        yield return new WaitForSeconds(3);
    }
    IEnumerator cameraScene4()
    {    
        yield return new WaitForSeconds(4);                                 // Miles: Nie będzie miał wyboru
        tekst[9].GetComponent<FadeMeOut>().enabled = true;
        yield return new WaitForSeconds(2);

        tekst[10].GetComponent<FadeMe>().enabled = true;
        yield return new WaitForSeconds(0.01f);
        tekst[10].GetComponent<SpriteRenderer>().enabled = true;            // Straż: Proszę z nami
        yield return new WaitForSeconds(4);
        tekst[10].GetComponent<FadeMeOut>().enabled = true;

        yield return new WaitForSeconds(4);
        GetComponent<FadeOut>().enabled = true;
        GetComponent<musicFadeOut>().findAudio();
        yield return new WaitForSeconds(3);
        Destroy(GameObject.Find("muzyka"));
    }
}
