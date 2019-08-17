using UnityEngine;
using UnityEngine.EventSystems;


public class showButtonSecondGraphic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject additionalGraphic;
    public AudioClip hoverSound;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        additionalGraphic.SetActive(true);
        audio.PlayOneShot(hoverSound, 0.3F);
        //  Debug.Log("aktywnosc wykryto");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        additionalGraphic.SetActive(false);
        //  Debug.Log("aktywnosc zakonczona");
    }

}
