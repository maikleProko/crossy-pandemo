using System;
using UnityEngine;

namespace Sources.CharacterSources {
    public class CharacterModel : MonoBehaviour {
        
        [SerializeField] private float _smoothFactorDirection;
        [SerializeField] private float _squeezeForJumpFactor;
        [SerializeField] private float _squeezeForJumpSpeed;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _jumpSpeed;
        
        private const float UP = -90;
        private const float DOWN = -270;
        private const double TOLERANCE = 0.00001;
        private const float DEFAULT_SIZE = (float)1.0;
        private const float DEFAULT_HEIGHT = (float)0.0;
        
        private float _direction;
        private float _squeezeDestination;
        private float _jumpDestination;

        private void Start() {
            _direction = UP;
            _squeezeDestination = DEFAULT_SIZE;
            _jumpDestination = DEFAULT_HEIGHT;
        }

        private void Update() {
            RotateSmoothToDirection();
            UpdateSqueeze();
            UpdateJump();
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

        public void StartSqueeze() {
            _squeezeDestination = _squeezeForJumpFactor;
        }
        
        private void UpdateSqueeze() {
            var scale = transform.localScale;
            var squeezeUnit = _squeezeForJumpFactor * _squeezeForJumpSpeed;
            if (Math.Abs(scale.z - _squeezeDestination) > squeezeUnit) {
                transform.localScale = new Vector3(scale.x, scale.y,
                    scale.z - Math.Sign(scale.z - _squeezeDestination) * squeezeUnit);
            }
        }

        public void EndSqueeze() {
            _squeezeDestination = DEFAULT_SIZE;
        }

        public void StartJump() {
            _jumpDestination = _jumpHeight;
        }

        private void UpdateJump() {
            var position = transform.localPosition;
            var jumpUnit = _jumpHeight * _jumpSpeed;
            if (Math.Abs(position.y - _jumpDestination) > jumpUnit) {
                transform.localPosition = new Vector3 (
                        position.x,
                        position.y - Math.Sign(position.y - _jumpDestination) * jumpUnit,
                        position.z
                    );
            } else EndJump();
        }

        private void EndJump() {
            _jumpDestination = DEFAULT_HEIGHT;
        }

        public void UpdatePosition(Vector3 position) {
            transform.position = new Vector3(
                position.x,
                transform.position.y,
                position.z
            );
        }
        
        

    }
}