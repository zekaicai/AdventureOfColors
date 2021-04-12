using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    [SerializeField] float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SquarePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<SquarePlayer>();
        player.JumpByForce(jumpForce);
    }
}
