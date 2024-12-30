using System.Collections.Generic;
using BingoObjects;
using Structure;

namespace Comparer {
    public class BingoEntityComparer : IComparer<BingoEntity> {
        public int Compare(BingoEntity x, BingoEntity y) {
            if (x == null || y == null) return 0;

            // Orden por tipo
            if (x is BingoToken && y is not BingoToken) return -1;
            if (x is not BingoToken && y is BingoToken) return 1;

            if (x is BingoItem && y is not BingoItem) return -1;
            if (x is not BingoItem && y is BingoItem) return 1;

            // Orden dentro de BingoToken por TokenValue
            if (x is BingoToken tokenX && y is BingoToken tokenY) {
                return tokenX.GetNumber().CompareTo(tokenY.GetNumber());
            }

            // Orden dentro de BingoItem por TierEnum y luego por precio
            if (x is BingoItem itemX && y is BingoItem itemY) {
                int tierComparison = itemX.tier.CompareTo(itemY.tier);
                return tierComparison != 0 ? tierComparison : itemX.storePrice.CompareTo(itemY.storePrice);
            }

            // TODO: Incluir esto si los UpgradePack puede estar en el inventario
            // Orden dentro de UpgradePack por TierEnum y luego por precio
            if (x is BingoUpgradePack packX && y is BingoUpgradePack packY) {
                int tierComparison = packX.tier.CompareTo(packY.tier);
                return tierComparison != 0 ? tierComparison : packX.storePrice.CompareTo(packY.storePrice);
            }

            return 0;
        }
    }
}