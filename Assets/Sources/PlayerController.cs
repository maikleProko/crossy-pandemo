using System;
using Sources.CharacterSources;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources {
    public class PlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        [SerializeField] private Character _character;
        
        private bool _isImmediateForwardJump;

        

        public void OnBeginDrag(PointerEventData eventData) {
            _isImmediateForwardJump = false;
        }
        
        public void OnDrag(PointerEventData eventData) {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y)) {
                RotateCharacterHorizontal(eventData);
            }
            else {
                RotateCharacterVertical(eventData);
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            
        }

        private void RotateCharacterHorizontal(PointerEventData eventData) {
            if (eventData.delta.x > 0) {
                _character.RotateLeft();
            } else {
                _character.RotateRight();
            }
        }
        
        private void RotateCharacterVertical(PointerEventData eventData) {
            if (eventData.delta.y > 0) {
                _character.RotateDown();
            } else {
                _character.RotateUp();
            }
        }
        
        private void CatchTouch() {
            if (Input.GetMouseButtonDown(0)) {
                _isImmediateForwardJump = true;
            }
            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0)) {
                HandleTouch();
            }
        }

        private void Update() {
            CatchTouch();
        }

        private void HandleTouch() {
            if (_isImmediateForwardJump) {
                _character.RotateDown();
            }
            _character.JumpForward();
        }

    }
}
