using Sources.CharacterSources;
using Sources.PlayerControllerSources;
using UnityEngine;

namespace Sources {
    public class Level : MonoBehaviour {

        [SerializeField] private Character _character;
        [SerializeField] private CameraComponent _cameraComponent;
        
        private void Start() {
        
        }

        private void CatchTouch() {
            if (Input.GetMouseButtonDown(0)) {
                HandleTouch();
            }
        }

        private void Update() {
            CatchTouch();
        }

        private void HandleTouch() {
            _character.JumpForward();
        }

    }
}
