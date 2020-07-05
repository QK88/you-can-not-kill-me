using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Ladder_hor : MonoBehaviour
{
    public Item item;
    public string chatName;

    public GameObject chatSign;
    private bool canChat = false;//是否可以对话

    bool sign_exist = false;


    private void Start()
    {
        gameObject.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Say();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (col.Length > 0)
            {
                foreach (Collider2D c in col)
                {
                    if (c.gameObject.name == "梯子")
                    {
                        OnClick();
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canChat)
            {
                OnClick();
            }

        }
    }
    private void OnClick()
    {
        Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        if (flowchart.HasBlock(chatName))
        {
            flowchart.ExecuteBlock(chatName);
        }
        GameManager.instance.AddItem(item);
        flowchart.SetBooleanVariable("isLadder", true);
        this.gameObject.SetActive(false);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canChat = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canChat = false;

    }
}
