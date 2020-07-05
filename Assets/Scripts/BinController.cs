using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
//using UnityEditor.UIElements;
using UnityEngine.UI;

public class BinController : MonoBehaviour
{
    public string chatName;//对话的内容
    private bool canChat = false;//是否可以对话
    public GameObject chatSign;
    public Item item;
    public InputField inputField;
    public GameObject thelight;
    public GameObject leftlight;
    bool sign_exist = false;
    // Start is called before the first frame update
    void Start()
    {
        inputField.gameObject.SetActive(false);
        thelight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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
        if (canChat)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Say();
                inputField.gameObject.SetActive(true);
            }
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    //inputField.gameObject.SetActive(true);
                
            //}
            if (Input.GetKeyDown(KeyCode.Return))
            {
                bool result = false;

                string password = inputField.text;
                if (password == "9924")
                {
                    result = true;
                    
                }
                inputField.gameObject.SetActive(false);
                if (result)
                {
                    GameManager.instance.isSucceed = result;
                    thelight.SetActive(true);
                    leftlight.SetActive(true);

                }
            }
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canChat = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canChat = false;

    }
    void Say()
    {
       
            Debug.Log("11");
            Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            //对话是否存在
            if (flowChart.HasBlock(chatName))
            {
                flowChart.ExecuteBlock(chatName);
            }
    }
    
}
