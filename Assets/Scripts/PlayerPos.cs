using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;
        bgm.time = gm.audioTime;
        print("bgm");
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource getBgm()
    {
        return bgm;
    }
}
