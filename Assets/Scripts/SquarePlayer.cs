using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;


public class SquarePlayer : Player
{
    [SerializeField] private List<Image> keys;
    private int numKeys;
    [SerializeField] private int targetNumKeys;
    [SerializeField] protected AudioSource keySound;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        numKeys = 0;
        targetNumKeys = keys.Capacity;
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

    public void GetKey()
    {
        keySound.Play();
        numKeys++;
        ChangeKeyUIColor(keys[numKeys - 1]);
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

    private void ChangeKeyUIColor(Image key)
    {
        key.color = new Color32(234, 116, 49, 255);
    }

    public bool GetEnoughKeys()
    {
        return numKeys >= targetNumKeys;
    }
}
