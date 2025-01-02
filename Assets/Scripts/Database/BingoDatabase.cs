using System.Collections.Generic;
using UnityEngine;

namespace Database {
    
    [CreateAssetMenu(fileName = "Nueva Base de Datos", menuName = "Database/DatabaseFile")]
    public class BingoDatabase : ScriptableObject {

        public List<TokenTemplate> tokenTemplate;
        
        // TODO: Incluir el resto de Templates

    }
}