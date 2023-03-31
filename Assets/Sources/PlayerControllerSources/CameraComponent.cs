using UnityEngine;

namespace Sources.PlayerControllerSources {
    public class CameraComponent : MonoBehaviour {

        [SerializeField] private float _smoothFactor;
        [SerializeField] private Transform _targetTransform;
        
        private Vector3 _differenceTransformPositionSelfTarget;
        private Vector3 _standardDifferenceTransformPositionSelfTarget;

        private CameraComponent() {
            _differenceTransformPositionSelfTarget = new Vector3(0, 0, 0);
        }

        private void Start() {
            var position = transform.position;
            var targetPosition = _targetTransform.position;
            _differenceTransformPositionSelfTarget = position - targetPosition;
            _standardDifferenceTransformPositionSelfTarget = position - targetPosition;
        }


        private Vector3 GetVectorForMoveToDestination() {
            return (_differenceTransformPositionSelfTarget - _standardDifferenceTransformPositionSelfTarget) * _smoothFactor;
        }

        private void MoveCamera() {
            UpdateDifferenceTransformPositionSelfTarget();
            transform.position -= GetVectorForMoveToDestination();
        }

        private void UpdateDifferenceTransformPositionSelfTarget() {
            _differenceTransformPositionSelfTarget = transform.position - _targetTransform.position;
        }
        
        private void Update() {
            MoveCamera();
        }

    }
}