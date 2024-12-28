using UnityEngine;

namespace Util {
    public static class Constants {
        
        // Constantes Genéricas 
        public static readonly Vector3 OutOfScreenPosition = new Vector3(30f, 0, 0);
        
        // Lista bingo
        public const string BingoNumberListName = "BingoNumberList";
        public static readonly Vector3 BingoListInitialPosition = new Vector3(5.6f, 2.76f, 0);
        public static readonly Vector2 BingoListDifPos = new Vector2(0.4f, 0.4f);
        public static readonly Vector2 BingoListConstraints = new Vector2(8, 15);
        public const bool HorizontalOrder = false;
        
        // Lista Inventario
        public const string InventoryListName = "Ficha";
        public const string InventoryBoxName = "Box";
        public static readonly Vector3 InventoryListInitialPosition = new Vector3(-7.8f, 4.1f, 0);
        public static readonly Vector2 InventoryListDifPos = new Vector2(1.2f, 1.5f);
        public static readonly Vector2 InventoryListConstraints = new Vector2(11, 2);
        
        public static readonly Vector2 InventoryClosedPosition = new Vector3(0, 3.5f, 0);
        public static readonly Vector2 InventoryOpenPosition = Vector3.zero;
        
        // Lista Cartón
        public static readonly int[] LaneMultiplier = new[] { 0, 0, 1, 3, 5, 7, 10, 14, 20, 50, 100, 200, 500, 1000 };
        
    
        // Base name for the prefabs paths
        public const string PrefabBasePath = "Prefabs";
    }
}
