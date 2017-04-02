using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDeveloper : MonoBehaviour {

    public GameObject poppop;

    void Awake()
    {
        poppop.SetActive(false);
    }

    public void OnButten()
    {
        poppop.SetActive(true);
    }
    public void OffButten()
    {
        poppop.SetActive(false);
    }
}
