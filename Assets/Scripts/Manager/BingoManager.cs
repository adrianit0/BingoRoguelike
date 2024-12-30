using System.Collections.Generic;
using GameComponents;
using Structure;
using UnityEngine;
using UnityEngine.Serialization;
using Util;

namespace Manager {
    public class BingoManager : MonoBehaviour {

        public InventoryList inventoryList;
        public ShopList shopList;
        public BingoList bingoList;
        public ScoreboardList scoreboardList;
    
        private List<IGameComponent> _includesBingo;
    
        void Start(){
            _includesBingo = new List<IGameComponent>() {
                // Lista de todos los Componentes, para ejecutarse de una sola vez.
                // Poner en orden ya que siempre se ejecutará en ese ordén
                inventoryList,
                shopList,
                bingoList,
                scoreboardList
            };
        
        
            // Inicializamos todos los componentes
            _includesBingo.ForEach(gc => gc.InitComponent());
        }

        void Update() {
            // TODO: Algo habrá que poner aquí...
        }

        public void OpenCloseInventory() {
            inventoryList.OpenClose();
        }

        public void OpenCloseShop() {
            shopList.OpenClose();
        }
    }
}
