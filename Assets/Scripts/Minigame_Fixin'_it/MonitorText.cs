using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameController
{
    public class MonitorText : MonoBehaviour
    {
        #region Variables
        GameController gameController;
        #endregion

        #region Core Functions
        private void Awake()
        {
            gameController = GameObject.Find("Game").GetComponent<GameController>();
        }
        private void OnEnable()
        {
            if(gameController.MonitorAwake)
            {
                gameController.ResetText();
            }
        }
        #endregion
    }
}