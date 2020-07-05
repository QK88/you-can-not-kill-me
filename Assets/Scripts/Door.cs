using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isSucceed)
        {//通关成功，开门进入电梯
            BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
            box.isTrigger = true;
        }
        //if (gameObject.GetComponent<BoxCollider2D>().isTrigger)
        //{
        //    //进入下一关；

        //}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //进入电梯；

        }
    }
}
