using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AL.ALUtil;

public class MissonManager : ALSingletonComponent<MissonManager> {

    [SerializeField]
    int _failCount = 0;

    [SerializeField]
    List<ObjectTile> _mainObjects;

    [SerializeField]
    TILE_TYPE[] _mainTypes;

    public int addCount;

    int _missionCount = 0;
    bool _value = false;


    private void Update()
    {
        CheckFail();
    }

    public bool CheckMissionTarget(TILE_TYPE type, ObjectTile tyle)
    {
        _value = GameSystem.instance.AllConnection();
        if (!_mainObjects.Contains(tyle))
            return false;

        bool temp = false;
        for (int i = 0; i < _mainTypes.Length; i++)
        {
            if (_mainTypes[i].Equals(type))
            {
                ++_missionCount;
                temp = true;
            }
        }
        if (temp)
            CheckClear();
        return temp;
    }

    private void CheckClear()
    {
        //Debug.Log(temp);
        if (_missionCount.Equals(_mainObjects.Count - addCount) && _value)
        {
            UIManager.instance.SetHappy();
            UIManager.instance.StartCoroutine(UIManager.instance.Clear());
            Debug.Log("클리어");
        }
    }
    private void CheckFail()
    {
        if (GameSystem.instance.count >= _failCount && !_value)
        {
            UIManager.instance.StartCoroutine(UIManager.instance.Fail());
            Debug.Log("실패");
        }
    }
}
