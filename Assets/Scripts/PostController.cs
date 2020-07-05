using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PostController : MonoBehaviour
{
    public string chatName;//对话的内容
                           //private bool canChat = false;//是否可以对话
                           // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (col.Length > 0)
            {
                foreach (Collider2D c in col)
                {
                    if (c.gameObject.name == "海报")
                    {
                        Say();
                    }
                }
            }
        }
    }
    
    public void Say()
    {
            Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            //对话是否存在
            if (flowChart.HasBlock(chatName))
            {
                flowChart.ExecuteBlock(chatName);
            }
    }
}
