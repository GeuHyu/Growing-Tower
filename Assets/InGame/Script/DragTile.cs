using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTile : MonoBehaviour
{
    [SerializeField]
    Transform _temp;

    [SerializeField]
    Transform _slider;

    [SerializeField]
    bool _canDrag = true;
    public bool canDrag { set { _canDrag = value; } get { return _canDrag; } }

    ObjectTile _objTile;
    Vector3 _offset = Vector3.zero;
    Vector3 _originPosition;

    private void Awake()
    {
        _objTile = GetComponent<ObjectTile>();
        _originPosition = transform.localPosition;
    }

    public void Down()
    {
        if (!_canDrag)
            return;

        transform.parent = (_temp);
        _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        GameSystem.instance.nowSelectTile = _objTile;
    }

    private void OnMouseDown()
    {
        Down();
    }

    public void Drag()
    {
        if (!_canDrag)
            return;

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
        transform.position = curPosition;
    }

    private void OnMouseDrag()
    {
        Drag();
    }

    public void Up()
    {
        if (!_canDrag)
            return;

        GameSystem.instance.SetOrigin();
    }

    private void OnMouseUp()
    {
        Up();
    }


    public void ToOrigin()
    {
        transform.SetParent(_slider);
        transform.localPosition = _originPosition;
    }
}
