using System.Collections.Generic;
using BingoObjects;
using Structure;
using UnityEngine;
using Util;

namespace GameComponents {
    
    [System.Serializable]
    public class BingoHistoricalManager : IGameComponent {
    
        public GameObject panel;

        private List<BingoNumber> numbers;


        public void InitComponent() {
            // TODO: Editar esto en un futuro
            string[] extras = new[] { "\ud83d\udc14", "\u2764\ufe0f", "\ud83e\udd75", "\ud83d\ude31", "\ud83d\ude28", "\ud83d\udca9" };
            IncludeNumbersInBingo(90, extras);
        }

        private void IncludeNumbersInBingo(int max = 90, string[] extras = null) {
            ClearPanel();
            numbers = new List<BingoNumber>();
            Vector2 constraints = Constants.HorizontalOrder ?   
                new Vector2(Constants.BingoListConstraints.y, Constants.BingoListConstraints.x) 
                : Constants.BingoListConstraints;
            Vector2 initial = Constants.BingoListInitialPosition;
            Vector2 position = Constants.BingoListDifPos;

            int numberOfInstances = 0;
            
            
            // TODO: Esto es una chapuza, pero es para probar
            List<string> numberValuesTest = new List<string>();
            for (int i = 0; i < max; i++) {
                numberValuesTest.Add((i+1).ToString());
            }
            foreach (string extra in extras) {
                numberValuesTest.Add(extra);
            }

            for (int x = 0; x < constraints.x; x++) {
                for (int y = 0; y < constraints.y; y++) {
                    int number = (int) (y  + x * constraints.y + 1);
                    Vector3 pos = new Vector3(initial.x + x * position.x, initial.y - y * position.y, 0);

                    InstantiateBingo(numberValuesTest[numberOfInstances] , pos);

                    numberOfInstances++;

                    if (numberOfInstances >= numberValuesTest.Count) {
                        break; // TODO: Mejorable esto
                    }
                }
                if (numberOfInstances >= numberValuesTest.Count) {
                    break; // TODO: Mejorable esto
                }
            }
        }

        private BingoNumber InstantiateBingo(string number, Vector2 position) {
            GameObject bingoNumber = GameObjectUtils.InstantiatePrefab(Constants.BingoNumberListName, 
                "Number #"+number,position, panel.transform);
            BingoNumber bingoNumberObject = bingoNumber.GetComponent<BingoNumber>();
            bingoNumberObject.text.text = number;
                
            numbers.Add(bingoNumberObject);
            
            return bingoNumberObject;
        }
    
        private void ClearPanel() {
            foreach (Transform child in panel.transform) {
                GameObjectUtils.DestroyObject(child.gameObject);
            }
        }
    }
}
