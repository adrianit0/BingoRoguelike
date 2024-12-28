using Structure;
using TMPro;
using UnityEngine;

namespace BingoObjects {
    public class Scoreboard : BingoObject {

        private int score = 0;
        private string text = "";
        
        public TMP_Text shadowText;
        public TMP_Text scoreText;

        public int maxNumbers;
        public bool allowExceedingLimit = false;
        
        public void DrawNumber(int number) {
            int numberCharacters = number.ToString().Length;
            scoreText.text = allowExceedingLimit && numberCharacters > maxNumbers ? 
                shadowText.text.Replace("8", "9") : number.ToString();

            score = number;
            text = number.ToString();
        }

        public void Draw(string text) {
            // TODO: Mejorar esto
            scoreText.text = text;

            score = 0;
            this.text = text;
        }

        public int GetScore() {
            return score;
        }

        public string GetText() {
            return text;
        }

        public void ClearScore() {
            DrawNumber(0);
        }

    }
}
