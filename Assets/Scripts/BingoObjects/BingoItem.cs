using Enums;
using Structure;
using TMPro;
using UnityEngine;

namespace BingoObjects {
    public class BingoItem : BingoEntity {
    
        // TODO: Programar los items

        public override CardType GetCardType() {
            return CardType.Item;
        }
    }
}
