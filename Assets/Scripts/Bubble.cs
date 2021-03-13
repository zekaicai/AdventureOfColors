using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("DestroySelf", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x + 1.8f, player.transform.position.y + 1.2f, player.transform.position.z);
    }

    private void DestroySelf()
    {
        print("Destroy");
        Destroy(this.gameObject);
    }
}
