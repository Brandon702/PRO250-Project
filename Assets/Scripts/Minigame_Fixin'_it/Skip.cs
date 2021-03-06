using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameController
{
    public class Skip : MonoBehaviour
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
            if (Input.GetKeyDown("space") && active)
            {
                gameController.SkipQuestion();
            }
        }
        #endregion

        #region Triggers
        private void OnTriggerEnter(Collider other)
        {
            active = true;
        }

        private void OnTriggerExit(Collider other)
        {
            active = false;
        }

        #endregion
    }
}