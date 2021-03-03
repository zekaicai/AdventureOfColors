using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CirclePlayer : Player
{

    private Collider2D coll;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask ground;

    [SerializeField]
    private GameObject afterImagePrefab;
    [SerializeField]
    private float afterImageGenerationTimeInterval = 0.02f;
    private float lastAfterImageTime;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();

        lastAfterImageTime = Time.time;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (CheckDead()) // If player is dead, should set velocity to 0 and return
        {
            return;
        }

        Movement();
        Zuozhetongdao();
        GenerateAfterImage();
    }

    private void Zuozhetongdao()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("111");
                SceneManager.LoadScene("VodkaDance");
            }
        }

    }

    private void Movement()
    {
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
        }
        else
        {
            rb.velocity = new Vector2(moveForce, rb.velocity.y);
        }
    }

    private void GenerateAfterImage()
    {
        float currTime = Time.time;
        if (currTime > (lastAfterImageTime + afterImageGenerationTimeInterval))
        {
            // generate an afterimage
            GameObject afterImage = Instantiate(afterImagePrefab);
            afterImage.SetActive(true);
            lastAfterImageTime = currTime;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(moveForce, jumpForce);
    }
}
