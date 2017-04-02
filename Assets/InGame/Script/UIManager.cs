using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AL.ALUtil;

public class UIManager : ALSingletonComponent<UIManager> {

    [SerializeField]
    Image _character;

    [SerializeField]
    Sprite _happy;

    [SerializeField]
    Image _clear;

    [SerializeField]
    Image _fail;

    public void SetHappy()
    {
        _character.sprite = _happy;
    }

    public IEnumerator Clear()
    {
        float tiemr = 0f;
        while(true)
        {
            tiemr += Time.fixedDeltaTime;
            if (_clear.transform.localPosition.y + 0.1 >= 0f && _clear.transform.localPosition.y - 0.1 <= 0f)
                break;

            _clear.transform.localPosition = ALLerp.Lerp(_clear.transform.localPosition, Vector3.zero, tiemr);
            Debug.Log(_clear.transform.localPosition + "|" + tiemr);
            yield return null;
        }
    }

    public IEnumerator Fail()
    {
        float tiemr = 0f;
        while (true)
        {
            tiemr += Time.fixedDeltaTime;
            if (_fail.transform.localPosition.y + 0.1 >= 0f && _fail.transform.localPosition.y - 0.1 <= 0f)
                break;

            _fail.transform.localPosition = ALLerp.Lerp(_fail.transform.localPosition, Vector3.zero, tiemr);
            yield return null;
        }
    }
}
