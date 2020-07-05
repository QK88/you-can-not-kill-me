using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using MoonSharp.Interpreter;
using JetBrains.Annotations;

public class PlugController : MonoBehaviour
{
    public string chatName;//对话的内容
    public GameObject chatSign;
    private bool canChat = false;//是否可以对话
    // Start is called before the first frame update
    public Item item;
    public GameObject mylight;
    public GameObject bed_light;
    public GameObject bed_withoutlight;
    public GameObject chatou;//todo:
    bool sign_exist = false;
    void Start()
    {
        mylight.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Say();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {//按下交互键
            if (GameManager.instance.items.Contains(item) && canChat)
            {
                Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
                flowChart.SetBooleanVariable("Plug", true);
                GameManager.instance.RemoveItem(item);
                mylight.SetActive(true);
                bed_light.gameObject.SetActive(true);
                bed_withoutlight.gameObject.SetActive(false);
                //todo: 需要在这里改成
                //name.gameObject.SetActive(true)
                //this.gameObject.SetActive(false);
                chatou.gameObject.SetActive(true);
               
            }

        }
    }
    private void OnMouseDown()
    {
        Say();
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
        if (canChat)
        {
            Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            //对话是否存在
            if (flowChart.HasBlock(chatName))
            {
                flowChart.ExecuteBlock(chatName);
            }
        }
    }
}
