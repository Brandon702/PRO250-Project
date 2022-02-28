using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public GameObject[] spaces = new GameObject[99];
    public Image end, movable;
    private List<List<GameObject>> map = new List<List<GameObject>>();
    private GameObject goal, player;
    private int col = 0, row = 0, endCol = 0, endRow = 0;
    private List<string> moves = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        int first = 0;
        int second = 0;
        foreach(GameObject space in spaces)
        {
            if(map.Count == second)
            {
                map.Add(new List<GameObject>());
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

        player = map[col][row];

        endCol = rand.Next(0, map.Count);
        endRow = rand.Next(0, map[col].Count);

        while(col - endCol > 2 && row - endRow > 2)
        {
            endCol = rand.Next(0, map.Count);
            endRow = rand.Next(0, map[endCol].Count);
        }

        goal = map[endCol][endRow];
    }
}
