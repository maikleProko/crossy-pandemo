using System;
using UnityEngine;

namespace Sources.CharacterSources {
    public class CharacterModel : MonoBehaviour {
        
        
        private const float UP = -90;
        private const float DOWN = -270;
        
        private float _direction;
        [SerializeField] private float _smoothFactorDirection;

        private void Start() {
            _direction = UP;
        }

        private void Update() {
            RotateSmoothToDirection();
        }


        private void Rotate(float value) {
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, value, transform.eulerAngles.z));
        }

        private void RotateSmoothToDirection() {
            Rotate(transform.rotation.eulerAngles.y - (transform.rotation.eulerAngles.y + _direction) * _smoothFactorDirection);
        }

        public void SetDirectionMesh(float value) {
            // TODO WORKAROUND
            switch (value) {
                case UP:
                    _direction = DOWN;
                    break;
                case DOWN:
                    _direction = UP;
                    break;
                default:
                    _direction = value;
                    break;
            }
        }
        
        
        
    }
}