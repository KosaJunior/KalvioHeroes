using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class musicFadeIn : MonoBehaviour
{

    public int secondsToFadeIn = 5;

    void Update()
    {
        if (GetComponent<AudioSource>().volume < 1)
        {
            GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume + (Time.deltaTime / (secondsToFadeIn + 1));
        }
        else
        {
            Destroy(this);
        }
    }
}