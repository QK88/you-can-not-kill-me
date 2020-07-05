using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void CloseButton()
    {
        GameManager.instance.clickMenu = true;
    }

    public void quitmethod()
    {
        Application.Quit();
    }
   public void BackToMain()
    {
        if (GameManager.instance.cycle == 1)
        {
            Debug.Log("//the players choose to stop");
            Debug.Log("可怜的孩子，难为你们了，后面的路还很长");
        }
        else
        {
            Debug.Log("//the players choose to stop");
            Debug.Log("不知道你们是否发觉了我留给你们的信息，希望你们早日终结我们创造的罪恶实验");
        }
        SceneManager.LoadScene("Main");
    }
}
