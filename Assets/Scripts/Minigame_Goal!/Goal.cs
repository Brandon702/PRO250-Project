using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Image[] spaces = new Image[99];
    public GameObject emptySpace;
    public Sprite end, movable;
    private List<List<Image>> map = new List<List<Image>>();
    private Image goal, player;
    private int col = 0, row = 0, endCol = 0, endRow = 0, mapCol, mapRow;
    private List<string> moves = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        int first = 0;
        int second = 0;
        foreach(Image space in spaces)
        {
            if(map.Count == second)
            {
                map.Add(new List<Image>());
            }
            map[second].Add(space);
            if(first >= 10)
            {
                first = 0;
                second++;
            }
            else
            {
                first++;
            }
        }

        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        moves.Add("Move");
    }

    void Left()
    {
        moves.Add("Left");
    }

    void Right()
    {
        moves.Add("Right");
    }

    void Undo()
    {
        if(moves.Count > 0)
        {
            moves.RemoveAt(moves.Count - 1);
        }
    }

    void Run()
    {

    }

    void RandomSpawn()
    {
        var rand = new System.Random();
        col = rand.Next(0, map.Count);
        row = rand.Next(0, map[col].Count);

        mapCol = col;
        mapRow = row;

        map[col][row] = player;

        endCol = rand.Next(0, map.Count);
        endRow = rand.Next(0, map[col].Count);

        while(col - endCol > 2 && row - endRow > 2)
        {
            endCol = rand.Next(0, map.Count);
            endRow = rand.Next(0, map[endCol].Count);
        }

        map[endCol][endRow] = goal;
    }
}
