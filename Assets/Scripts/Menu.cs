using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void UIEnable()
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }
    public void UIDisable()
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(false);
    }
    public void ShowRules(){
        GameObject.Find("Canvas/MainMenu/Rules").SetActive(true);
    }
    public void ShowGameDesign(){
        GameObject.Find("Canvas/MainMenu/GameDesign").SetActive(true);
    }
}
