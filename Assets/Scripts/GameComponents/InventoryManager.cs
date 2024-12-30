using System.Collections;
using System.Collections.Generic;
using BingoObjects;
using Comparer;
using Structure;
using UnityEngine;
using Util;

namespace GameComponents {
    
    [System.Serializable]
    public class InventoryManager : IGameComponent {

        public GameObject panel;

        private List<BingoEntity> bingoEntities;
        
        private bool isOpen = false;


        public void InitComponent() {
            bingoEntities = new List<BingoEntity>();
            
            CreateStarterTokens();
        }

        public void OpenClose() {
            OpenClose(!isOpen);
        }

        public void OpenClose(bool isOpen, bool moveInstantly = false) {
            Vector3 startPos = panel.transform.position;
            Vector3 endPos = isOpen ? Constants.InventoryOpenPosition : Constants.InventoryClosedPosition;
            Coroutines.MoveGameobject(panel, startPos, endPos, moveInstantly ? 0 : 0.25f); // TODO: Cambiar duracion por velocidad, y que este dependa del valor seleccionado el usuario en ajustes
            this.isOpen = isOpen;
        }

        public void AddTokenToInventory() {
            // TODO: Hacer
        }

        private void SortInventory() {
            // TODO: ORDENAR AUNQUE ESTÉ CERRADO
            bingoEntities.Sort(new BingoEntityComparer());
            
            Vector2 constraints = Constants.InventoryListConstraints;
            Vector2 initial = Constants.InventoryListInitialPosition;
            Vector2 position = Constants.InventoryListDifPos;
            
            float openedPosition = isOpen ? 0 : Constants.InventoryClosedPosition.y;
            
            int i = 0;

            for (int y = 0; y < constraints.y; y++) {
                for (int x = 0; x < constraints.x; x++) {
                    Vector3 endPos = new Vector3(
                        initial.x + x * position.x, initial.y - y * position.y + openedPosition, 0);

                    BingoEntity fichaBingo = bingoEntities[i];
                    Coroutines.MoveGameobject(fichaBingo.gameObject, fichaBingo.transform.position, endPos, 0.25f);
                    
                    i++;
                    if (i >= bingoEntities.Count) {
                        break; // TODO: Mejorable esto
                    }
                }
            }
        }

        private void CreateStarterTokens() {
            // TODO: Crea las primeras 10 fichas en el inventario. Mejora el sistema
            ClearPanel();

            OpenClose(true, true);
            
            CreateNewTokenAndIncludeIntoInventory("1", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("5", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("3", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("4", 10, 0);
            CreateNewTokenAndIncludeIntoInventory("2", 10, 0);
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
        }

        // TODO: Metodo de prueba. El real no tendría que venir aquí
        private BingoToken CreateNewTokenAndIncludeIntoInventory(string number, int score, int multi) {
            // TODO: Mejorar esto, ya que es un comportamiento que se usará en inventario + tienda + Algunos items podrá crear otros items
            
            GameObject bingoNumber = GameObjectUtils.InstantiatePrefab(Constants.InventoryListName, 
                "Ficha #"+number, Constants.InventoryListInitialPosition, panel.transform);
            BingoToken @object = bingoNumber.GetComponent<BingoToken>();

            @object.Init(number, score, multi);
                
            bingoEntities.Add(@object);
            return @object;
        }
    
        private void ClearPanel() {
            foreach (Transform child in panel.transform) {
                if (child.name != Constants.InventoryBoxName)
                    GameObjectUtils.DestroyObject(child.gameObject);
            }
        }
    }
}
