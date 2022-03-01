using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Image[] spaces = new Image[99];
    public Sprite goal, player;
    private List<List<Sprite>> map = new List<List<Sprite>>();
    private List<string> moves = new List<string>();
    //          Starting position   goal's position         current position
    private int col = 0, row = 0, endCol = 0, endRow = 0, mapCol, mapRow;

    // Start is called before the first frame update
    void Start()
    {
        int first = 0;
        int second = 0;
        foreach(Image space in spaces)
        {
            if(map.Count == second)
            {
                map.Add(new List<Sprite>());
            }
            map[second].Add(space.sprite);
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

    void Calculate()
    {
        int rightTurns = 0;
        int rotation = 0; //0 - north, 90 & -270 - east, -90 & 270 west, 180 & -180 - south

        foreach(string function in moves)
        {
            switch (function)
            {
                case "Right":
                    rightTurns++;
                    rotation += 90;
                    if (rightTurns > 3)
                    {
                        rightTurns = 0;
                        rotation = 0;
                    }
                    
                    break;

                case "Left":
                    rightTurns--;
                    rotation -= 90;
                    if (rightTurns < -3)
                    {
                        rightTurns = 0;
                        rotation = 0;
                    }
                    break;

                case "Move":
                    //previous position
                    map[mapCol][mapRow] = null;
                    //calculate new position
                    switch (rightTurns)
                    {
                            //west
                        case -1:
                            mapCol--;
                            break;

                            //south
                        case -2:
                            mapRow--;
                            break;
                        
                            //east
                        case -3:
                            mapCol++;
                            break;

                            //east
                        case 1:
                            mapCol++;
                            break;

                            //south
                        case 2:
                            mapRow--;
                            break;

                            //west
                        case 3:
                            mapCol--;
                            break;

                            //north
                        case 0:
                            mapRow++;
                            break;

                        default:
                            break;
                    }
                    //new position
                    map[mapCol][mapRow] = player;
                    break;

                default:
                    break;
            }
        }
    }

    void RandomSpawn()
    {
        var rand = new System.Random();
        //starting position of the movable object
        col = rand.Next(0, map.Count);
        row = rand.Next(0, map[col].Count);

        //current position of the object to move
        mapCol = col;
        mapRow = row;

        map[col][row] = player;

        //position of the goal
        endCol = rand.Next(0, map.Count);
        endRow = rand.Next(0, map[col].Count);

        //Make sure the goal isn't where the player is at the very start
        while(col - endCol > 2 && row - endRow > 2)
        {
            endCol = rand.Next(0, map.Count);
            endRow = rand.Next(0, map[endCol].Count);
        }

        map[endCol][endRow] = goal;
    }
}
