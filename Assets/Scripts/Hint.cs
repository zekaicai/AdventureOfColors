using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    //check for tutorial
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bubble, Vector3.zero, transform.rotation);
        Destroy(this.gameObject);
    }
}
