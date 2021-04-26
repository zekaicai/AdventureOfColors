using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using UnityEngine.Audio;

public class HelpReturn : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject player;
    public void ShowRules(){

        Analytics.CustomEvent("HitHelpInLevel");
        GameObject.Find("Canvas/Buttons/Rules").SetActive(true);
    }
    public void ShowMusic(){

        GameObject.Find("Canvas/Buttons/MusicPanel").SetActive(true);
    }
    public void PauseGame()
    {
        AudioSource bgm = player.GetComponent<PlayerPos>().bgm;
        
        //AudioSource bgm = Camera.main.GetComponent<AudioSource>();
        if (bgm != null)
        {
            bgm.Pause();
        }
        Time.timeScale = 0f;
    }
    public void ResumeToScene()
    {
        AudioSource bgm = player.GetComponent<PlayerPos>().bgm;
        if (bgm != null)
        {
            bgm.Play();
        }
        GameObject.Find("Canvas/Buttons/Rules").SetActive(false);
        
        Time.timeScale = 1f;
    }
    public void MusicExit()
    {
        GameObject.Find("Canvas/Buttons/MusicPanel").SetActive(false);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }
    
}
