using Enums;

namespace Structure {
    public abstract class BingoEntity : BingoButtonHandler {


        public TierEnum tier = TierEnum.Common;
        
        // TODO: Configuración de la tienda
        public bool canBeBoughtInstore = true;
        public bool canBeSoldInStore = true;
        public int storePrice = 0;  // Precio de compra
        public int sellPrice = 0;   // Precio de venta (Por defecto un 70% del precio de compra)

        public abstract CardType GetCardType();
        
        
    }
}