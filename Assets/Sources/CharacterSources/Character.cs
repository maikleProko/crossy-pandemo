using UnityEngine;

namespace Sources.CharacterSources {
    public class Character : MonoBehaviour {

        [SerializeField] private float _maxSpeed;

        private float _speed;

        private Character() {
            _speed = 0;
        }

        private void Move() {
            transform.Translate(-Vector3.up * (Time.deltaTime * _speed));
        }

        private void DecreaseSpeed() {
            if (_speed > 0) {
                _speed --;
            }
        }

        private void Update() {
            Move();
            DecreaseSpeed();
        }
        
        
        public void JumpForward() {
            _speed = _maxSpeed;
        }
    }
}