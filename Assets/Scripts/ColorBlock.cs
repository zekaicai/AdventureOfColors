using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    [SerializeField] private bool isRed;
    [SerializeField] Player player;
    private Collider2D coll;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerColor();
    }

    private void CheckPlayerColor()
    {
        if (this.isRed == player.isRed)
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), coll, true);
        }
        else
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), coll, false);
        }
    }

    private void ChangeColor()
    {
        if (isRed)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.green;
        }
    }
}
