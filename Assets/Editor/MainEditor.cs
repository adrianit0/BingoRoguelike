using System.Collections.Generic;
using Database;
using UnityEditor;
using UnityEngine;

namespace Editor {
    public class MainEditor : EditorWindow {
        private Vector2 _scrollPositionBarra;
        private Vector2 _scrollPositionContent;
        
        private BingoDatabase database;

        private TokenModuleEditor tokenModuleEditor;

        IModulo modulo;

        public BingoDatabase GetBingoDatabase() {
            return database;
        }

        [MenuItem("Bingo/Editor", false, 140)]
        private static void Init() {
            MainEditor window = (MainEditor) EditorWindow.GetWindow(typeof(MainEditor));

            window.titleContent = new GUIContent("Editor Principal del juego del Bingo");
            window.position = new Rect(0, 20, 1200, 600);
            window.Crear();

            window.Show();
        }

        private void Crear() {
            minSize = new Vector2(800, 400);
            
            tokenModuleEditor = new TokenModuleEditor(this);
        }
        
        private void CreateNewDatabase() {
            database = ScriptableObject.CreateInstance<BingoDatabase>();
            database.tokenTemplate = new List<TokenTemplate>();
            SaveDatabase();
        }
        
        private void SaveDatabase() {
            string path = EditorUtility.SaveFilePanelInProject("Guardar Base de Datos", "NewDatabase", "asset", "Save your database");
            if (!string.IsNullOrEmpty(path)) {
                AssetDatabase.CreateAsset(database, path);
                AssetDatabase.SaveAssets();
            }
        }

        private bool PedirManager() {
            if (!database) {
                EditorGUILayout.HelpBox("Hace falta un Base de Datos  para hacer funcionar este plugin y así poder editar las funciones del Bingo.", MessageType.Info);
                EditorGUILayout.HelpBox("No se ha encontrado la Base de Datos, insertalo aquí:", MessageType.Warning);
                
                GUILayout.Space(20);
                
                database = (BingoDatabase) EditorGUILayout.ObjectField(
                    "Cargar Base de Datos", database, typeof(BingoDatabase), false, 
                    GUILayout.MinWidth(50), GUILayout.MaxWidth(300));
                
                GUILayout.Space(20);
                
                EditorGUILayout.HelpBox("Si no tienes ninguno puedes crear uno aqui:", MessageType.Info);
                
                GUILayout.Space(20);
                
                if (GUILayout.Button("Crear Nueva Base de Datos", GUILayout.MinWidth(20), GUILayout.MaxWidth(200))) {
                    CreateNewDatabase();
                }
                return false;
            }
            return true;
        }

        void OnGUI() {
            if (!PedirManager ()) {
                return;
            }

            GUILayout.BeginHorizontal("box", GUILayout.ExpandWidth(true), GUILayout.Height(50));
            
            //Zona de módulos: Incluirlos todos aquí.
            if (GUILayout.Button ("Inicio", GUILayout.Height (45), GUILayout.Width (100))) {
                modulo = null;
            }
            if(GUILayout.Button("Fichas", GUILayout.Height(45), GUILayout.Width(100))) {
                modulo = (IModulo) tokenModuleEditor;
            }
            if(GUILayout.Button("Items", GUILayout.Height(45), GUILayout.Width(100))) {
                // TODO: Programar esto
                Debug.LogWarning("Funcionalidad no programada aún");
            }
            if(GUILayout.Button("Gashas", GUILayout.Height(45), GUILayout.Width(100))) {
                // TODO: Programar esto
                Debug.LogWarning("Funcionalidad no programada aún");
            }
            if(GUILayout.Button("Pack Mejoras", GUILayout.Height(45), GUILayout.Width(100))) {
                // TODO: Programar esto
                Debug.LogWarning("Funcionalidad no programada aún");
            }
            if(GUILayout.Button("Perks", GUILayout.Height(45), GUILayout.Width(100))) {
                // TODO: Programar esto
                Debug.LogWarning("Funcionalidad no programada aún");
            }
            if(GUILayout.Button("Elementos", GUILayout.Height(45), GUILayout.Width(100))) {
                // TODO: Programar esto
                Debug.LogWarning("Funcionalidad no programada aún");
            }
            if(GUILayout.Button("Jefes", GUILayout.Height(45), GUILayout.Width(100))) {
                // TODO: Programar esto
                Debug.LogWarning("Funcionalidad no programada aún");
            }
            if(GUILayout.Button("Cartones", GUILayout.Height(45), GUILayout.Width(100))) {
                // TODO: Programar esto
                Debug.LogWarning("Funcionalidad no programada aún");
            }
            if(GUILayout.Button("Tienda", GUILayout.Height(45), GUILayout.Width(100))) {
                // TODO: Programar esto
                Debug.LogWarning("Funcionalidad no programada aún");
            }
            //Fin de zona de módulos
            
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical("box", GUILayout.Width(210), GUILayout.ExpandHeight(true));
            //Zona de la lista.
            if (modulo != null) {
                _scrollPositionBarra = GUILayout.BeginScrollView(_scrollPositionBarra, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                modulo.OnList(database);
                GUILayout.EndScrollView();
            } else {
                GUILayout.Label("Sin contenido.", EditorStyles.boldLabel);
            }
            //Fin zona de la lista.
            GUILayout.EndVertical();
            
            GUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            //La otra zona.
            if(modulo != null) {
                _scrollPositionContent = GUILayout.BeginScrollView(_scrollPositionContent, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                modulo.OnBody(database);
                GUILayout.EndScrollView();
            }
            else {
                GUILayout.Label("No se ha encontrado datos para mostrar.", EditorStyles.boldLabel);
            }
            //Fin zona de la lista.
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        
    }
}