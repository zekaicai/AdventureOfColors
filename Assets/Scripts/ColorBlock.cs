using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    [SerializeField] private bool isRed;
    protected Player player;
    protected Collider2D coll;
    protected SpriteRenderer sr;
    private static Color32 pink = new Color32(255, 74, 211, 255);
    private static Color32 blue = new Color32(35, 214, 255, 255);

    // Start is called before the first frame update
    protected virtual void Start()
    {
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        ChangeColor();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CheckBlockColor();
        CheckPlayerColor();
    }

    private void CheckBlockColor()
    {
        GameObject[] colorBlocks = GameObject.FindGameObjectsWithTag("ColorBlock");
        for (int i = 0; i < colorBlocks.Length; i++)
        {
            SetCollision(colorBlocks[i]);
        }
    }

    private void CheckPlayerColor()
    {
        SetCollision(GameObject.FindGameObjectWithTag("Player"));
    }

    private void SetCollision(GameObject gameObject)
    {
        Collider2D[] collider2Ds = gameObject.GetComponents<Collider2D>();
        for (int i = 0; i < collider2Ds.Length; i++)
        {
            if (GetObjectColor() == GetColor())
            {
                Physics2D.IgnoreCollision(collider2Ds[i], coll, true);
            }
            else
            {
                Physics2D.IgnoreCollision(collider2Ds[i], coll, false);
            }
        }
        
    }

    private bool GetObjectColor()
    {
        return isRed;
    }

    private static bool GetColor()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isRed;
    }

    private void ChangeColor()
    {
        if (isRed)
        {
            sr.color = pink;
        }
        else
        {
            sr.color = blue;
        }
    }
}
