using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpikesHoriz : MonoBehaviour
{
    [SerializeField] private float num;
    [SerializeField] private float leftPoint;
    [SerializeField] private float rightPoint;
    [SerializeField] private float moveForce;
    private enum State { waiting, waitingEnd, right, left };
    [SerializeField] private State state = State.waiting;
    private float nextActionTime = 0.0f;
    [SerializeField] float period;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {   
        nextActionTime = Time.time + period;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        num = GameObject.Find("NumCheck2").GetComponent<NumCheck>().num;
        if(num == 0) return;
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
        if (state == State.right)
        {
            transform.position = new Vector3(transform.position.x + moveForce * Time.deltaTime,
                transform.position.y,
                transform.position.z);
        }
        else if (state == State.left)
        {
            transform.position = new Vector3(transform.position.x - moveForce * Time.deltaTime,
                transform.position.y,
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
        float loc = transform.position.x;
        if (loc <= leftPoint)
        {
            if (state == State.waitingEnd)
            {
                state = State.right;
            }
            else if (state == State.left)
            {
                state = State.waiting;
                nextActionTime = Time.time + period;
            }
        }

        else if (loc >= rightPoint)
        {
            if (state == State.waitingEnd)
            {
                state = State.left;
            }
            else if (state == State.right)
            {
                state = State.waiting;
                nextActionTime = Time.time + period;
            }
        }
    }
}
