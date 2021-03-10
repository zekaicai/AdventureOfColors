using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    private void Start()
    {
        print("hellp");
    }
    //check for tutorial
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var name = gameObject.name;
        if(name == "Check1")
        {
            GameObject.Find("Canvas/Panel/1Check").SetActive(true);
            Invoke("ShadeHint", 3f);
        }
        else if(name == "Check2")
        {
            GameObject.Find("Canvas/Panel/2Check").SetActive(true);
            Invoke("ShadeHint", 3f);
        }
        else if(name == "Check3")
        {
            GameObject.Find("Canvas/Panel/3Check").SetActive(true);
            Invoke("ShadeHint", 3f);
        }
        else if(name == "Check4")
        {
            GameObject.Find("Canvas/Panel/4Check").SetActive(true);
            Invoke("ShadeHint", 3f);
        }
        else if(name == "Check5")
        {
            GameObject.Find("Canvas/Panel/5Check").SetActive(true);
            Invoke("ShadeHint", 3f);
        }
        
        Debug.Log("Name is " + name);
        //var tag = collision.GetComponent<Collider>().tag;

        // Debug.Log("Tag is " + tag);
    }
    private void ShadeHint()
    {
        GameObject.Find("Canvas/Panel/1Check").SetActive(false);
        GameObject.Find("Canvas/Panel/2Check").SetActive(false);
        GameObject.Find("Canvas/Panel/3Check").SetActive(false);
        GameObject.Find("Canvas/Panel/4Check").SetActive(false);
        GameObject.Find("Canvas/Panel/5Check").SetActive(false);
    }

        // 销毁当前游戏物体
       // Destroy(this.gameObject); 
        // else if(collision.gameObject.tag == "Check")
        // {
            
        //     if(collision.gameObject.name == "Check1")
        //     {
        //         GameObject.Find("Canvas/1Check").SetActive(true);
        //     }
        // }
}
