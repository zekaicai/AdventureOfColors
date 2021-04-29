using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    public AudioSource bgm;
    Dictionary<string, Vector2> map = new Dictionary<string, Vector2>();
    // Start is called before the first frame update
    void Start()
    {

        AddDefault();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName != gm.lastSceneName)
        {
            print("Load Default");
            LoadDefault();
            gm.lastCheckpointPos = map[currentSceneName];
            bgm.time = 0;
        }
        else
        {
            print("Load Master" + gm.lastCheckpointPos);
            transform.position = gm.lastCheckpointPos;
            bgm.time = gm.audioTime;
            bgm.Play();
        }

        gm.lastSceneName = currentSceneName;
    }

    private void AddDefault()
    {
        map.Add("SquareTutorial", new Vector2(-42, -4));
        map.Add("VodkaDance", new Vector2(-53.99f, -4.6f));
        map.Add("SquareScene", new Vector2(-23, -4.5f));
        map.Add("square02", new Vector2(-70.34f, 5.52f));
        map.Add("circle02", new Vector2(-53.05f, -3.49f));
    }

    private void LoadDefault()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        print(map[currentSceneName]);
        transform.position = map[currentSceneName];
        bgm.time = 0;
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
