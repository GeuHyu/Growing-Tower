using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour {


    public void MoveToLevel1()
    {
        //()안에 씬이름 입력좀
        SceneManager.LoadScene("Stage1");
    }
    public void MoveToLevel2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void MoveToLevel3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void MoveToLevel4()
    {
        SceneManager.LoadScene("Stage4");
    }
    public void MoveToLevel5()
    {
        //SceneManager.LoadScene("Stage5");
    }
}
