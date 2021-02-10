using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float jumpForce;
    [SerializeField] float moveForce;
    [SerializeField] LayerMask ground;
    [SerializeField] Color pink;
    [SerializeField] Color blue;
    [SerializeField] AudioSource explosion;
    public bool isDead = false;
    public bool isPink = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        //sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            jump();
        }
        else
        {
            rb.velocity = new Vector2(moveForce, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            isPink = !isPink;
        }
        if (isPink)
        {
            sr.color = pink;
        }
        else
        {
            sr.color = blue;
        }
    }

    private void jump()
    {
        rb.velocity = new Vector2(moveForce, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            isDead = true;
            rb.velocity = new Vector2(0, 0);
            anim.SetBool("Dead", true);
            explosion.Play();
        }
    }

    private void GameOver()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
