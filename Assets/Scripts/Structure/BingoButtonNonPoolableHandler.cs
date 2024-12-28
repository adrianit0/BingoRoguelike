using UnityEngine;

namespace Structure {
    public abstract class BingoButtonNonPoolableHandler : BingoObjectNonPoolable, IGameComponent, IClickableComponent {

        public SpriteRenderer Renderer;
        
        public void InitComponent() {
            /*
             * TODO: Configurar correctamente los Botones no poleables
             * Esto son los botones estáticos que habrá por la pantalla que no se crea proceduralmente.
             */
        }
    }
}