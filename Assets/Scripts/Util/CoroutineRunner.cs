using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util {
    public class CoroutineRunner : MonoBehaviour {
        // Instancia única (Singleton) del CoroutineRunner
        private static CoroutineRunner _instance;
        
        // Almacenará 
        private static Dictionary<GameObject, Coroutine> _activeCoroutines = new Dictionary<GameObject, Coroutine>();

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
        public static void Stop(Coroutine coroutine) {
            Instance.StopCoroutine(coroutine);
        }
        
        public static Coroutine StartManagedCoroutine(GameObject target, IEnumerator routine) {
            // Si ya existe una corutina para este GameObject, detén la actual
            if (_activeCoroutines.TryGetValue(target, out Coroutine currentCoroutine)) {
                Stop(currentCoroutine);
                _activeCoroutines.Remove(target);
            }

            // Inicia la nueva corutina y almacénala en el diccionario
            Coroutine newCoroutine = Start(ExecuteCoroutine(target, routine));
            _activeCoroutines[target] = newCoroutine;
            return newCoroutine;
        }

        // Método para detener coroutines desde cualquier clase
        public static void Stop(IEnumerator routine) {
            Instance.StopCoroutine(routine);
        }
        
        private static IEnumerator ExecuteCoroutine(GameObject target, IEnumerator routine) {
            yield return Start(routine);

            // Elimina la corutina del diccionario al terminar
            _activeCoroutines.Remove(target);
        }
    
    }
}