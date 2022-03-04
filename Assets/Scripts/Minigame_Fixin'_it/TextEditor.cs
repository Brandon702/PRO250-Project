using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameController
{
    public class TextEditor : MonoBehaviour
    {
        #region Variables
        bool active = false;
        GameController gameController;
        #endregion

        #region Core Functions
        private void Awake()
        {
            gameController = GameObject.Find("Game").GetComponent<GameController>();
        }
        private void Update()
        {
            gameController.EditText();
        }
        #endregion
    }
}