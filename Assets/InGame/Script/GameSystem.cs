using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AL.ALUtil;
using System.Text;
using System;

public class GameSystem : ALSingletonComponent<GameSystem> {

    public ObjectTile nowSelectTile { set; get; }
    public int count = 0;

    public BaseTile[] _all;

    public void SetOrigin()
    {
        StartCoroutine(SetToOrigin());
    }

    public void SetBaseTile()
    {
        nowSelectTile.dragTile.canDrag = false;
        nowSelectTile = null;
        StopAllCoroutines();
        ++count;
    }

    public bool AllConnection()
    {
        bool[] check = new bool[5];
        check[4] = false;
        for (int i = 0; i < _all.Length; i++)
        {
            if (_all[i].objTile == null)
                continue;

            if (_all[i].right != null)
            {
                if ((_all[i].right.objTile != null))
                    check[0] = true;
            }

            if (_all[i].left != null)
            {
                if ((_all[i].left.objTile != null))
                    check[1] = true;
            }

            if (_all[i].up != null)
            {
                if ((_all[i].up.objTile != null))
                    check[2] = true;
            }

            if (_all[i].down != null)
            {
                if ((_all[i].down.objTile != null))
                    check[3] = true;
            }

            //if (_all[i].right != null && _all[i].right.objTile == null)
            //    check[0] = false;
            //else if (_all[i].right != null)
            //    check[0] = true;

            //if (_all[i].left != null && _all[i].left.objTile == null)
            //    check[1] = false;
            //else if (_all[i].left != null)
            //    check[1] = true;

            //if (_all[i].up != null && _all[i].up.objTile == null)
            //    check[2] = false;
            //else if (_all[i].up != null)
            //    check[2] = true;

            //if (_all[i].down != null && _all[i].down.objTile == null)
            //    check[3] = false;
            //else if (_all[i].down != null)
            //    check[3] = true;

            for (int j = 0; j < check.Length - 1; ++j)
            {
                if (check[j].Equals(true))
                    check[4] = true;
            }
            if (check[4].Equals(false))
                return false;
            else
            {
                for (int k = 0; k < check.Length; ++k)
                {
                    check[k] = false;
                }
            }

        }
        
        return true;
    }

    IEnumerator SetToOrigin()
    {
        yield return new WaitForSeconds(0.05f);
        nowSelectTile.dragTile.ToOrigin();
    }

    //[SerializeField]
    //Transform _canvas;

    //[SerializeField]
    //GameObject[] _tileSets;

    //[SerializeField]
    //Transform _tileParent;

    //[SerializeField]
    //Vector2 _tileSize;

    //StringBuilder _builder = new StringBuilder();
    //int[,] _arr;
    //Vector2 _arrSize = Vector2.zero;
    //string[] sperator = { "\r\n" };

    //private void Awake()
    //{
    //    LoadTileMap(GameManager.instance.stageName, GameManager.instance.stageType);
    //}

    //private void LoadTileMap(string name, int type)
    //{
        //_builder.Remove(0, _builder.Length);
        //GameObject temp = null;
        //switch (type)
        //{
        //    case 3:
        //        temp = Instantiate(_tileSets[0], Vector3.zero, Quaternion.identity, _canvas);
        //        temp.transform.localPosition = new Vector3(-200, 184);

        //        break;

        //    case 4:
        //        temp = Instantiate(_tileSets[1], Vector3.zero, Quaternion.identity, _canvas);
        //        temp.transform.localPosition = new Vector3(-200, 230);
        //        break;

        //    case 5:
        //        temp = Instantiate(_tileSets[2], Vector3.zero, Quaternion.identity, _canvas);
        //        temp.transform.localPosition = new Vector3(-200, 230);
        //        break;
        //}

        //int y = 0;
        //_arr = new int[temp.Length, data.Length];
        //while (y >= data.Length)
        //{
        //    data = temp[y].ToCharArray();
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        _arr[y, i] = int.Parse(data[i].ToString());
        //    }
        //    ++y;
        //}
        //ParseTiles();
    //}

    //private void ParseTiles()
    //{
    //    for (int i = 0; i < _arrSize.x; i++)
    //    {
    //        for (int j = 0; j < _arrSize.y; j++)
    //        {
    //            SetTiles(_arr[j, i], i, j);
    //        }
    //    }
    //}

    //private void SetTiles(int type, int x, int y)
    //{
    //    ///600, 690
    //    _builder.Remove(0, _builder.Length);
    //    TileBehaviour tile = null;
    //    switch(type)
    //    {
    //        case 0:
    //            tile = Resources.Load<BaseTile>(_builder.Append(Pathes.tilePath).Append("BaseTile").ToString());
    //            tile = Instantiate(tile, Vector3.zero, Quaternion.identity, _tileParent);
    //            break;
    //    }
    //    tile.transform.localScale = Vector3.one;
    //    tile.SetTile(x, y);
    //}
}
