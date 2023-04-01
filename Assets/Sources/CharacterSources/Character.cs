using System;
using UnityEngine;

namespace Sources.CharacterSources {
    public class Character : MonoBehaviour {

        [SerializeField] private float _maxSpeed;
        [SerializeField] private CharacterModel _characterModel;

        private float _speed;
        
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
            transform.Translate(Vector3.up * (Time.deltaTime * _speed));
        }

        private void DecreaseSpeed() {
            if (_speed > 0) {
                _speed --;
            }
        }

        private void Update() {
            _characterModel.transform.position = transform.position;
            Move();
            DecreaseSpeed();
        }
        
        public void JumpForward() {
            _speed = _maxSpeed;
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