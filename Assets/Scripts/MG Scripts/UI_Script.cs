using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class UI_Script : MonoBehaviour
{
    public Text Timer;
    public Text Obj;
    public float timerVal = 30f;
    public GameObject topPanel;
    public GameObject GameOverUI;
    public GameObject PauseUI;
    public AudioSource Flatline;
    public AudioSource GameOverMusic;
    public AudioSource HeartBEEP;
    public AudioSource TimeTick;
    public Image TimerBackground;
    public bool ticking = true;
    private void Start()
    {
        this.Wait(1f, TimerTick); 
    }
    public void TimerTick()
    {
        if (timerVal == 5f && ticking) 
        {
            TimerBackground.color = new Color (255, 0, 0, 150);
            TimeTick.Play();
        }
        if (timerVal > 0 && ticking)
        {
            Timer.text = timerVal + " Seconds";
            timerVal--;
            this.Wait(1f, TimerTick);
        }
        else if (timerVal == 0 && ticking) 
        {
            Timer.text = timerVal + " Seconds";
            Flatline.Play();            
            HeartBEEP.Stop();
            this.Wait(5f, dead);
        }       
    }
    void dead() 
    {
        topPanel.SetActive(false);
        GameOverUI.SetActive(true);
        GameOverMusic.Play();
    }
    public void Paused() 
    {
        topPanel.SetActive(false);
        PauseUI.SetActive(true);
        ticking = false;
    }
    public void exitButton() 
    {
        Application.Quit();
    }public void ResumeButton() 
    {
        topPanel.SetActive(true);
        PauseUI.SetActive(false);
        ticking = true;
    }
    public void RestartButton() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

}

