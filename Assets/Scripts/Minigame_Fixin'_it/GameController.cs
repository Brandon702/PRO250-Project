using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game;
using UnityEngine;
using System;
using TMPro;

namespace gameController
{
    public class GameController : MonoBehaviour
    {
        #region Variables
        List<String> questions = new List<string>();
        List<String> answers = new List<string>();
        GameObject inputText_Canvas;
        TextMeshPro textChanger;
        TMP_InputField monitorText;
        TextMeshPro userText;
        TextMeshPro playerInputText;
        Rigidbody playerRigidBody;
        public List<Rigidbody> rigidbodies = new List<Rigidbody>();
        int currLevel = 0;
        int score = 0;
        public bool MonitorAwake = false;

        #endregion

        #region Core Functions
        private void Awake()
        {
            answers.Add(
                @"public List<int> GenerateList(int length)
        {
            List<int> intList = new List<int>();
            for(int i = 0; i < length; i++)
            {
                intList.Add(i+1);
                Debug.Log(intList[i]);
            }
            return intList;
        }"
                );
            questions.Add(
                "//Instructions: Return a list of integers from 1 to 10\n" +
                "\n" +
                "public List<int> generateList()\n" +
                "{\n" +
                "   List<int> intList = new List<int>();\n" +
                "   //HINT: Use a for loop to generate a set number of integers\n" +
                "       //Add to the integer list object\n" +
                "}\n"
                );
            answers.Add(
                @""
                );
            questions.Add(
                "//Instructions: Concatenate a list of strings into one string in a readable format\n" +
                "//HINT: Add a \", \" to the end of each addition to the string\n" +
                "public string Concat(List<string> strings)\n" +
                "{\n" +
                "   int listSize = strings.Count - 1;\n" +
                "   for (int i = listSize; i < 0; i++)\n" +
                "   {\n" +
                "       final += strings[i];\n" +
                "   }\n" +
                "   //HINT: Dont forget to cut off the end of a string if it contains unnessisary chars\n" +
                "   Debug.Log(final);\n" +
                "   return final;\n" +
                "}\n"
                );
            answers.Add(
                @"public float VolumeOfTheSun(float radius)
        {
            float final;
            final = (float)((4 / 3) * Math.PI * Mathf.Pow(radius, 3));
            Debug.Log(final);
            return final;
        }"
                );
            questions.Add(
                "//Instructions: Calculate the volume of the sun... yes really, you are given the radius and the volume formula to make it easier luckily\n" +
                "//HINT: Dont forget to use Math functions such as Math.PI to use pi or Math.E for Eulers number to calcualte special numbers\n" +
                "public float VolumeOfTheSun(float radius)\n" +
                "{\n" +
                "    //HINT: Formula for finding the volume of a sphere is as follows: (((4/3) * PI) radius^3)\n" +
                "}\n"
                );
        }

        void Start()
        {
            inputText_Canvas = GameObject.Find("InputText_Canvas");
            textChanger = GameObject.Find("GameText").GetComponent<TextMeshPro>();
            userText = GameObject.Find("UserText").GetComponent<TextMeshPro>();
            monitorText = GameObject.Find("InputText").GetComponent<TMP_InputField>();
            inputText_Canvas.SetActive(false);

            foreach(Rigidbody player in rigidbodies)
            {
                if (player != null && player.gameObject.active) { playerRigidBody = player; }
            }
            Debug.Log(playerRigidBody);
            QuestionController(currLevel);
        }
        #endregion

        #region Test Functions
        //Generate a list of ints from from 1 to a given length
        //HINT: Use a loop to get a set number of ints
        public List<int> GenerateList(int length)
        {
            List<int> intList = new List<int>();
            for(int i = 0; i < length; i++)
            {
                intList.Add(i+1);
                Debug.Log(intList[i]);
            }
            return intList;
        }

        //Concatate a list of strings in reverse 
        //HINT: Add ", " to the end of each addition to the string
        //HINT: Dont forget to cut off the end of a string if it contains unnessisary chars
        public string Concat(List<string> strings)
        {
            string final = "";
            int listSize = strings.Count-1;
            for(int i = listSize; i >= 0; i--)
            {
                final += strings[i] + ", ";
            }
            if(final.Length > 2)
            {
                final = final.Remove(final.Length - 2);
            }
            Debug.Log(final);
            return final;
        }

        //Math questions or somein' goes ere'

        //Make radius equal 695,700 KM
        //HINT: Dont forget to use Math functions such as Math.PI to use pi or Math.E for Eulers number to calcualte special numbers
        //HINT: Dont be afraid to look up the formula for volume of a sphere
        //HINT: Formula for finding the volume of a sphere is as follows: (((4/3) * PI) radius^3)
        public float VolumeOfTheSun(float radius)
        {
            float final;
            final = (float)((4 / 3) * Math.PI * Mathf.Pow(radius, 3));
            Debug.Log(final);
            return final;
        }

        #endregion

        #region Functions
        public bool Result()
        {
            bool res = false;
            switch(currLevel)
            {
                case 0:
                    res = test(userText.text, 0);
                    break;
                case 1:
                    res = test(userText.text, 1);
                    break;
                case 2:
                    res = test(userText.text, 2);
                    break;
                default:
                    break;
            }

            return res;
        }

        public bool test(string userInput, int testNum)
        {
            bool t = false;
            if (userInput.Equals(answers[testNum])) { t = true; } else { t = false; }

            return t;
        }

        public void EditText()
        {
            inputText_Canvas.SetActive(true);
            FreezeMovement(true);
            if (playerInputText == null)
            {
                playerInputText = GameObject.Find("PlayerInputText").GetComponent<TextMeshPro>();
            }
        }

        public void exitEdit()
        {
            inputText_Canvas.SetActive(false);
            FreezeMovement(false);
            userText.text = monitorText.text;
            MonitorAwake = false;
        }

        public void FreezeMovement(bool t)
        {
            if (t)
            {
                playerRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            }
            else
            {
                playerRigidBody.constraints = RigidbodyConstraints.None;
                playerRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }
        }

        public void SubmitText()
        {
            bool val = Result();

            if (val)
            {
                Debug.Log("Correct Answer");
                nextQuestion();
                score += 250;
            }
            else
            {
                Debug.Log("Wrong Answer!");
                score -= 50;
            }
        }

        public void SkipQuestion()
        {
            nextQuestion();
            score -= 50;
        }

        public void nextQuestion()
        {
            if (currLevel < 4)
            {
                currLevel++;
                QuestionController(currLevel);
            }
        }

        public void QuestionController(int q)
        {
            switch(q)
            {
                case 0:
                    textChanger.text = answers[0];
                    monitorText.text = questions[0];
                    userText.text = monitorText.text;
                    break;
                case 1:
                    textChanger.text = answers[1];
                    monitorText.text = questions[1];
                    userText.text = monitorText.text;
                    break;
                case 2:
                    textChanger.text = answers[2];
                    monitorText.text = questions[2];
                    userText.text = monitorText.text;
                    break;
                case 3:
                    FinshGame();
                    break;
                default:
                    break;
            }
        }

        public void ResetText()
        {
            QuestionController(currLevel);
        }

        public void FinshGame()
        {
            if (score > 0) { score = 0; }
            var currentMoney = PlayerPrefs.GetInt("money");
            var script = GameObject.Find("Player").GetComponent<WinScript>();
            PlayerPrefs.SetInt("money", currentMoney + score);
            script.enabled = true;
            enabled = false;
        }
        #endregion 
    }
}