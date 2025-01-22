using System;
using UnityEngine;

// generick� t��da
public class Grid<TGridObject>
{
    // rozm�r m��ky
    private int _width;
    private int _height;
    private float _cellSize;
    private TGridObject[,] _gridArray;

    // konstruktor m��ky
    public Grid(int width, int height, float cellSize, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;

        _gridArray = new TGridObject[width, height];

        // sestaven� m��ky
        for (int column = 0; column < _gridArray.GetLength(0); column++)
        {
            for (int row = 0; row < _gridArray.GetLength(1); row++)
            {
                if (createGridObject != null)
                {
                    _gridArray[column, row] = createGridObject(this, column, row);
                }
            }
        }
    }

    // z�sk�n� sv�tov� pozice pol��ka
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y, 0) * _cellSize;
    }

    // z�sk�n� m��kov� pozice pol��ka
    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / _cellSize);
        y = Mathf.FloorToInt(worldPosition.y / _cellSize);
    }

    // p�i�ad� hodnotu do m��kov�ho pole, pomoc� sou�adnic
    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < _width && y < _height)
        {
            _gridArray[x, y] = value;
        }
    }

    // p�i�ad� hodnotu do m��zkov� pole, sv�tov�ch sou�adnic
    public void SetGridObject(Vector3 worldPosition, TGridObject value)
    {
        GetXY(worldPosition, out int x, out int y);
        SetGridObject(x, y, value);
    }

    // vr�t� m��kov� objekt, podle zadan�ch sou�adnic
    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < _width && y < _height)
        {
            return _gridArray[x, y];
        }

        return default(TGridObject);
    }

    // vr�t� m��kov� objekt, podle zadan�ch sv�tov�ch sou�adnic
    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);
        return GetGridObject(x, y);
    }

    // z�sk�n� ���ky
    public int GetWidth()
    {
        return _width;
    }

    // z�sk�n� v��ky
    public int GetHeight()
    {
        return _height;
    }
}
