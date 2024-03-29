﻿using System;
using UnityEngine;

namespace Sources.CharacterSources {
    public class Character : MonoBehaviour {

        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _speedDecreaseFactor;
        [SerializeField] private CharacterModel _characterModel;

        private float _speed;
        
        // TODO: TAKE THE CONSTANTS OUTSIDE
        private const float LEFT = -180;
        private const float UP = -90;
        private const float RIGHT = 0;
        private const float DOWN = -270;

        private Character() {
        }

        private void Start() {
            _speed = 0;
        }

        private void Move() {
            // TODO CHANGE MOVEMENT BY CREATING AND USING TILES
            transform.Translate(Vector3.up * (_speed));
        }

        private void DecreaseSpeed() {
            if (_speed > 0.0) {
                _speed -= _speed * _speedDecreaseFactor;
            }
        }

        private void Update() {
            _characterModel.UpdatePosition(transform.position);
            Move();
            DecreaseSpeed();
        }

        public void PrepareJump() {
            _characterModel.StartSqueeze();
        }
        
        public void JumpForward() {
            _speed = _maxSpeed;
            _characterModel.EndSqueeze();
            _characterModel.StartJump();
        }
        
        private void Rotate(float value) {
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, value, transform.eulerAngles.z));
            _characterModel.SetDirectionMesh(value);
        }
        
        
        public void RotateLeft() {
            Rotate(LEFT);
        }
        
        public void RotateRight() {
            Rotate(RIGHT);
        }

        public void RotateDown() {
            Rotate(DOWN);
        }

        public void RotateUp() {
            Rotate(UP);
        }
    }
}