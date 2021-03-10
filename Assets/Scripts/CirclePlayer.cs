using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CirclePlayer : Player
{

    private Collider2D coll;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (CheckDead()) // If player is dead, should set velocity to 0 and return
        {
            return;
        }

        Movement();
        Zuozhetongdao();
    }

    private void Zuozhetongdao()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("111");
                SceneManager.LoadScene("VodkaDance");
            }
        }

    }

    private void Movement()
    {
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
        }
        else
        {
            rb.velocity = new Vector2(moveForce, rb.velocity.y);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(moveForce, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
