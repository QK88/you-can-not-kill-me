using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherSceneVolumeChange : MonoBehaviour
{
    private bool pause = false;
    private void Start()
    {
        GameObject.Find("Canvas").transform.Find("GameMenu").transform.Find("SettingPanel").Find("BGSlider").GetComponent<Slider>().value = GameObject.Find("music").GetComponent<AudioController>().bgVolume;
        GameObject.Find("Canvas").transform.Find("GameMenu").transform.Find("SettingPanel").Find("AffectSlider").GetComponent<Slider>().value = GameObject.Find("music").GetComponent<AudioController>().affectVolume;
    }
    public void BG_Volume()
    {
        if (pause)
        {
            GameObject.Find("music").GetComponent<AudioController>().BGVolume();
        }
        //
    }
   
    public void Affect_Volume()
    {
        if (pause)
        {
            GameObject.Find("music").GetComponent<AudioController>().AffectVolume();
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                GameObject.Find("Canvas").transform.Find("GameMenu").gameObject.SetActive(false);
                pause = false;
            }
            else
            {
                GameObject.Find("Canvas").transform.Find("GameMenu").gameObject.SetActive(true);
                pause = true;
            }


        }

    }
}
