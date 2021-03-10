using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public bool isRed = true;
    protected Rigidbody2D rb;
    protected Animator anim;
    protected SpriteRenderer sr;
    [SerializeField] protected string nextSceneName;
    [SerializeField] protected AudioSource explosion;
    [SerializeField] protected float moveForce;
    [SerializeField] protected string levelName;

    [SerializeField] private List<Image> keys;
    private int numKeys;
    [SerializeField] private int targetNumKeys;
    [SerializeField] protected AudioSource keySound;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        numKeys = 0;
        targetNumKeys = keys.Capacity;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        ChangeColor();
        Suicide();
    }

    private void Suicide()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("Dead", true);
            explosion.Play();
        }
    }

    protected void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isRed = !isRed;
        }
        if (isRed)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.green;
        }
    }

    public void GetKey()
    {
        keySound.Play();
        numKeys++;
        ChangeKeyUIColor(keys[numKeys - 1]);
    }


    private void ChangeKeyUIColor(Image key)
    {
        key.color = new Color32(234, 116, 49, 255);
    }

    public bool GetEnoughKeys()
    {
        return numKeys >= targetNumKeys;
    }

    public int GetNumKeys()
    {
        return numKeys;
    }

    protected bool CheckDead()
    {
        if (anim.GetBool("Dead"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") && !anim.GetBool("Dead"))
        {
            bool isFalling = false;
            if (rb.velocity.y < 0)
            {
                isFalling = true;
            }
            AnalyticsResult result = Analytics.CustomEvent(
                "DeathOnSpike",
                new Dictionary<string, object>{
                    {"SpikeName", collision.gameObject.name},
                    {"HitSpikeOnWhenFalling", isFalling}
                }
            );

            Debug.Log(collision.gameObject.name);
            Debug.Log(isFalling);
            Debug.Log(result);

            rb.velocity = new Vector2(0, 0);
            anim.SetBool("Dead", true);
            explosion.Play();
        }
    }

    protected void GameOver()
    {
        AnalyticsResult result = Analytics.CustomEvent(
                "Death",
                new Dictionary<string, object>{
                    {"Level", levelName}
                }
        );
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathLine")
        {
            AnalyticsResult result = Analytics.CustomEvent(
                "DeathFallingOFF",
                new Dictionary<string, object>{
                    {"Level", levelName}
                }
            );

            float delayInMs = 0.2f;
            float ms = Time.deltaTime;

            while (ms <= delayInMs)
            {
                ms += Time.deltaTime;
                yield return null;
            }

            anim.SetBool("Dead", true);
            explosion.Play();
        }
        
        else if (collision.gameObject.tag == "Goal")
        {
            if (!GetEnoughKeys())
            {
                AnalyticsResult result = Analytics.CustomEvent(
                "NotEnoughKeys",
                new Dictionary<string, object>{
                    {"NumKeys", GetNumKeys()}
                }
                );
                print("not enough");
            }
            else
            {
                AnalyticsResult result2 = Analytics.CustomEvent(
                "PassLevel",
                new Dictionary<string, object>{
                    {"Level", levelName},
                    {"Time", Time.time}
                }
                );
                SceneManager.LoadScene(nextSceneName);
            }
        }
        
    }
}
