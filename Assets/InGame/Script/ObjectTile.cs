using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    SLEEP,
    RUNNING,
}

public class ObjectTile : TileBehaviour {

    [SerializeField]
    STATE _state;
    public STATE state { set { _state = value; } get { return _state; } }

    [SerializeField]
    DragTile _dragTile = null;
    public DragTile dragTile { get { return _dragTile; } }

    [SerializeField]
    BaseTile _baseTile = null;
    public BaseTile baseTile { set { _baseTile = value; } get { return _baseTile; } }

    public bool already { private set; get; }

    private void Awake()
    {
        already = false;
    }

    /// <summary>
    /// 앙 기모띠 함수
    /// </summary>
    public virtual void Excute() { }
    public virtual int Excute(int count, int dir, TILE_TYPE type) // dir = 1 -> 오, 2 -> 왼, 3 -> 위, 4 -> 아  
    {
        //if (_tileType.Equals(type))
        {
            //Debug.Log(this.name);
            if (!MissonManager.instance.CheckMissionTarget(type, this))
            {
                //switch(dir)
                //{
                //    case 1:
                //        return ConnectionExcuteUp(count, type) + ConnectionExcuteLeft(count, type) + ConnectionExcuteDown(count, type) + count;

                //    case 2:
                //        return ConnectionExcuteUp(count, type) + ConnectionExcuteRight(count, type) + ConnectionExcuteDown(count, type) + count;

                //    case 3:
                //        return ConnectionExcuteDown(count, type) + ConnectionExcuteRight(count, type) + ConnectionExcuteLeft(count, type) + count;

                //    case 4:
                //        return ConnectionExcuteUp(count, type) + ConnectionExcuteRight(count, type) + ConnectionExcuteLeft(count, type) + count;
                //}
            }
        }
        return count;
    }

    public int ConnectionExcuteRight(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null)
            return count;

        if (_baseTile.right.objTile != null && _baseTile.right.objTile._tileType.Equals(type))
        {
            _baseTile.right.objTile.Excute(count, 1, type);
            return ConnectionRight(count + 1, type);
        }
        return count;
    }

    public int ConnectionExcuteLeft(int count, TILE_TYPE type)
    {
        if (_baseTile.left == null)
            return count;

        if (_baseTile.left.objTile != null && _baseTile.left.objTile._tileType.Equals(type))
        {
            _baseTile.left.objTile.Excute(count, 2, type);
            return ConnectionRight(count + 1, type);
        }
        return count;
    }

    public int ConnectionExcuteUp(int count, TILE_TYPE type)
    {
        if (_baseTile.up == null)
            return count;

        if (_baseTile.up.objTile != null && _baseTile.up.objTile._tileType.Equals(type))
        {
            _baseTile.up.objTile.Excute(count, 3, type);
            return ConnectionRight(count + 1, type);
        }
        return count;
    }

    public int ConnectionExcuteDown(int count, TILE_TYPE type)
    {
        if (_baseTile.down == null)
            return count;

        if (_baseTile.down.objTile != null && _baseTile.down.objTile._tileType.Equals(type))
        {
            _baseTile.down.objTile.Excute(count, 4, type);
            return ConnectionRight(count + 1, type);
        }
        return count;
    }

    public int ConnectionExcuteRightUp(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null && _baseTile.up == null)
            return count;

        if (_baseTile.right.objTile != null && _baseTile.up.objTile != null 
            && _baseTile.right.objTile._tileType.Equals(type) && _baseTile.up.objTile._tileType.Equals(type))
        {
            _baseTile.right.objTile.Excute();
            _baseTile.up.objTile.Excute();
            return ConnectionRight(count + 1, type);
        }
        return count;
    }

    public int ConnectionExcuteRightDown(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null && _baseTile.up == null)
            return count;

        if (_baseTile.down.objTile != null && _baseTile.right.objTile != null 
            && _baseTile.down.objTile._tileType.Equals(type) && _baseTile.right.objTile._tileType.Equals(type))
        {
            _baseTile.right.objTile.Excute();
            _baseTile.down.objTile.Excute();
            return ConnectionRight(count + 1, type);
        }
        return count;
    }

    public int ConnectionExcuteLeftUp(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null && _baseTile.up == null)
            return count;

        if (_baseTile.left.objTile != null && _baseTile.up.objTile != null 
            && _baseTile.left.objTile._tileType.Equals(type) && _baseTile.up.objTile._tileType.Equals(type))
        {
            _baseTile.left.objTile.Excute();
            _baseTile.up.objTile.Excute();
            return ConnectionRight(count + 1, type);
        }
        return count;
    }

    public int ConnectionExcuteLeftDown(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null && _baseTile.up == null)
            return count;

        if (_baseTile.down.objTile != null && _baseTile.left.objTile != null 
            && _baseTile.down.objTile._tileType.Equals(type) && _baseTile.left.objTile._tileType.Equals(type))
        {
            _baseTile.down.objTile.Excute();
            _baseTile.left.objTile.Excute();
            return ConnectionRight(count + 1, type);
        }
        return count;
    }

    // -------

    public int CheckConnection(int count, int dir ,TILE_TYPE type)
    {
        switch (dir)
        {
            case 1:
                return CheckConnection(count, 3, type) + CheckConnection(count, 2, type) + CheckConnection(count, 4, type);

            case 2:
                return CheckConnection(count, 3, type) + CheckConnection(count, 1, type) + CheckConnection(count, 4, type);

            case 3:
                return CheckConnection(count, 4, type) + CheckConnection(count, 1, type) + CheckConnection(count, 2, type);

            case 4:
                return CheckConnection(count, 3, type) + CheckConnection(count, 1, type) + CheckConnection(count, 2, type);
        }
        return count;
        //int sum = ConnectionRight(0, type) + ConnectionLeft(0, type) + ConnectionUp(0, type) + ConnectionDown(0, type) + 1; // 1은 자기 자신
        //Debug.Log(sum + "|" + GameSystem.instance.count);
        //if (GameSystem.instance.count.Equals(sum))
        //    return true;
        //return false;
    }

    public int ConnectionAll(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null)
            return count;

        if (_baseTile.right.objTile != null)
            return ConnectionRight(count + 1, type);
        return count;
    }

    public int ConnectionRight(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null)
            return count;

        if (_baseTile.right.objTile != null)
            return ConnectionRight(count + 1, type);
        return count;
    }

    public int ConnectionLeft(int count, TILE_TYPE type)
    {
        if (_baseTile.left == null)
            return count;

        if (_baseTile.left.objTile == null)
            return ConnectionRight(count + 1, type);
        return count;
    }

    public int ConnectionUp(int count, TILE_TYPE type)
    {
        if (_baseTile.up == null)
            return count;

        if (_baseTile.up.objTile == null)
            return ConnectionRight(count + 1, type);
        return count;
    }

    public int ConnectionDown(int count, TILE_TYPE type)
    {
        if (_baseTile.down == null)
            return count;

        if (_baseTile.down.objTile == null)
            return ConnectionRight(count + 1, type);
        return count;
    }

    public int ConnectionRightUp(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null && _baseTile.up == null)
            return count;

        if (_baseTile.right.objTile == null && _baseTile.up.objTile == null)
            return ConnectionRight(count + 1, type);
        return count;
    }

    public int ConnectionRightDown(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null && _baseTile.up == null)
            return count;

        if (_baseTile.down.objTile == null && _baseTile.right == null)
            return ConnectionRight(count + 1, type);
        return count;
    }

    public int ConnectionLeftUp(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null && _baseTile.up == null)
            return count;

        if (_baseTile.left.objTile == null && _baseTile.up.objTile == null)
            return ConnectionRight(count + 1, type);
        return count;
    }

    public int ConnectionLeftDown(int count, TILE_TYPE type)
    {
        if (_baseTile.right == null && _baseTile.up == null)
            return count;

        if (_baseTile.down.objTile == null && _baseTile.left.objTile == null)
            return ConnectionRight(count + 1, type);
        return count;
    }
}
