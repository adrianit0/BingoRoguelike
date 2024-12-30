using System.Collections;
using System.Collections.Generic;
using BingoObjects;
using Structure;
using UnityEngine;
using Util;

namespace GameComponents {
    
    [System.Serializable]
    public class InventoryList : IGameComponent {

        public GameObject panel;

        private List<FichaBingo> fichas;
        
        private bool isOpen = false;


        public void InitComponent() {
            fichas = new List<FichaBingo>();
            
            CreateStarterTokens();
        }

        public void OpenClose() {
            Vector3 startPos = panel.transform.position;
            Vector3 endPos = isOpen ? Constants.InventoryClosedPosition : Constants.InventoryOpenPosition;
            Coroutines.MoveGameobject(panel, startPos, endPos, 0.25f); // TODO: Cambiar duracion por velocidad, y que este dependa del valor seleccionado el usuario en ajustes
            isOpen = !isOpen;
        }

        private void SortInventory() {
            // TODO: ORDENAR AUNQUE ESTÉ CERRADO
            // TODO: Ordena el inventario
            Vector2 constraints = Constants.InventoryListConstraints;
            Vector2 initial = Constants.InventoryListInitialPosition;
            Vector2 position = Constants.InventoryListDifPos;
            
            int i = 0;

            for (int y = 0; y < constraints.y; y++) {
                for (int x = 0; x < constraints.x; x++) {
                    Vector3 pos = new Vector3(initial.x + x * position.x, initial.y - y * position.y, 0);

                    FichaBingo fichaBingo = fichas[i];
                    fichaBingo.transform.position = pos;
                    
                    i++;
                    if (i >= fichas.Count) {
                        break; // TODO: Mejorable esto
                    }
                }
            }
        }

        private void CreateStarterTokens() {
            // TODO: Crea las primeras 10 fichas en el inventario. Mejora el sistema
            ClearPanel();

            panel.transform.position = Constants.InventoryOpenPosition;
            
            CreateNewTokenAndIncludeIntoInventory("1", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("2", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("3", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("4", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("5", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("6", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("7", 5, 1);
            CreateNewTokenAndIncludeIntoInventory("8", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("9", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("10", 10, 0);
            
            CreateNewTokenAndIncludeIntoInventory("\ud83d\udc14", 30, 1); // POLLO
            CreateNewTokenAndIncludeIntoInventory("\u2764\ufe0f", 150, 0);
            CreateNewTokenAndIncludeIntoInventory("\ud83e\udd75", 1, 50);
            CreateNewTokenAndIncludeIntoInventory("\ud83d\ude31", 10, 20);
            CreateNewTokenAndIncludeIntoInventory("\ud83d\ude28", 1000, 0);
            CreateNewTokenAndIncludeIntoInventory("\ud83d\udca9", -5, 1);
            CreateNewTokenAndIncludeIntoInventory("\ud83d\udca9", -5, 1);
            CreateNewTokenAndIncludeIntoInventory("\ud83d\udca9", -5, 1);
            CreateNewTokenAndIncludeIntoInventory("\ud83d\udca9", -5, 1);
            CreateNewTokenAndIncludeIntoInventory("\ud83d\udca9", -5, 1);
            
            SortInventory();
            
            panel.transform.position = Constants.InventoryClosedPosition;
            isOpen = false;
        }

        private FichaBingo CreateNewTokenAndIncludeIntoInventory(string number, int score, int multi) {
            // TODO: Mejorar esto, ya que es un comportamiento que se usará en inventario + tienda + Algunos items podrá crear otros items
            
            GameObject bingoNumber = GameObjectUtils.InstantiatePrefab(Constants.InventoryListName, 
                "Ficha #"+number, Constants.OutOfScreenPosition, panel.transform);
            FichaBingo fichaObject = bingoNumber.GetComponent<FichaBingo>();

            fichaObject.Init(number, score, multi);
                
            fichas.Add(fichaObject);
            return fichaObject;
        }
    
        private void ClearPanel() {
            foreach (Transform child in panel.transform) {
                if (child.name != Constants.InventoryBoxName)
                    GameObjectUtils.DestroyObject(child.gameObject);
            }
        }
    }
}
