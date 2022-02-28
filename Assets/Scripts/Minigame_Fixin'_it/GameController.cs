using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace gameController
{
    public class GameController : MonoBehaviour
    {
        List<String> questions = new List<string>();

        void Start()
        {
            //populate questions list (3 questions)
            questions.Add(
                "public void generateRandoms()" +
                "{" +
                "" +
                "}"
                );
        }

        public void editText()
        {
            //Allow player to edit the object text here
        }

        public void submitText()
        {
            //Submit after editing is done to confirm functionality (unit test?)
        }
    }
}