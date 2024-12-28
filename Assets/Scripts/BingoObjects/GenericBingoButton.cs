using System;
using Structure;
using UnityEngine;
using UnityEngine.Events;

namespace BingoObjects {
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
            Debug.Log("ClickDown");
            OnClickDown?.Invoke();
        }

        private void ClickUp() {
            Debug.Log("ClickUp");
            OnClickUp?.Invoke();
        }

        private void ClickStay() {
            // Debug.Log("ClickStay");
            OnClickStay?.Invoke();
        }

        private void RightClickDown() {
            Debug.Log("RightClickDown");
            OnRightClickDown?.Invoke();
        }

        private void RightClickUp() {
            Debug.Log("RightClickUp");
            OnRightClickUp?.Invoke();
        }

        private void RightClickStay() {
            // Debug.Log("RightClickStay");
            OnRightClickStay?.Invoke();
        }

        public void OnMouseEnter() {
            Debug.Log("HoverEnter");
            holdStay = true;
            OnHoverDown?.Invoke();
        }

        public void OnMouseExit() {
            Debug.Log("HoverExit");
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