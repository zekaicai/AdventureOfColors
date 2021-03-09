using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HelpReturn : MonoBehaviour
{
    public void ShowRules(){
        GameObject.Find("Canvas/Buttons/Rules").SetActive(true);
        
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeToScene()
    {
        GameObject.Find("Canvas/Buttons/Rules").SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
