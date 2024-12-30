using System.Collections.Generic;
using BingoObjects;
using Structure;
using UnityEngine;
using Util;

namespace GameComponents {
    
    [System.Serializable]
    public class ShopManager : IGameComponent {

        public GameObject panel;

        // TODO: Expandir a otros tipos de items en venta
        private List<FichaBingo> ventaFichas;
        
        // TODO: Descomentar o eliminar cuando se piense correctamente que hacer con esto
        // private List<FichaBingo> ventaItems;
        // private List<Gacha> ventaGacha; // TODO: Hacer que los gachas sea tambien FichaBingo por facilitar la programación?
        
        // TODO: Mejorar el sistema. A lo mejor solo se necesita 1 lista en lugar de varios y ordenar en la tienda según el tipo de objeto que se venda?

        private bool isOpen = false;

        public void InitComponent() {
            ventaFichas = new List<FichaBingo>();
            
            // CreateStarterTokens();
        }
        
        public void OpenClose() {
            Vector3 startPos = panel.transform.position;
            Vector3 endPos = isOpen ? Constants.ShopClosedPosition : Constants.ShopOpenPosition;
            Coroutines.MoveGameobject(panel, startPos, endPos, 0.25f); // TODO: Cambiar duracion por velocidad, y que este dependa del valor seleccionado el usuario en ajustes
            isOpen = !isOpen;
        }

        private void SortShop() {
            // TODO: ORDENAR AUNQUE ESTÉ CERRADO
            // TODO: Ordenar por precio
            Vector2 constraints = Constants.InventoryListConstraints; // Crear constantes para el orden de la tienda
            Vector2 initial = Constants.InventoryListInitialPosition;
            Vector2 position = Constants.InventoryListDifPos;
            
            // TODO: Ordenarlo
        }

        private void CreateStarterTokens() {
            ClearPanel();

            panel.transform.position = Constants.InventoryOpenPosition;
            
            CreateNewTokenAndIncludeIntoShop("1", 10, 0, 2);
            CreateNewTokenAndIncludeIntoShop("2", 10, 0, 2);
            CreateNewTokenAndIncludeIntoShop("3", 10, 0, 2);
            
            SortShop();
            
            panel.transform.position = Constants.InventoryClosedPosition;
        }

        private FichaBingo CreateNewTokenAndIncludeIntoShop(string number, int score, int multi, int price) {
            // TODO: Mejorar esto, ya que es un comportamiento que se usará en inventario + tienda + Algunos items podrá crear otros items
            
            GameObject bingoNumber = GameObjectUtils.InstantiatePrefab(Constants.InventoryListName, 
                "Ficha #"+number, Constants.OutOfScreenPosition, panel.transform);
            FichaBingo fichaObject = bingoNumber.GetComponent<FichaBingo>();

            fichaObject.SetNumber(number);
            fichaObject.SetScore(score);
            fichaObject.SetMulti(multi);
            // TODO: Incluir Precio
                
            ventaFichas.Add(fichaObject);
            return fichaObject;
        }
    
        private void ClearPanel() {
            // TODO: Programar esto
        }
    }
}
