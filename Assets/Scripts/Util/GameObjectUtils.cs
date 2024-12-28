using System;
using Structure;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Util {
    public class GameObjectUtils {
        private const string path = Constants.PrefabBasePath;

        public static GameObject FindObjectByName(string nombre) {
            GameObject obj = GameObject.Find(nombre);
            if (obj == null)
                throw new Exception("Objeto no encontrado: " + nombre);
            return obj;
        }

        public static GameObject InstantiatePrefab(string prefabName, string newName, Vector2 startPosition, Transform parent) {
            GameObject prefab = GameObject.Instantiate(
                Resources.Load(path + "/" + prefabName, typeof(GameObject)), parent) as GameObject;

            if (prefab == null) {
                throw new Exception("Prefab no encontrado: " + prefabName);
            }

            prefab.transform.position = startPosition;
            prefab.name = newName;
            
            BingoObject bingoObject = prefab.GetComponent<BingoObject>();
            if (bingoObject != null) {
                IncludeInPool(bingoObject);
            }
            
            return prefab;
        }
        
        public static GameObject InstantiatePrefab(string prefabName, string newName) {
            return InstantiatePrefab(prefabName, newName, Vector2.zero, null);
        }
        
        public static GameObject InstantiatePrefab(GameObject prefab, string newName, Vector2 startPosition) {
            // TODO: Implementar cuando se requiera
            throw new NotImplementedException();
        }

        public static void DestroyObject(GameObject obj, bool destroyPermanently = true) {
            // TODO: Si destroyPermanently == false entonces enviar a su pool, solo disponible si el GameObject es de tipo BingoObject
            GameObject.Destroy(obj);
        }

        public static void IncludeInPool(BingoObject obj) {
            // TODO: Crear sistema de pool
        }
    }
}