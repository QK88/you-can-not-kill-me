using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public float bgVolume = 1;
    public float affectVolume = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void BGVolume() 
    {
        bgVolume = GameObject.Find("BGSlider").GetComponent<Slider>().value;
        GetComponents<AudioSource>()[0].volume = bgVolume;

    }
    public void BGplay()
    {
        GetComponent<AudioSource>().Play();
    }
    public void BGstop()
    {
        GetComponent<AudioSource>().Stop();
    }
    public void play(int i)
    {
        GetComponentsInChildren<AudioSource>()[i].Play();
    }
    public void stop(int i)
    {
        GetComponentsInChildren<AudioSource>()[i].Stop();
    }
    public void AffectVolume()
    {
        affectVolume = GameObject.Find("AffectSlider").GetComponent<Slider>().value;
        foreach (Transform n in gameObject.transform)
        {
            n.GetComponent<AudioSource>().volume = affectVolume;
        }
    }
}
