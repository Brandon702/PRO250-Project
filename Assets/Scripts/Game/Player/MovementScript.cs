﻿using Assets.Scripts.Game.Inventory;
using UnityEngine;

namespace Assets.Scripts.Game.Player
{
    public class MovementScript : MonoBehaviour
    {
        private Animator _animator;

        private Rigidbody _transform;

        [SerializeField]
        public AudioSource SfxSource;

        [SerializeField]
        public float Speed;

        // For RoboLightScript 
        public static bool IsMoving = false;

        private float _startingSpeed;

        private float _carrySpeed;

        // Start is called before the first frame update
        private void Start()
        {
            _animator = GetComponent<Animator>();

            _transform = GetComponent<Rigidbody>();

            _startingSpeed = Speed;

            // Carry speed 65% of basic speed
            _carrySpeed = 0.65f * _startingSpeed;
        }

        // Update is called once per frame
        private void Update()
        {
            // Stop walk animation
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
                Input.GetKeyUp(KeyCode.RightArrow))
            {
                _animator.SetBool("Move", false);

                IsMoving = false;
            }

            // Run walk animation
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) ||
                Input.GetKey(KeyCode.RightArrow))
            {
                _animator.SetBool("Move", true);

                IsMoving = true;

                if(SfxSource.isPlaying == false && IsMoving &&
                   Time.timeScale >= 1f && InventoryManager.IsInventoryOpened == false
                   && MapToggler.IsMapOpened == false)
                    SfxSource.Play();
            }
        }

        private void FixedUpdate()
        {
            if (Pickup.IsHolding)
            {
                Speed = _carrySpeed;
            }
            else
            {
                Speed = _startingSpeed;
            }

            if (InventoryManager.IsInventoryOpened == false && MapToggler.IsMapOpened == false)
            {
                // Move forward
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    _transform.AddForce(new Vector3(0, 0, 5) * Speed, ForceMode.VelocityChange);

                    if (Pickup.IsHolding == false)
                        _transform.rotation = Quaternion.LookRotation(Vector3.forward);
                }

                // Move left
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    _transform.AddForce(new Vector3(-5, 0, 0) * Speed, ForceMode.VelocityChange);

                    if (Pickup.IsHolding == false)
                        _transform.rotation = Quaternion.LookRotation(Vector3.left);
                }

                // Move back
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    _transform.AddForce(new Vector3(0, 0, -5) * Speed, ForceMode.VelocityChange);

                    if (Pickup.IsHolding == false)
                        _transform.rotation = Quaternion.LookRotation(Vector3.back);
                }

                // Move right
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    _transform.AddForce(new Vector3(5, 0, 0) * Speed, ForceMode.VelocityChange);

                    if (Pickup.IsHolding == false)
                        _transform.rotation = Quaternion.LookRotation(Vector3.right);
                }
            }
           
            // Apply little falling force
            _transform.AddForce(new Vector3(0, -2, 0) * Speed, ForceMode.VelocityChange);
        }
    }
}
