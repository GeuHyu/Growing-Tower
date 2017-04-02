using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamepause : MonoBehaviour {
    public GameObject PauseButton;
    public GameObject PlayButton;
    public GameObject GetBackButton;
    public GameObject ToTouch;

    void Awake()
    {
        PlayButton.SetActive(false);
        GetBackButton.SetActive(false);
        ToTouch.SetActive(false);
    }

    public void OffButten()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        ToTouch.SetActive(true);
        GetBackButton.SetActive(true);
        PlayButton.SetActive(true);
    }
    
    public void OnButten1()
    {
        Time.timeScale = 1;
        ToTouch.SetActive(false);
        PlayButton.SetActive(false);
        GetBackButton.SetActive(false);
        PauseButton.SetActive(true);
    }
}
