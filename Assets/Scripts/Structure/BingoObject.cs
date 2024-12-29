using UnityEngine;

namespace Structure {
    public abstract class BingoObject : BingoObjectNonPoolable, IPoolableObject {
        
        public string poolName; // TODO: Futuro uso, para devolverlo a un pool en lugar de eliminar

    }
}