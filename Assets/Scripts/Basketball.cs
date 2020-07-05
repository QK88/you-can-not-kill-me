using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Basketball : MonoBehaviour
{
    // Start is called before the first frame update
    public Item item_bask;//篮球
    public Item item_ladder;//钥匙
    public string chatName;
    public GameObject ladder;

    public GameObject chatSign;
    private bool canChat = false;//是否可以对话
    public bool key = false;

    bool sign_exist = false;

    private void Start()
    {
        ladder.gameObject.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canChat)
            {
                OnClick();
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (col.Length > 0)
            {
                foreach (Collider2D c in col)
                {
                    if (c.gameObject.name == "篮球")
                    {
                        OnClick();
                    }
                }
            }

        }
    }
    private void OnClick()
    {// 添加钥匙，消耗篮球
        Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        if (GameManager.instance.items.Contains(item_ladder))
        {//有篮球，触发对话掉钥匙
            ladder.gameObject.SetActive(true);
            GameManager.instance.AddItem(item_bask);
            flowChart.SetBooleanVariable("isBasketball", true);
            GameManager.instance.RemoveItem(item_ladder);
        }
        if (flowChart.HasBlock(chatName))
        {
            flowChart.ExecuteBlock(chatName);
        }

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
