using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    protected Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
//Debug.Log("Tag is ");
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

    }
    // 碰撞开始
    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("Tag is 1");
        anim.SetBool("Release", false);
        anim.SetBool("Compression", true);
         // 销毁当前游戏物体
         //Destroy(this.gameObject);
     }
 
     // 碰撞结束
     private void OnCollisionExit2D(Collision2D collision)
     {
        //Debug.Log("Tag is 2");
        anim.SetBool("Compression", false);
        anim.SetBool("Release", true);
     }
 
     // 碰撞持续中
    private void OnCollisionStay2D(Collision2D collision)
     {
      //  Debug.Log("Tag is 3");
        
     }
    // Vector3 fixPos;
    // public float elasticValue=0.1f; //弹性系数
    // Vector3 forceDie;             //力量的方向
    // Rigidbody2D rig;
    // private void Start()
    // {
    //     fixPos = transform.position;
    //     rig = GetComponent<Rigidbody2D>();
    // }
    //   // Update is called once per frame
    // private void Update()
    // {
    //     Elastic();  
    // }
    // void Elastic()
    // {
    //     if (rig.velocity == Vector2.zero) return;
    //     rig.AddForce((fixPos - transform.position) * elasticValue*Time.deltaTime);
    // }

}
