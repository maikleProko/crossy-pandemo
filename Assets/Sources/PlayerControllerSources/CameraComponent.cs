using System;
using UnityEngine;

namespace Sources.PlayerControllerSources {
    public class CameraComponent : MonoBehaviour {

        [SerializeField] private float _smoothFactor;
        
        private Transform _destination;

        private Vector3 GetVectorForMoveToDestination() {
            return (transform.position - _destination.position) * ((_smoothFactor) * (float)0.005);
        }

        private void MoveCamera() {
            transform.Translate(GetVectorForMoveToDestination());
        }
        
        private void Update() {
            MoveCamera();
        }

        public void MoveCameraToDestination(Transform destination) {
            _destination = destination;
        }
        
    }
}