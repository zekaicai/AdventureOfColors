using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    private AudioSource bgm;
    //[SerializeField] float audioTime;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        bgm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>().getBgm();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.lastCheckpointPos = transform.position;
            gm.audioTime = bgm.time;
        }
    }
}
