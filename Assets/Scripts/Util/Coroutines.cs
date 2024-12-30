using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Util {
    public class Coroutines {

        private static bool _pause = false;

        // TODO: Esto no debería ir aquí...
        private static readonly GameObject PauseScreen = null; // GameObject.Find(Constants.NOMBRE_MARCO_PAUSA);
        
        // TODO: Mejorar esto
        public static void ShowPauseScreen(bool estado) {
            PauseScreen.transform.position = new Vector3(estado ? 0 : -20, PauseScreen.transform.position.y,
                PauseScreen.transform.position.z);
        }

        public static bool PausarReanudar() {
            if (_pause)
                Resume();
            else
                Pause();

            return _pause;
        }
    
        public static void Pause() {
            _pause = true;
            ShowPauseScreen(_pause);
        }

        public static void Resume() {
            _pause = false;
            ShowPauseScreen(_pause);
        }

        // TODO: Hacer un MoveGameObject que vaya por velocidad, no por tiempo
        public static void MoveGameobject(GameObject gameObject, Vector2 start, Vector2 end, float duration) {
            CoroutineRunner.StartManagedCoroutine(gameObject, MoveGameObjectAndReturn(gameObject, start, end, duration, 0));
        }
    
        public static IEnumerator MoveGameobjectX(GameObject gameObject, float inicio, float fin, float duracion) {
            IEnumerator coroutine = MoveGameObjectAndReturn(gameObject,
                new Vector3(inicio, gameObject.transform.position.y, gameObject.transform.position.z),
                new Vector3(fin, gameObject.transform.position.y, gameObject.transform.position.z), duracion,
                0);
        
            CoroutineRunner.StartManagedCoroutine(gameObject, coroutine);

            return coroutine;
        }

        public static IEnumerator Wait1Frame() {
            do {
                yield return null;
            } while (_pause);
        }

        public static IEnumerator Wait(float seconds) {
            float elapsedTime = 0;
            while (elapsedTime < seconds) {
                elapsedTime += Time.deltaTime;
                yield return Wait1Frame();
            }
        }

        public static void ExecuteCoroutine (IEnumerator coroutine) {
            CoroutineRunner.Start(coroutine);
        }
    
        public static void StopCoroutine(IEnumerator coroutine) {
            CoroutineRunner.Stop(coroutine);
        }

        private static IEnumerator MoveGameObjectAndReturn(GameObject gameObject, Vector3 start, Vector3 end, float duration, float returnTime) {
            Transform transform = gameObject.transform;
            float elapsedTime = 0;
        
            // Mientras el tiempo transcurrido sea menor que la duración, seguimos interpolando
            while (elapsedTime < duration) {
                // Interpolación lineal entre la posición inicial y final
                transform.position = Vector3.Lerp(start, end, elapsedTime / duration);

                // Incrementamos el tiempo transcurrido en cada frame
                elapsedTime += Time.deltaTime;

                // Esperar hasta el siguiente frame
                yield return Wait1Frame();
            }

            // Asegurar que el GameObject llegue exactamente a la posición final
            transform.position = end;

            if (returnTime > 0) {
                yield return Wait(returnTime);
                yield return MoveGameObjectAndReturn(gameObject, end, start, duration, 0);
            }
        }
    
    }
}
