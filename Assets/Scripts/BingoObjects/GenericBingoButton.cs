using System;
using Structure;
using UnityEngine;
using UnityEngine.Events;

namespace BingoObjects {
    [RequireComponent(typeof(BoxCollider2D))]
    public class GenericBingoButton : BingoButtonNonPoolableHandler {

        public UnityEvent OnClickDown;
        public UnityEvent OnClickUp;
        public UnityEvent OnClickStay;
        
        public UnityEvent OnRightClickDown;
        public UnityEvent OnRightClickUp;
        public UnityEvent OnRightClickStay;
        
        public UnityEvent OnHoverDown;
        public UnityEvent OnHoverUp;
        public UnityEvent OnHoverStay;

        private bool holdStay = false;
        private bool pressedDown = false;
        private bool pressedRightDown = false;

        private void ClickDown() {
            OnClickDown?.Invoke();
        }

        private void ClickUp() {
            OnClickUp?.Invoke();
        }

        private void ClickStay() {
            OnClickStay?.Invoke();
        }

        private void RightClickDown() {
            OnRightClickDown?.Invoke();
        }

        private void RightClickUp() {
            OnRightClickUp?.Invoke();
        }

        private void RightClickStay() {
            OnRightClickStay?.Invoke();
        }

        public void OnMouseEnter() {
            holdStay = true;
            OnHoverDown?.Invoke();
        }

        public void OnMouseExit() {
            holdStay = false;
            OnHoverUp?.Invoke();
        }

        public void OnMouseOver() {
            OnHoverStay?.Invoke();
            
            if(Input.GetMouseButtonDown(0)) {
                pressedDown = true;
                ClickDown();
            } else if (pressedDown && Input.GetMouseButtonUp(0)) {
                pressedDown = false;
                ClickUp();
            } else if (Input.GetMouseButton(0)) {
                ClickStay();
            }
            
            if(Input.GetMouseButtonDown(1)) {
                pressedRightDown = true;
                RightClickDown();
            } else if (holdStay && pressedRightDown && Input.GetMouseButtonUp(1)) {
                pressedRightDown = false;
                RightClickUp();
            } else if (Input.GetMouseButton(1)) {
                RightClickStay();
            }
        }

        public void Update() {
            if (!holdStay && pressedDown && Input.GetMouseButtonUp(0)) {
                pressedDown = false;
            }
            if (!holdStay && pressedRightDown && Input.GetMouseButtonUp(1)) {
                pressedRightDown = false;
            }
        }
    }
}