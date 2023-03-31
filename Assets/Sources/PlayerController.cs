using System;
using Sources.CharacterSources;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources {
    public class PlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        [SerializeField] private Character _character;
        
        private bool _isForwardJump;
        
        
        

        public void OnBeginDrag(PointerEventData eventData) {
            _isForwardJump = false;
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
                _character.RotateRight();
            } else {
                _character.RotateLeft();
            }
        }
        
        private void RotateCharacterVertical(PointerEventData eventData) {
            if (eventData.delta.y > 0) {
                _character.RotateUp();
            } else {
                _character.RotateDown();
            }
        }
        
        private void CatchTouch() {
            if (Input.GetMouseButtonDown(0)) {
                _isForwardJump = true;
            }
            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0)) {
                HandleTouch();
            }
        }

        private void Update() {
            CatchTouch();
        }

        private void HandleTouch() {
            if (_isForwardJump) {
                _character.RotateUp();
            }
            _character.JumpForward();
        }

    }
}
