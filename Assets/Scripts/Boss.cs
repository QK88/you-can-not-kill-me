using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float speed;
    public float look;//朝向
    public GameObject player;
    Rigidbody2D rbody;
    Animator anim;
    //private bool appear=false;
    bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("music").GetComponent<AudioController>().play(3);//play boss music 
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isBoss)
        {
            //look
            if (rbody.position.x > player.transform.position.x) 
            {
                anim.SetFloat("Look", 0);
            }
            else
            {
                anim.SetFloat("Look", 1);
            }
           // Appear();
           // anim.SetBool("Appear", appear);
            //appear = false;
           AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);//监听动画状态
            if (info.normalizedTime > 1.0f)
            {
                canMove = true;
            }
            anim.SetBool("CanMove", canMove);
            if (canMove)
            {
                Move();
            }

        }
    }
    public void Move()
    {//
        rbody.position = Vector2.MoveTowards(rbody.position, player.transform.position, Time.deltaTime * speed);
    }
    //public void Appear()
    //{//时间结束调用此函数使出现
    //    appear = true;
    //}
    public void Attack()
    {//todo: 调入玩家第几次闯关根据闯关生成日志
        GameObject.Find("music").GetComponent<AudioController>().play(4);//player kill music 
        GameManager.instance.isDeath = true;
       // SceneManager.LoadScene("Death");
        //Destroy(this.gameObject);//碰撞后boss消失
    }
}
