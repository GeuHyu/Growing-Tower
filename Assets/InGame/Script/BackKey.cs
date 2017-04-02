using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackKey : MonoBehaviour {

	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch(SceneManager.GetActiveScene().buildIndex)
            {
                case 0:
                    Application.Quit();
                    break;

                default:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                    break;
            }
        }	
	}
}
