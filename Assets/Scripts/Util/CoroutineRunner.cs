using System.Collections;
using UnityEngine;

namespace Util {
    public class CoroutineRunner : MonoBehaviour {
        // Instancia única (Singleton) del CoroutineRunner
        private static CoroutineRunner _instance;

        private static CoroutineRunner Instance {
            get {
                if (_instance == null) {
                    // Si no existe una instancia, crea un nuevo GameObject con el CoroutineRunner
                    GameObject go = new GameObject("CoroutineRunner");
                    _instance = go.AddComponent<CoroutineRunner>();

                    // Asegura que el objeto no se destruya al cambiar de escena
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        // Método para iniciar coroutines desde cualquier clase
        public static Coroutine Start(IEnumerator coroutine) {
            return Instance.StartCoroutine(coroutine);
        }

        // Método para detener coroutines desde cualquier clase
        public static void Stop(IEnumerator coroutine) {
            Instance.StopCoroutine(coroutine);
        }
    
    }
}