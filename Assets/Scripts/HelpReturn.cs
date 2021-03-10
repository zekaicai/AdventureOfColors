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
        AudioSource bgm = Camera.main.GetComponent<AudioSource>();
        if (bgm != null)
        {
            bgm.Pause();
        }
        Time.timeScale = 0f;
    }
    public void ResumeToScene()
    {
        GameObject.Find("Canvas/Buttons/Rules").SetActive(false);
        Time.timeScale = 1f;
        AudioSource bgm = Camera.main.GetComponent<AudioSource>();
        if (bgm != null)
        {
            bgm.Play();
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
