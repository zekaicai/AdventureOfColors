using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool collected;
    // Start is called before the first frame update
    void Start()
    {
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collected && collision.tag == "Player")
        {
            collected = true;
            Destroy(this.gameObject);
            SquarePlayer player = collision.gameObject.GetComponent<SquarePlayer>();
            player.GetKey();
        }
    }
}
