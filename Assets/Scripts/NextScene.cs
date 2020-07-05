using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class NextScene : MonoBehaviour
{
    private bool canChat=false;

    public GameObject chatSign;

    bool sign_exist = false;

    public Item item_key;//钥匙

    public bool needkey;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        canChat = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canChat = false;
    }
    private void Update()
    {
        if (canChat)
        {
            if (sign_exist == false)
            {
                chatSign.gameObject.SetActive(true);
                sign_exist = true;
            }

        }
        else
        {
            if (sign_exist == true)
            {
                chatSign.gameObject.SetActive(false);
                sign_exist = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.W)&&canChat)
        {
            if (GameManager.instance.items.Contains(item_key))
            {
                GameManager.instance.RemoveItem(item_key);
                needkey = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            if(needkey == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
