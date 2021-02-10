using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGround : MonoBehaviour
{
    [SerializeField] bool isPink;
    [SerializeField] Player player;
    private Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.isDead)
        //{
        //    coll.enabled = false;
        //    return;
        //}

        if (this.isPink == player.isPink)
        {
            coll.enabled = false;
        }
        else
        {
            coll.enabled = true;
        }
    }
}
