using UnityEngine;

namespace Structure {
    public abstract class BingoButtonHandler : BingoObject, IGameComponent, IClickableComponent {

        public SpriteRenderer Renderer;
        
        public void InitComponent() {
            /*
             * TODO: Configurar correctamente los Botones poleables
             * Esto son los botones dinámicos, como los objetos de tienda, las piezas del inventario, etc.
             */
        }
    }
}