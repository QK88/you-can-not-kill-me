using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    //设置60秒倒计时并进行UI显示

    private float totalTime=0;
    public float allTime;  //**此处自定义倒计时时间**
    public Text timeText;  //文本
    public GameObject boss;

    public void Timer()
    {
        //累加每帧消耗时间
        totalTime += Time.deltaTime;
        if (totalTime >= 1)//每过1秒执行一次
        {
            allTime--;
            if (allTime > 0)
            {
                timeText.text = allTime.ToString() + " s";  //对显示时间的文本进行设置
                totalTime = 0;
            }
            else
            {
                GameManager.instance.isBoss = true;
                timeText.text = "DEATH";
                boss.gameObject.SetActive(true);
            }
        }
    }

           // Start is called before the first frame update
     
    // Update is called once per frame
    void Update()
    {
        Timer();
    }
}
