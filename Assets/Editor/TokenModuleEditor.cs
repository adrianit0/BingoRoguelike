using Database;
using Enums;
using UnityEditor;
using UnityEngine;

namespace Editor {
    public class TokenModuleEditor : IModulo {

        private int _id;

        private MainEditor _mainEditor;

        public TokenModuleEditor(MainEditor mainEditor) {
            this._mainEditor = mainEditor;
        }

        public void OnList(BingoDatabase database) {
            if (!database) {
                _id = 0;
                return;
            }
            _id = EditorUtils.ShowButtonList(ref database.tokenTemplate, _id, this, database);
        }

        public void OnBody(BingoDatabase database) {
            
            EditorGUILayout.HelpBox("Hay que programar el Editor para que sea usable", MessageType.Warning);
            
            if(!database) {
                EditorGUILayout.HelpBox("No hay Base de datos para hacer funcionar este modulo.", MessageType.Warning);
                return;
            }
            if(_id >= database.tokenTemplate.Count) {
                EditorGUILayout.HelpBox("El id es superior al valor real, seleccione otro valor.", MessageType.Warning);
                return;
            }

            TokenTemplate info = database.tokenTemplate[_id];
            
            info.tier = (TierEnum) EditorGUILayout.EnumPopup("Tier: ", info.tier);
            
            info.name = EditorGUILayout.TextField("Name", info.name);
            info.description = EditorGUILayout.TextField("Descripción: ", info.description);

            info.storePrice = EditorGUILayout.IntSlider("Precio: ", info.storePrice, 0, 15);
            

            info.prefab = (GameObject) EditorGUILayout.ObjectField("Prefab", info.prefab, typeof(GameObject), false);
            if(!info.prefab)
                EditorGUILayout.HelpBox("Si no tiene prefab no tendra efecto alguno ya que utilizará el Prefab genérico.", MessageType.Info);
            
            GUILayout.Space(20);
            
            info.number = EditorGUILayout.TextField("Numero: ", info.number);
        }

        public string GetName(BingoDatabase database, int i) {
            if (!database) {
                return "Vacio...";
            }

            TokenTemplate token = database.tokenTemplate[i];
            
            return string.IsNullOrEmpty(token.name) ? "Sin nombre..." : token.name; 
        }
    }
}