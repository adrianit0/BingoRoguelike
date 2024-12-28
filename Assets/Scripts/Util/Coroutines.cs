using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Util {
    public class Coroutines {

        private static bool pausado = false;

        // TODO: Esto no debería ir aquí
        public static GameObject pantallaPausa = null; // GameObject.Find(Constants.NOMBRE_MARCO_PAUSA);

        public static void mostrar(bool estado) {
            pantallaPausa.transform.position = new Vector3(estado ? 0 : -20, pantallaPausa.transform.position.y,
                pantallaPausa.transform.position.z);
        }

        public static bool PausarReanudar() {
            if (pausado)
                Reanudar();
            else
                Pausar();

            return pausado;
        }
    
        public static void Pausar() {
            pausado = true;
            mostrar(pausado);
        }

        public static void Reanudar() {
            pausado = false;
            mostrar(pausado);
        }

        public static void MoverGameobject(GameObject gameObject, Vector2 inicio, Vector2 fin, float duracion) {
            CoroutineRunner.Start(MoverDeA(gameObject, inicio, fin, duracion, 0));
        }
    
        public static IEnumerator MoverGameobjectX(GameObject gameObject, float inicio, float fin, float duracion, float tiempoRegreso) {
            IEnumerator coroutine = MoverDeA(gameObject,
                new Vector3(inicio, gameObject.transform.position.y, gameObject.transform.position.z),
                new Vector3(fin, gameObject.transform.position.y, gameObject.transform.position.z), duracion,
                tiempoRegreso);
        
            CoroutineRunner.Start(coroutine);

            return coroutine;
        }

        public static IEnumerator Esperar1Frame() {
            do {
                yield return null;
            } while (pausado);
        }

        public static IEnumerator EsperarSegundos(float segundos) {
            float tiempoTranscurrido = 0;
            while (tiempoTranscurrido < segundos) {
                tiempoTranscurrido += Time.deltaTime;
                yield return Esperar1Frame();
            }
        }

        public static void EjecutarCoroutine(IEnumerator coroutine) {
            CoroutineRunner.Start(coroutine);
        }
    
        public static void FinalizarCoroutine(IEnumerator coroutine) {
            CoroutineRunner.Stop(coroutine);
        }

        private static IEnumerator MoverDeA(GameObject gameObject, Vector3 inicio, Vector3 fin, float duracion, float tiempoRegreso) {
            Transform transform = gameObject.transform;
            float tiempoTranscurrido = 0;
        
            // Mientras el tiempo transcurrido sea menor que la duración, seguimos interpolando
            while (tiempoTranscurrido < duracion) {
                // Interpolación lineal entre la posición inicial y final
                transform.position = Vector3.Lerp(inicio, fin, tiempoTranscurrido / duracion);

                // Incrementamos el tiempo transcurrido en cada frame
                tiempoTranscurrido += Time.deltaTime;

                // Esperar hasta el siguiente frame
                yield return Esperar1Frame();
            }

            // Asegurar que el GameObject llegue exactamente a la posición final
            transform.position = fin;

            if (tiempoRegreso > 0) {
                yield return EsperarSegundos(tiempoRegreso);
                yield return MoverDeA(gameObject, fin, inicio, duracion, 0);
            }
        }
    
    }
}
