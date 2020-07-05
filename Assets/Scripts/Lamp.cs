using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System.Linq;

public class Lamp : MonoBehaviour
{
    public Item item_bask;//篮球
    public Item item_key;//钥匙
    public string chatName;
    public GameObject lamp_nonekey;
    public GameObject lamp_withkey;

    //public bool haskey = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (col.Length > 0)
            {
                foreach (Collider2D c in col)
                {
                    if (c.gameObject.name=="灯")
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
        if (GameManager.instance.items.Contains(item_bask))
        {//有篮球，触发对话掉钥匙
            GameManager.instance.AddItem(item_key);
            flowChart.SetBooleanVariable("isKey", true);
            GameManager.instance.RemoveItem(item_bask);
            lamp_nonekey.gameObject.SetActive(true);
            lamp_withkey.gameObject.SetActive(false);
            //haskey = true;

        }
        if (flowChart.HasBlock(chatName))
        {
            flowChart.ExecuteBlock(chatName);
        }
        
    }
    
}
