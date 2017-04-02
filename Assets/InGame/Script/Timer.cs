using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    Image _bar;

    [SerializeField]
    float _maxTim;

    float _amount = 0;

	void Awake ()
    {
        _amount = 1f / _maxTim;
	}
	
	void Update ()
    {
        if (_bar.fillAmount <= 0)
        {
            //SceneManager.LoadScene("GameOver");
        }

        _bar.fillAmount -= _amount;
    }
}
