using System;
using UnityEngine;

// generická tøída
public class Grid<TGridObject>
{
    // rozmìr møížky
    private int _width;
    private int _height;
    private float _cellSize;
    private TGridObject[,] _gridArray;

    // konstruktor møížky
    public Grid(int width, int height, float cellSize, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;

        _gridArray = new TGridObject[width, height];

        // sestavení møížky
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

    // získání svìtové pozice políèka
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y, 0) * _cellSize;
    }

    // získání møížkové pozice políèka
    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / _cellSize);
        y = Mathf.FloorToInt(worldPosition.y / _cellSize);
    }

    // pøiøadí hodnotu do møížkového pole, pomocí souøadnic
    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < _width && y < _height)
        {
            _gridArray[x, y] = value;
        }
    }

    // pøiøadí hodnotu do møízkové pole, svìtových souøadnic
    public void SetGridObject(Vector3 worldPosition, TGridObject value)
    {
        GetXY(worldPosition, out int x, out int y);
        SetGridObject(x, y, value);
    }

    // vrátí møížkový objekt, podle zadaných souøadnic
    public TGridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < _width && y < _height)
        {
            return _gridArray[x, y];
        }

        return default(TGridObject);
    }

    // vrátí møížkový objekt, podle zadaných svìtových souøadnic
    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);
        return GetGridObject(x, y);
    }

    // získání šíøky
    public int GetWidth()
    {
        return _width;
    }

    // získání výšky
    public int GetHeight()
    {
        return _height;
    }
}
