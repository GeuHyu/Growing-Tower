using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTile : TileBehaviour
{
    [SerializeField]
    ObjectTile _objTile = null;
    public ObjectTile objTile { get { return _objTile; } }

    [SerializeField]
    BaseTile _right = null;
    public BaseTile right { get { return _right; } }

    [SerializeField]
    BaseTile _left = null;
    public BaseTile left { get { return _left; } }

    [SerializeField]
    BaseTile _up = null;
    public BaseTile up { get { return _up; } }

    [SerializeField]
    BaseTile _down = null;
    public BaseTile down { get { return _down; } }

    public bool angGimoDDi = false;

    Rect _rect;

    private void Awake()
    {
        _rect = new Rect(transform.localPosition.x - (_tileSize.x * 0.5f), transform.localPosition.y - (_tileSize.y * 0.5f), _tileSize.x, _tileSize.y);
    }

    private void Update()
    {
        if (CheckTileIn() && Input.GetMouseButtonUp(0) && _objTile == null)
        {
            _objTile = GameSystem.instance.nowSelectTile;
            GameSystem.instance.SetBaseTile();
            _objTile.transform.SetParent(transform);
            _objTile.transform.localPosition = Vector3.zero;
            _objTile.baseTile = this;
            int value = _right != null && _right._objTile != null ? right._objTile.Excute(0, 1, objTile.tileType) : -1;
            value = left != null && left._objTile != null ? left._objTile.Excute(0, 2, objTile.tileType) : -1;
            value = up != null && up._objTile != null ? up._objTile.Excute(0, 3, objTile.tileType) : -1;
            value = down != null && down._objTile != null ? down._objTile.Excute(0, 4, objTile.tileType) : -1;
            angGimoDDi = true;
        }
    }

    bool CheckTileIn()
    {
        if (GameSystem.instance.nowSelectTile != null && _rect.Contains(GameSystem.instance.nowSelectTile.transform.localPosition))
            return true;
        return false;
    }
}
