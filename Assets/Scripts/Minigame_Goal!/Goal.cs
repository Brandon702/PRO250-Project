using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject[] spaces = new GameObject[99];
    private List<List<GameObject>> map = new List<List<GameObject>>();

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {

    }

    void Left()
    {

    }

    void Right()
    {

    }
}
