using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] float moveForce;
    [SerializeField] LayerMask ground;
    [SerializeField] float waitingTimeBeforeMove;
    private float timeStartMove;
    private Animator anim;
    Canon canon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeStartMove = Time.time + waitingTimeBeforeMove;
        canon = GameObject.FindGameObjectWithTag("Cannon").GetComponent<Canon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < timeStartMove)
        {
            return;
        }
        rb.velocity = new Vector2(moveForce, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = new Vector2(0, 0);    
            anim.SetBool("isDead", true);
        }
    }

    private void GameOver()
    {
        canon.GenerateBullet();
        Destroy(this.gameObject);
    }
}
