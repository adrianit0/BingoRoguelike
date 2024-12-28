using UnityEngine;

namespace Util {
    public class RandomUtils {
        public static float Random() {
            return UnityEngine.Random.value;
        }

        public static float Random(float finish) {
            return Random(0f, finish);
        }

        public static float Random(float start, float finish) {
            return UnityEngine.Random.Range(start, finish);
        }
    
        public static int Random(int finish) {
            return UnityEngine.Random.Range(0, finish);
        }

        public static int Random(int start, int finish) {
            return UnityEngine.Random.Range(start, finish);
        }
    }
}