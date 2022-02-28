using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameController
{
    public class Submit : MonoBehaviour
    {
        bool active = false;
        GameController gameController;

        private void Awake()
        {
            gameController = GameObject.Find("Game").GetComponent<GameController>();
        }
        private void Update()
        {
            if (Input.GetKeyDown("space") && active)
            {
                gameController.submitText();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            active = true;
        }

        private void OnTriggerExit(Collider other)
        {
            active = false;
        }
    }
}