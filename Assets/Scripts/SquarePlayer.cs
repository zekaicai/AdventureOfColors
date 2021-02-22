using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquarePlayer : Player
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                transform.position = new Vector3(15.46f, -9.54f, 0);
            }
        }

    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-moveForce, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(moveForce, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
    }
}
