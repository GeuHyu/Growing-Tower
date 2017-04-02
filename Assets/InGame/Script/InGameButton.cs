using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButton : MonoBehaviour {

    public void gotoMain()
    {
        SceneManager.LoadScene("main");
    }
}
