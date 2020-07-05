using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //对角色进行控制
    public float Speed = 3f;  //角色速度
    public GameObject chatBob;
    private float look = -1f;//默认朝向左
    private Rigidbody2D rbody;  //刚体
    private Animator anim; //动画组件
   
    void Start()
    {
        chatBob.gameObject.SetActive(false);
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rbody.position;//角色的位置
        float moveX = Input.GetAxisRaw("Horizontal");  //角色的左右移动，按左键值为-1，按右键值为1
        if (moveX != 0)
        {
            look = moveX;
        }
        float speed = System.Math.Abs(Speed * moveX);
        anim.SetFloat("Look", look);
        anim.SetFloat("Walk",moveX ); //设置动画变量值，速度
        anim.SetFloat("Speed",speed);
        position.x += moveX * Speed * Time.deltaTime;
        rbody.MovePosition(position);  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {//游戏结束，玩家死亡
        
        Boss boss = collision.collider.GetComponent<Boss>();
        if (boss)
        {
            //玩家与boss碰撞
            boss.Attack();
            GameObject.Find("music").GetComponent<AudioController>().BGstop();
            GameObject.Find("music").GetComponent<AudioController>().play(5);
            SceneManager.LoadScene("Death");

        }
    }
   

}

