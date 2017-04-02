using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour {

    private void Awake()
    {
        Screen.SetResolution(720, 1280, false);
    }

    public void OnButtenClicked()
    {
        SceneManager.LoadScene(1);
    }
}
