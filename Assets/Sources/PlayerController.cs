using System;
using Sources.CharacterSources;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sources {
    public class PlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        [SerializeField] private Character _character;
        
        private bool _isImmediateForwardJump;

        private void Start() {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }


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
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
                _isImmediateForwardJump = true;
            }
            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) {
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
