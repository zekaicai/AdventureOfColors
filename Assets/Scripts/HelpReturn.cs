using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class HelpReturn : MonoBehaviour
{
    public void ShowRules(){

        Analytics.CustomEvent("HitHelpInLevel");
        GameObject.Find("Canvas/Buttons/Rules").SetActive(true);
    }
    public void PauseGame()
    {
        AudioSource bgm = Camera.main.GetComponent<AudioSource>();
        if (bgm != null)
        {
            bgm.Pause();
        }
        Time.timeScale = 0f;
    }
    public void ResumeToScene()
    {
        AudioSource bgm = Camera.main.GetComponent<AudioSource>();
        if (bgm != null)
        {
            bgm.Play();
        }
        GameObject.Find("Canvas/Buttons/Rules").SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
