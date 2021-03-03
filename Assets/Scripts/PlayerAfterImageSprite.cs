using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer sr;
    private SpriteRenderer playerSr;

    [SerializeField]
    private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    [SerializeField]
    private float alphaSet = 0.85f;
    [SerializeField]
    private float alphaMultiplier = 0.85f;

    private Color color;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        print(player);
        playerSr = player.GetComponent<SpriteRenderer>();
        color = playerSr.color;

        alpha = alphaSet;
        sr.sprite = playerSr.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        Color fadedColor = new Color(color.r, color.g, color.b, alpha) ;
        sr.color = fadedColor;

        if (Time.time >= (timeActivated + activeTime))
        {
            Destroy(this.gameObject);
        }
    }
}
