using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoad : MonoBehaviour
{
    
    public void Load()
    {
        GameObject.Find("music").GetComponent<AudioController>().play(1);
        SceneManager.LoadScene("EquipmentRoom");
    }
    
}
