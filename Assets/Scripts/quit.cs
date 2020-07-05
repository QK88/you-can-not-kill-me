using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {//按下ESC键则退出游戏
           // UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

}
