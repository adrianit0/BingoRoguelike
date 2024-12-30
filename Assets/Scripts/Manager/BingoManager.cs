using System.Collections.Generic;
using GameComponents;
using Structure;
using UnityEngine;
using UnityEngine.Serialization;
using Util;

namespace Manager {
    public class BingoManager : MonoBehaviour {

        public InventoryManager inventoryManager;
        public ShopManager shopManager;
        public BingoHistoricalManager bingoHistoricalManager;
        public ScoreboardManager scoreboardManager;
    
        private List<IGameComponent> _includesBingo;
    
        void Start(){
            _includesBingo = new List<IGameComponent>() {
                // Lista de todos los Componentes, para ejecutarse de una sola vez.
                // Poner en orden ya que siempre se ejecutará en ese ordén
                inventoryManager,
                shopManager,
                bingoHistoricalManager,
                scoreboardManager
            };
        
        
            // Inicializamos todos los componentes
            _includesBingo.ForEach(gc => gc.InitComponent());
        }

        void Update() {
            // TODO: Algo habrá que poner aquí...
        }

        public void OpenCloseInventory() {
            inventoryManager.OpenClose();
        }

        public void OpenCloseShop() {
            shopManager.OpenClose();
        }
    }
}
