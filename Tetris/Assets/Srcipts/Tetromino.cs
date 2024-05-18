using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    // Start is called before the first frame update
    private float previousTime;
    public float fallTime = 0.8f;
    public static int width = 10;
    public static int height = 20;
    public Vector3 rotationPoint;
    public static Transform[,] grid = new Transform[width, height];



    public void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            Debug.Log("Show " + x + " " + y);
            grid[x, y] = child;
        }
    }


    public void Start()
    {

        //tempTime = fallTime;
    }
    public bool ValidMove()
    {
        foreach (Transform child in transform)
        {

            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);


            if (x >= width || y >= height)
            {
                return false;
            }
            if (x < 0 || y < 0)
            {
                return false;
            }

            if (grid[x, y] != null)
            {
                return false;
            }

        }
        return true;



    }





    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, 90);

            if (!ValidMove())
            {
                transform.RotateAround(convertedPoint, Vector3.forward, -90);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = transform.position + Vector3.left;
            if (!ValidMove())
            {
                transform.position = transform.position + Vector3.right;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = transform.position + Vector3.right;
            if (!ValidMove())
            {
                Debug.Log("Show " + transform.position.x + " " + transform.position.y);
                transform.position = transform.position + Vector3.left;
            }
        }

        float tempTime = fallTime;
        // it has to be before because if it was not the regular fall would overide the temptime
        if (Input.GetKey(KeyCode.DownArrow))
        {

            tempTime = tempTime / 10;
            Debug.Log("Down Key is Held" + tempTime);

        }

        if (Time.time - previousTime > tempTime)
        {

            transform.position = transform.position + Vector3.down;
            previousTime = Time.time;

            if (!ValidMove())
            {


                transform.position = transform.position + Vector3.up;
                this.enabled = false;
                AddToGrid();
                FindObjectOfType<Spawner>().SpawnTetromino();
                CheckLines();
            }


        }





    }

    public void CheckLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    public bool HasLine(int i) 
    {
        for (int j=0; j < width; j++)
        {
            if (grid[j,i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    public void RowDown(int i)
    {
     for (int y = i; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].transform.position += Vector3.down;
                }
            }
        }
    }
}
