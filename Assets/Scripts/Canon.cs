using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] float canonLength;
    [SerializeField] float delayInMs;
    // Start is called before the first frame update
    void Start()
    {
        GenerateBullet();
    }

    public void GenerateBullet()
    {
        //float ms = Time.deltaTime;

        //while (ms <= delayInMs)
        //{
        //    ms += Time.deltaTime;
        //    yield return null;
        //}
        Bullet clone = (Bullet)Instantiate(bullet, new Vector3(transform.position.x + canonLength,
                    transform.position.y + 0.5f, transform.position.z), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //Bullet clone = (Bullet)Instantiate(bullet, transform.position, transform.rotation);
    }
}
