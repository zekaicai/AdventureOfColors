using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    // public void PlayGame()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }
    public void PlayGame()
    {
        UIDisable();
        GameObject.Find("Canvas/MainMenu/Selection").SetActive(true);
    }
    public void SwitchToLevel()
    {
        string name =  EventSystem.current.currentSelectedGameObject.name;
        if(name == "1")
        {
            SceneManager.LoadScene("SquareTutorial");
        }
        if(name == "2")
        {
            SceneManager.LoadScene("VodkaDance");
        }
        if(name == "3")
        {
            SceneManager.LoadScene("SquareScene");
        }

        
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
    public void ResumeToScene()
    {
        GameObject.Find("Canvas/MainMenu/Rules").SetActive(false);
        GameObject.Find("Canvas/MainMenu/GameDesign").SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
