using System;
using UnityEngine;
using UnityEngine.Events;

namespace Structure {
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class BingoButtonHandler : BingoObject, IClickableComponent {

        public SpriteRenderer Renderer;
        
        // TODO: Configuración de la tienda
        public bool canBeBoughtInstore = true;
        public bool canBeSoldInStore = true;
        public int storePrice = 0;  // Precio de compra
        public int sellPrice = 0;   // Precio de venta (Por defecto un 70% del precio de compra)
        
        // Todos los eventos permitidos para ser clickados
        private Action _onClickDown;
        private Action _onClickUp;
        private Action _onClickStay;
        private Action _onRightClickDown;
        private Action _onRightClickUp;
        private Action _onRightClickStay;
        private Action _onHoverDown;
        private Action _onHoverUp;
        private Action _onHoverStay;

        private bool _holdStay = false;
        private bool _pressedDown = false;
        private bool _pressedRightDown = false;
        
        public void AddClickDownEvent(Action clickDown) {
            _onClickDown += clickDown;
        }
        public void AddClickUpEvent(Action clickUp) {
            _onClickUp += clickUp;
        }
        public void AddClickStayEvent(Action clickStay) {
            _onClickStay += clickStay;
        }
        public void AddRightClickDownEvent(Action rightClickDown) {
            _onRightClickDown += rightClickDown;
        }
        public void AddRightClickUpEvent(Action rightClickUp) {
            _onRightClickUp += rightClickUp;
        }
        public void AddRightClickStayEvent(Action rightClickStay) {
            _onRightClickStay += rightClickStay;
        }
        public void AddHoverDownEvent(Action hoverDown) {
            _onHoverDown += hoverDown;
        }
        public void AddHoverUpEvent(Action hoverUp) {
            _onHoverUp += hoverUp;
        }
        public void AddHoverStayEvent(Action hoverStay) {
            _onHoverStay += hoverStay;
        }

        private void ClickDown() {
            _onClickDown?.Invoke();
        }

        private void ClickUp() {
            _onClickUp?.Invoke();
        }

        private void ClickStay() {
            _onClickStay?.Invoke();
        }

        private void RightClickDown() {
            _onRightClickDown?.Invoke();
        }

        private void RightClickUp() {
            _onRightClickUp?.Invoke();
        }

        private void RightClickStay() {
            _onRightClickStay?.Invoke();
        }

        public void OnMouseEnter() {
            _holdStay = true;
            _onHoverDown?.Invoke();
        }

        public void OnMouseExit() {
            _holdStay = false;
            _onHoverUp?.Invoke();
        }

        public void OnMouseOver() {
            _onHoverStay?.Invoke();
            
            if(Input.GetMouseButtonDown(0)) {
                _pressedDown = true;
                ClickDown();
            } else if (_pressedDown && Input.GetMouseButtonUp(0)) {
                _pressedDown = false;
                ClickUp();
            } else if (Input.GetMouseButton(0)) {
                ClickStay();
            }
            
            if(Input.GetMouseButtonDown(1)) {
                _pressedRightDown = true;
                RightClickDown();
            } else if (_holdStay && _pressedRightDown && Input.GetMouseButtonUp(1)) {
                _pressedRightDown = false;
                RightClickUp();
            } else if (Input.GetMouseButton(1)) {
                RightClickStay();
            }
        }

        public void Update() {
            if (!_holdStay && _pressedDown && Input.GetMouseButtonUp(0)) {
                _pressedDown = false;
            }
            if (!_holdStay && _pressedRightDown && Input.GetMouseButtonUp(1)) {
                _pressedRightDown = false;
            }
        }
    }
}