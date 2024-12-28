using System.Collections.Generic;
using GameComponents;
using Structure;
using UnityEngine;
using UnityEngine.Serialization;

namespace Manager {
    public class BingoManager : MonoBehaviour {

        public InventoryList inventoryList;
        public BingoList bingoList;
        public ScoreboardList scoreboardList;
    
        private List<IGameComponent> _includesBingo;
    
        void Start(){
            _includesBingo = new List<IGameComponent>() {
                // Lista de todos los Componentes, para ejecutarse de una sola vez.
                // Poner en orden ya que siempre se ejecutará en ese ordén
                inventoryList,
                bingoList,
                scoreboardList
            };
        
        
            // Inicializamos todos los componentes
            _includesBingo.ForEach(gc => gc.InitComponent());
        }

        void Update() {
        
        }
    }
}
