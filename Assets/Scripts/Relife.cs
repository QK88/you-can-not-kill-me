using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Relife : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReStart()
    {
        GameObject.Find("music").GetComponent<AudioController>().stop(5);
        GameObject.Find("music").GetComponent<AudioController>().BGplay();
        SceneManager.LoadScene("ReMain");
    }
}
