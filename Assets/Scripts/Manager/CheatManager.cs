using UnityEngine;
using Util;

namespace Manager {
    public class CheatManager : MonoBehaviour  {
        
        public BingoManager manager;
        public GameObject panel;
        private bool isOpen = false;
        
        
        public void OpenClose() {
            Vector3 startPos = panel.transform.position;
            Vector3 endPos = isOpen ? Constants.CheatClosedPosition : Constants.CheatOpenPosition;
            Coroutines.MoveGameobject(panel, startPos, endPos, 0.25f); 
            // TODO: Cambiar duracion por velocidad, y que este dependa del valor seleccionado el usuario en ajustes
            isOpen = !isOpen;
        }
        
        public void Add1Draw() {
            // TODO: Programar esto cuando el propio sistema lo permita
        }
        public void Minus1Draw() {
            // TODO: Programar esto cuando el propio sistema lo permita
        }
        public void Add1Gold() {
            // TODO: Programar esto cuando el propio sistema lo permita
        }
        public void Minus1Gold() {
            // TODO: Programar esto cuando el propio sistema lo permita
        }
        public void CreateRandomToken() {
            // TODO: Programar esto cuando el propio sistema lo permita
        }
        public void UpdateShop() {
            // TODO: Programar esto cuando el propio sistema lo permita
        }
        
    }
}