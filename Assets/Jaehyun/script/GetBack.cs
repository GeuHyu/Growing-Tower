using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetBack : MonoBehaviour{

    public void OnButtenClicked()
    {
        SceneManager.LoadScene(0);
    }
}
