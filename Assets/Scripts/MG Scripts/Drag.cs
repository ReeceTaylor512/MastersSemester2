using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Drag : MonoBehaviour
{
    public GameObject stethascope;
    public BoxCollider BCollider;
    public AudioSource Audio;
    private float mZCoord;
    static bool keepFadeIn;
    static bool keepFadeOut;
    public static Drag instance;

    private void Awake()
    {
        instance = this;
    }
    void OnMouseDown()
    {
        // Store offset = gameobject world pos - mouse world pos        
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Cursor.visible = false;
        stethascope.SetActive(false);
    }
    private Vector3 GetMouseWorldPos() 
    {
        // pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = new Vector3 (GetMouseWorldPos().x, 1.3717f, (GetMouseWorldPos() * 1.8f).z);
    }
    private void OnMouseUp()
    {
        transform.position = new Vector3(0, 1.3717f, 0);
        stethascope.SetActive(true);
        Cursor.visible = true;
    }         
    private void OnTriggerEnter(Collider Coll)
    {
        Debug.Log(Coll.gameObject.tag);
        if (Coll.gameObject.CompareTag("AudioCollider"))
        {
            Audio.Play();
            Debug.Log("colision");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Audio.Stop();
    }
    public static void FadeInCaller(AudioSource audioSource, float duration, float targetVolume) 
    {
        instance.StartCoroutine(Fadein(audioSource, duration, targetVolume));
    }
    public static void FadeOutCaller(AudioSource audioSource, float duration)
    {
        instance.StartCoroutine(Fadeout(audioSource, duration));
    }
    static IEnumerator Fadein(AudioSource audioSource, float duration, float targetVolume) 
    {
        keepFadeIn = true;
        keepFadeOut = false;
        audioSource.volume = 0;
        float audioVolume = audioSource.volume;
        while (audioSource.volume < targetVolume && keepFadeIn) 
        {
            audioVolume += duration;
            audioSource.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }
    }
    static IEnumerator Fadeout(AudioSource audioSource, float duration)
    {
        keepFadeIn = false;
        keepFadeOut = true;
        float audioVolume = audioSource.volume;
        while (audioSource.volume >= duration && keepFadeIn)
        {
            audioVolume += duration;
            audioSource.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }
    }
}