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
    private static Color32 pink = new Color32(255, 74, 211, 255);
    private static Color32 blue = new Color32(35, 214, 255, 255);
    [SerializeField] GameObject bubble;

    public static explicit operator Player(GameObject v)
    {
        throw new NotImplementedException();
    }

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
        print(transform.position);
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
            sr.color = pink;
        }
        else
        {
            sr.color = blue;
        }
    }

    public void GetKey()
    {
        print("get");
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

    public bool IsFalling()
    {
        return rb.velocity.y < 0;
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
            Analytics.CustomEvent(
                "DieSpike",
                new Dictionary<string, object>{
                    {"SpikeName", collision.gameObject.name},
                    {"DieWhenFalling", isFalling}
                }
            );
            rb.velocity = new Vector2(0, 0);
            anim.SetBool("Dead", true);
            explosion.Play();
        }
    }

    protected void GameOver()
    {
        Analytics.CustomEvent(
                "DieLevel",
                new Dictionary<string, object>{
                    {"Level", levelName}
                }
        );
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathLine"))
        {
            Analytics.CustomEvent(
                "DieFallingOff",
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
        
        else if (collision.gameObject.CompareTag("Goal"))
        {
            if (!GetEnoughKeys())
            {
                print("not enough keys!");
                Analytics.CustomEvent(
                    "NotEnoughKeys",
                    new Dictionary<string, object>{
                        {"NumKeys", GetNumKeys()}
                    }
                );
                Instantiate(bubble, Vector3.zero, transform.rotation);
            }
            else
            {
                Analytics.CustomEvent(
                    "PassLevel",
                    new Dictionary<string, object>{
                        {"Level", levelName},
                    }
                );

                Analytics.CustomEvent(
                    "PassLevel_" + levelName,
                    new Dictionary<string, object>{
                        {"Time", Mathf.RoundToInt(Time.time / 10)},
                    }
                );

                SceneManager.LoadScene(nextSceneName);
            }
        }
        
    }

    public String GetLevelName()
    {
        return levelName;
    }

    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }

    public void JumpByForce(float force)
    {
        rb.velocity = new Vector2(0, force);
    }
}
