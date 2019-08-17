using UnityEngine;
using System.Collections;

public class musicFadeOut : MonoBehaviour
{
    public int secondsToFadeOut = 5;

    public void findAudio()
    {
        // Call findAudioAndFadeOut Coroutine
        StartCoroutine(findAudioAndFadeOut());
    }

    IEnumerator findAudioAndFadeOut()
    {
        // Find Audio Music in scene
        AudioSource audioMusic = GameObject.Find("muzyka").GetComponent<AudioSource>();
        //Debug.Log("odnalazlem");

        // Check Music Volume and Fade Out
        while (audioMusic.volume > 0.01f)
        {
            audioMusic.volume -= Time.deltaTime / secondsToFadeOut;
            yield return null;
        }

        // Make sure volume is set to 0
        audioMusic.volume = 0;

        // Stop Music
        audioMusic.Stop();

        // Destroy
        Destroy(this);
    }
}