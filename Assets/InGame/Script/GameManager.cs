using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AL.ALUtil;
using System.Text;
using UnityEngine.SceneManagement;


public class GameManager : ALSingleton<GameManager> {

    private StringBuilder _builder = new StringBuilder();

    private string _stageName = "Stage1";
    public string stageName { get { return _stageName; } }

    private int _stageType = 3;
    public int stageType { get { return _stageType; } }

    void LoadInGame(int stage, int type)
   {
        _stageName = _builder.Append("Stage").Append(stage).ToString();
        SceneManager.LoadScene("InGame");
   }
}
