using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    int _width, _height;
    int _cellsize;
    int[,] _grid;
    TextMesh[,] _textMeshes;

    // Start is called before the first frame update
    public Grid(int width, int height, int cellsize)
    {
        _width = width;
        _height = height;
        _cellsize = cellsize;

        _grid = new int[width,height];
        _textMeshes = new TextMesh[width,height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                _grid[i, j] = 0;
                var position = GetWorldPosition(i,j);

               



            }
        }

    }


    Vector3 GetWorldPosition(int x, int y) { return new Vector3(x, y) * _cellsize; }
}
