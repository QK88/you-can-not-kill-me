using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BoneCotroller : MonoBehaviour
{
    public string chatName;//对话的内容
    public GameObject chatSign;
    private bool canChat=false;//是否可以对话
    public Item item;
    public Item item1;
    bool sign_exist=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canChat)
        {
            if (sign_exist==false)
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
            if (GameManager.instance.items.Contains(item)&&canChat)
            {
                Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
                flowChart.SetBooleanVariable("Bone", true);
                Say();
                GameManager.instance.RemoveItem(item);
                GameManager.instance.AddItem(item1);
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
