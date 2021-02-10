using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLine : MonoBehaviour
{

    [SerializeField]AudioSource explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("collision death line");
            explosion.Play();
            float delayInMs = 0.2f;
            float ms = Time.deltaTime;

            while (ms <= delayInMs)
            {
                ms += Time.deltaTime;
                yield return null;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
