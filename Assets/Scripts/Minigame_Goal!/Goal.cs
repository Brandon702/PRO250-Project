using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Goal : MonoBehaviour
{
    public GameObject[] rowOne = new GameObject[11];
    public GameObject[] rowTwo = new GameObject[11];
    public GameObject[] rowThree = new GameObject[11];
    public GameObject[] rowFour = new GameObject[11];
    public GameObject[] rowFive = new GameObject[11];
    public GameObject[] rowSix = new GameObject[11];
    public GameObject[] rowSeven = new GameObject[11];
    public GameObject[] rowEight = new GameObject[11];
    public GameObject[] rowNine = new GameObject[11];
    public TextMeshProUGUI codeBox;
    public Sprite goal, player;
    private List<string> moves = new List<string>();
    //          Starting position   goal's position         current position
    private int col = 0, row = 0, endCol = 0, endRow = 0, mapCol, mapRow;

    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }

    public void Move()
    {
        moves.Add("Move");
        codeBox.text = SetText();
    }

    public void Left()
    {
        moves.Add("Left");
        codeBox.text = SetText();
    }

    public void Right()
    {
        moves.Add("Right");
        codeBox.text = SetText();
    }

    public void Undo()
    {
        if(moves.Count > 0)
        {
            moves.RemoveAt(moves.Count - 1);
        }
        codeBox.text = SetText();
    }

    public void Run()
    {
        StartCoroutine(Calculate());
    }

    IEnumerator Calculate()
    {
        int leftTurns = 0;
        int rotation = 0; //0 - north, 90 & -270 - east, -90 & 270 west, 180 & -180 - south

        foreach (string function in moves)
        {
            switch (function)
            {
                case "Left":
                    leftTurns++;
                    rotation += 90;
                    if (leftTurns > 3)
                    {
                        leftTurns = 0;
                        rotation = 0;
                    }
                    GetObject(mapRow, mapCol).transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;

                case "Right":
                    leftTurns--;
                    rotation -= 90;
                    if (leftTurns < -3)
                    {
                        leftTurns = 0;
                        rotation = 0;
                    }
                    break;

                case "Move":
                    //previous position
                    SetPosition(mapRow, mapCol);
                    //calculate new position
                    switch (leftTurns)
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
                    SetPosition(mapRow, mapCol, player);
                    break;

                default:
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }

        /*if (!Win())
        {
            SetPosition(row, col, player);
            SetPosition(mapRow, mapCol);
            mapRow = row;
            mapCol = col;
        }*/
    }

    void RandomSpawn()
    {
        var rand = new System.Random();
        //starting position of the movable object
        col = rand.Next(0, 11);
        row = rand.Next(0, 9);

        //current position of the object to move
        mapCol = col;
        mapRow = row;

        SetPosition(row, col, player);

        //position of the goal
        endCol = rand.Next(0, 11);
        endRow = rand.Next(0, 9);

        //Make sure the goal isn't where the player is at the very start
        while(col - endCol > 2 && row - endRow > 2)
        {
            endCol = rand.Next(0, 11);
            endRow = rand.Next(0, 8);
        }

        SetPosition(endRow, endCol, goal);
    }

    void SetPosition(int row, int col, Sprite picture = null)
    {
        switch (row)
        {
            case 0:
                rowOne[col].gameObject.GetComponent<Image>().sprite = picture;
                break;

            case 1:
                rowTwo[col].gameObject.GetComponent<Image>().sprite = picture;
                break;

            case 2:
                rowThree[col].gameObject.GetComponent<Image>().sprite = picture;
                break;

            case 3:
                rowFour[col].gameObject.GetComponent<Image>().sprite = picture;
                break;

            case 4:
                rowFive[col].gameObject.GetComponent<Image>().sprite = picture;
                break;

            case 5:
                rowSix[col].gameObject.GetComponent<Image>().sprite = picture;
                break;

            case 6:
                rowSeven[col].gameObject.GetComponent<Image>().sprite = picture;
                break;

            case 7:
                rowEight[col].gameObject.GetComponent<Image>().sprite = picture;
                break;
            
            case 8:
                rowNine[col].gameObject.GetComponent<Image>().sprite = picture;
                break;

            default:
                break;
        }
    }

    string SetText()
    {
        string code = "";
        foreach (string move in moves)
        {
            code += move + "();";
            if (moves.IndexOf(move) != moves.Count - 1)
                code += "\n";
        }
        return code;
    }

    bool Win()
    {
        if (mapCol == endCol && mapRow == endRow)
            return true;
        else
            return false;
    }

    GameObject GetObject(int row, int col)
    {
        return row switch
        {
            0 => rowOne[col],
            1 => rowTwo[col],
            2 => rowThree[col],
            3 => rowFour[col],
            4 => rowFive[col],
            5 => rowSix[col],
            6 => rowSeven[col],
            7 => rowEight[col],
            8 => rowNine[col],
            _ => null,
        };
    }
}
