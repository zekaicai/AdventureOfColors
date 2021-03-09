using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    [SerializeField] private float downPoint;
    [SerializeField] private float upPoint;
    [SerializeField] private float moveForce;
    private enum State { waiting, waitingEnd, jumping, falling };
    [SerializeField] private State state = State.waiting;
    private float nextActionTime = 0.0f;
    [SerializeField] float period;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        nextActionTime = Time.time + period;
        rb = GetComponent<Rigidbody2D>();
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

        ChangeState();
        Move();
    }

    private void Move()
    {
        if (state == State.jumping)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y + moveForce * Time.deltaTime,
                transform.position.z);
        }
        else if (state == State.falling)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y - moveForce * Time.deltaTime,
                transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z);
        }
    }

    private void ChangeState()
    {
        float loc = transform.position.y;
        if (loc <= downPoint)
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

        else if (loc >= upPoint)
        {
            if (state == State.waitingEnd)
            {
                state = State.falling;
            }
            else if (state == State.jumping)
            {
                state = State.waiting;
                nextActionTime = Time.time + period;
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.collider.transform.SetParent(transform);
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.collider.transform.SetParent(null);
    //    }
    //}
}
