using System.Collections.Generic;
using Database;
using UnityEditor;
using UnityEngine;

namespace Editor {
    public class EditorUtils {
        
        public static int ShowButtonList <T> (ref List<T> array, int selected, IModulo modulo, BingoDatabase database) where T : new() {
            float buttonListWidth = EditorConstants.ButtonListWidth;
            float buttonWidth = EditorConstants.ButtonWidth;
            
            for(int i = 0; i < array.Count; i++) {
                string nombre = modulo.GetName(database, i);
                nombre = (nombre == "") ? "Array #" + i : nombre;

                EditorGUILayout.BeginHorizontal();
                if(selected == i) {
                    GUILayout.Label(nombre, GUILayout.Width(buttonListWidth - (buttonWidth * 3)));
                } else {
                    if(GUILayout.Button(nombre, GUILayout.Width(buttonListWidth - (buttonWidth * 3)))) {
                        GUIUtility.keyboardControl = 0;
                        selected = i;
                    }
                }

                if(array.Count > 1) {
                    if(GUILayout.Button("-", GUILayout.Width(buttonWidth))) {
                        if(EditorUtility.DisplayDialog("Confirmar", "¿Deseas eliminar el elemento " + nombre + "?", "Sí", "No")) {
                            GUIUtility.keyboardControl = 0;
                            array = EditorUtils.DeleteValue(array, i);
                            selected = Mathf.Clamp(selected - 1, 0, array.Count - 1);
                        }
                    }
                }

                if(i == array.Count - 1) {
                    GUILayout.Space(buttonWidth + 4);
                } else {
                    if(GUILayout.Button("↓", GUILayout.Width(buttonWidth))) {
                        array = EditorUtils.ChangeValuePosition(array, i, i + 1);
                    }
                }
                if(i == 0) {
                    GUILayout.Space(buttonWidth);
                } else {
                    if(GUILayout.Button("↑", GUILayout.Width(buttonWidth))) {
                        array = EditorUtils.ChangeValuePosition(array, i, i - 1);
                    }
                }

                EditorGUILayout.EndHorizontal();
            }
            GUILayout.Space(5);
            if(GUILayout.Button("Crear nuevo elemento", GUILayout.Width(200)) || array.Count == 0) {
                GUIUtility.keyboardControl = 0;
                
                array = EditorUtils.NewValue(array);
                selected = array.Count - 1;
            }
            
            return selected;
        }
        
        public static List<T> NewValue<T>(List<T> list) where T : new() {
            list.Add(new T());
            return list;
        }

        public static List<T> DeleteValue<T>(List<T> list, int value) {
            if(value < 0 || value >= list.Count)
                return list;
            
            list.RemoveAt(value);

            return list;
        }

        public static List<T> CopyValue<T> (List<T> list, int value) where T:IModulo{
            if(value < 0 || value >= list.Count)
                return list;
        
            // TODO: Programar esto...

            return list;
        }

        public static List<T> ChangeValuePosition<T>(List<T> list, int value1, int value2) {
            if(value1 < 0 || value1 >= list.Count || value2 < 0 || value2 >= list.Count)
                return list;

            (list[value1], list[value2]) = (list[value2], list[value1]);
            return list;
        }
    }
}