using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Collider2D coll;
    [SerializeField] LayerMask ground;
    [SerializeField] float jumpForce;
    [SerializeField] private float upPoint;
    [SerializeField] float period;
    private float nextActionTime = 0.0f;
    private enum State { waiting, waitingEnd, jumping, falling };
    [SerializeField]private State state = State.waiting;
    //[SerializeField]private float time = 0.0f;
    //public float interpolationPeriod = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        //upPoint = transform.position.y;
        nextActionTime = Time.time + period;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.waiting)
        {
            if (Time.time >= nextActionTime)
            {
                state = State.waitingEnd;
            }
            return;
        }

        float pos = transform.position.y;

        if (coll.IsTouchingLayers(ground))
        {
            if (state == State.waitingEnd)
            {
                state = State.jumping;
            }
            else if (state == State.falling)
            {
                state = State.waiting;
                nextActionTime = Time.time + period;
            }
        }

        if (pos >= upPoint)
        {
            if (state == State.waitingEnd)
            {
                state = State.falling;
            }
            else if (state == State.jumping)
            {
                print("111");
                state = State.waiting;
                nextActionTime = Time.time + period;
            }
        }

        if (state == State.jumping)
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
        else if (state == State.falling)
        {
            rb.velocity = new Vector2(0, -jumpForce);
        } else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
