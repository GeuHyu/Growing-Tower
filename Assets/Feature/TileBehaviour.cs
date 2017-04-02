using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TILE_TYPE
{
    BASE_TILE,
    HOUSE_TILE,
    APARTMENT_TILE,
    CGV_TILE,
    CONVI_TILE,
    TREE_TILE,
    SCHOOL_TILE,
    PARK_TILE,
    HOSTITAL_TILE,
}

public class TileBehaviour : MonoBehaviour
{
    [SerializeField]
    protected TILE_TYPE _tileType = TILE_TYPE.BASE_TILE;
    public TILE_TYPE tileType { set { _tileType = value; } get { return _tileType; } }

    [SerializeField]
    protected Vector2 _index = Vector2.zero;
    public Vector2 index { set { _index = value; } get { return _index; } }

    [SerializeField]
    protected Vector2 _tileSize = Vector2.zero;
    public Vector2 tileSize { set { _tileSize = value; } get { return _tileSize; } }

    protected int[][] _effectArray;
    public int[][] effectArray { set { _effectArray = value; } get { return _effectArray; } }

    public virtual void TileEffect() { }

    public void SetTile(float x, float y)
    {
        _index.x = x;
        _index.y = y;
        transform.localPosition = new Vector3((_index.x * tileSize.x), (_index.y * tileSize.y * -1f), 0f);
        Debug.Log(transform.localPosition);
        Debug.Log(_index.x + "|" + _index.y + "|" + tileSize.x + "|" + tileSize.y);
    }
}