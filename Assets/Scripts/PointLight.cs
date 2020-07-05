using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLight : MonoBehaviour
{
    private bool canChat;
    public GameObject leftLight;
    public string chatName;

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
        if (Input.GetKeyDown(KeyCode.E)&&canChat)
        {
            Say();
            gameObject.SetActive(false);
            leftLight.SetActive(true);
        }
    }
    private void Say()
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
