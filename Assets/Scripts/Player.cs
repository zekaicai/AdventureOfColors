using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;


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
    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        ChangeColor();
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

            AnalyticsResult result = Analytics.CustomEvent(
                "DeathOnSpike",
                new Dictionary<string, object>{
                    {"SpikeName", collision.gameObject.name}
                }
            );

            Debug.Log(collision.gameObject.name);
            Debug.Log(result);

            rb.velocity = new Vector2(0, 0);
            anim.SetBool("Dead", true);
            explosion.Play();
        }
    }

    protected void GameOver()
    {

        AnalyticsResult result = Analytics.CustomEvent(
                "DeathOnFalling",
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
                "DeathOnFalling",
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
    }
}
