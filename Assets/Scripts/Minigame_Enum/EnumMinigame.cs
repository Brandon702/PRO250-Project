using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnumMinigame : MonoBehaviour
{
    public InputField firstInput;
    public GameObject wrongOne;
    public InputField secondInput;
    public GameObject wrongTwo;
    public InputField thirdInput;
    public GameObject wrongThree;
    public InputField fourthInput;
    public GameObject wrongFour;
    public InputField fifthInput;
    public GameObject wrongFive;

    public GameObject winScreen;

    public void Submit()
    {
        int correctLines = 0;

        if(firstInput.text != "public enum Elements")
        {
            wrongOne.SetActive(true);
        }
        else
        {
            wrongOne.SetActive(false);
            correctLines++;
        }

        if (secondInput.text != "Water")
        {
            wrongTwo.SetActive(true);
        }
        else
        {
            wrongTwo.SetActive(false);
            correctLines++;
        }

        if (thirdInput.text != "Earth")
        {
            wrongThree.SetActive(true);
        }
        else
        {
            wrongThree.SetActive(false);
            correctLines++;
        }

        if (fourthInput.text != "Fire")
        {
            wrongFour.SetActive(true);
        }
        else
        {
            wrongFour.SetActive(false);
            correctLines++;
        }

        if (fifthInput.text != "Air")
        {
            wrongFive.SetActive(true);
        }
        else
        {
            wrongFive.SetActive(false);
            correctLines++;
        }

        if(correctLines == 5)
        {
            winScreen.SetActive(true);
        }
    }
}
