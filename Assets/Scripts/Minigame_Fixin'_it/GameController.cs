using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace gameController
{
    public class GameController : MonoBehaviour
    {
        #region Variables
        List<String> questions = new List<string>();
        TextMeshPro textChanger;
        List<String> test = new List<string>();
        #endregion

        #region Core Functions
        void Start()
        {
            //populate questions list (3 questions)
            questions.Add(
                "Instructions: Return a list of integers from 1 to 10\n" + 
                "\n" +
                "public List<int> generateList()\n" +
                "{\n" +
                "   List<int> intList = new List<int>();\n" +
                "   //HINT: Use a for loop to generate a set number of integers\n" +
                "       //Add to the integer list object\n" +
                "}\n"
                );
            questions.Add(
                ""
                );

            test.Add("1");
            test.Add("2");
            test.Add("3");
            test.Add("4");
            test.Add("5");
            test.Add("6");

            textChanger = GameObject.Find("GameText").GetComponent<TextMeshPro>();
            textChanger.text = questions[0];


            //Test functions here
            generateList();
            concat(test);
        }
        #endregion

        #region Test Functions
        //Generate a list of ints from 1-10
        public List<int> generateList()
        {
            List<int> intList = new List<int>();
            for(int i = 0; i < 10; i++)
            {
                intList.Add(i+1);
                Debug.Log(intList[i]);
            }
            return intList;
        }

        //Concatate a list of strings in reverse (HINT Add ", " to the end of each addition to the string)
        public string concat(List<string> strings)
        {
            string final = "";
            int listSize = strings.Count-1;
            for(int i = listSize; i >= 0; i--)
            {
                final += strings[i] + ", ";
            }
            final = final.Remove(final.Length - 2);
            Debug.Log(final);
            return final;
        }

        //Math questions or somein' goes ere'

        //Make radius equal 695,700 KM

        //HINT(Dont forget to use Math functions such as Math.PI to use pi or Math.E for Eulers number to calcualte special numbers)
        //HINT(Dont be afraid to look up the formula for volume of a sphere)
        public float volumeOfTheSun(float radius)
        {
            float final;
            final = (float)((4 / 3) * Math.PI * Mathf.Pow(radius, 3));

            return final;
        }

        #endregion

        #region Functions
        public void editText()
        {
            //Allow player to edit the object text here
        }

        public void submitText()
        {
            //Submit after editing is done to confirm functionality (unit test?)
        }

        public void skipQuestion()
        {
            //Skip question and deduct points
            //Use another function in here so its DRY
        }

        public void changeText(int num)
        {
            //Make sure to add \n to every time the user presses enter if possible
        }

        public void correct()
        {

        }

        public void incorrect()
        {

        }
        #endregion 
    }
}