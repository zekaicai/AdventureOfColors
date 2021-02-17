using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public bool isRed = true;
    protected Rigidbody2D rb;
    protected Animator anim;
    protected SpriteRenderer sr;
    [SerializeField] protected AudioSource explosion;
    [SerializeField] protected float moveForce;

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
        if (collision.gameObject.CompareTag("Spike"))
        {
            rb.velocity = new Vector2(0, 0);
            anim.SetBool("Dead", true);
            explosion.Play();
        }
    }

    protected void GameOver()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
