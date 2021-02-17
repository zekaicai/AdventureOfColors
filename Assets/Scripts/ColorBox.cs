using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBox : MonoBehaviour
{
    [SerializeField] bool isPink;
    [SerializeField] SquarePlayer player;
    [SerializeField] private Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (this.isPink == player.isPink)
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), coll, true);
        }
        else
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), coll, false);
        }
    }
}
