using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private bool pause = false;
    // Start is called before the first frame update
    public void Load()
    {
        GameObject.Find("music").GetComponent<AudioController>().play(1);
        SceneManager.LoadScene("Introduce");
        
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
