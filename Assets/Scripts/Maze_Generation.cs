using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Generation : MonoBehaviour
{
    public GameObject one_wall, finish;
    public int size;
    public Vector2 def_pos;
    public float width, height;

    struct wall
    {
        public Vector3 pos;
        public Quaternion rot;
    }

    class cell
    {
        public bool is_visited, is_wall_right, is_wall_up;
        public wall[] walls;
        public cell(float x, float y, float width, float height)
        {
            is_visited = false;
            is_wall_right = true;
            is_wall_up = true;
            walls = new wall[2];
            walls[0].pos = new Vector3(x, height / 2, y + width);
            walls[0].rot = new Quaternion(0, 0, 0, 0);
            walls[1].pos = new Vector3(x + width/2, height / 2, y + width / 2);
            walls[1].rot = new Quaternion(0.7071f, 0, 0.7071f, 0);
        }
    }

    void Start()
    {
        cell[,] cells = new cell[size, size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                cells[i, j] = new cell(def_pos.x + i * width, def_pos.y + j * width, width, height);
            }
        cells[0, 0].is_visited = true;

        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (cells[i,j].is_visited)
                    Gen_Maze_Map(cells, i, j);

        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                if (cells[i, j].is_wall_right)
                    Instantiate(one_wall, cells[i, j].walls[0].pos, cells[i, j].walls[0].rot);
                if (cells[i, j].is_wall_up)
                {
                    GameObject f = Instantiate(one_wall, cells[i, j].walls[1].pos, cells[i, j].walls[1].rot);
                    f.transform.Rotate(180, 0, 0);
                }
            }

        for (int i = 0; i < size; i++)
        {
            Vector3 p1 = new Vector3(def_pos.x + i * width, height / 2, def_pos.y);
            Vector3 p2 = new Vector3(def_pos.x - width/2, height / 2, def_pos.y + i * width + width/2);
            Quaternion r1 = new Quaternion(0, 0, 0, 0);
            Quaternion r2 = new Quaternion(0.7071f, 0, 0.7071f, 0);
            Instantiate(one_wall, p1, r1);
            GameObject f = Instantiate(one_wall, p2, r2);
            f.transform.Rotate(180, 0, 0);
        }

        Vector3 fin_pos = new Vector3(def_pos.x + size * width - width, 2, def_pos.y + size * width - width/2);
        Quaternion fin_rot = new Quaternion(0, 0, 0, 0);
        Instantiate(finish, fin_pos, fin_rot);

    }

    void Gen_Maze_Map(cell[,] cells,int i_curr, int j_curr)
    {
        int i = i_curr;
        int j = j_curr;
        bool fl = true;
        while (fl)
        {
            int side = Random.Range(1, 5);
            if ((side == 1) && (j < size - 1) && (!cells[i, j + 1].is_visited))
            {
                cells[i, j + 1].is_visited = true;
                cells[i, j].is_wall_right = false;
                j++;
            }
            if ((side == 2) && (i < size - 1) && (!cells[i + 1, j].is_visited))
            {
                cells[i + 1, j].is_visited = true;
                cells[i, j].is_wall_up = false;
                i++;
            }
            if ((side == 3) && (j > 0) && (!cells[i, j - 1].is_visited))
            {
                cells[i, j - 1].is_visited = true;
                cells[i, j - 1].is_wall_right = false;
                j--;
            }
            if ((side == 4) && (i > 0) && (!cells[i - 1, j].is_visited))
            {
                cells[i - 1, j].is_visited = true;
                cells[i - 1, j].is_wall_up = false;
                i--;
            }
            if (!IsSideToMove(cells, i, j))
                fl = false;
        }
    }

    bool IsSideToMove(cell[,] cells, int i, int j)
    {
        bool fl = false;
        if ((j < size - 1) && (!cells[i, j + 1].is_visited))
            fl = true;
        if ((i < size - 1) && (!cells[i+1, j].is_visited))
            fl = true;
        if ((j > 0) && (!cells[i, j - 1].is_visited))
            fl = true;
        if ((i > 0) && (!cells[i - 1, j].is_visited))
            fl = true;
        return fl;
    }

    void Update()
    {
        
    }
}
