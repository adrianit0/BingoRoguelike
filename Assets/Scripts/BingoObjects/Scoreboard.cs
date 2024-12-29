using Structure;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace BingoObjects {
    public class Scoreboard : BingoObject {
        private int score = 0;
        private string text = "";

        public TMP_Text shadowText;
        public TMP_Text scoreText;

        public int maxNumbers;
        public bool allowExceedingLimit = false;


        public void Draw(string text) {
            scoreText.text = text;

            this.text = text;
        }

        public void DrawNumber() {
            DrawNumber(score);
        }

        public void DrawNumber(int number) {
            int numberCharacters = number.ToString().Length;
            scoreText.text = allowExceedingLimit && numberCharacters > maxNumbers
                ? shadowText.text.Replace("8", "9")
                : number.ToString();

            score = number;
            text = number.ToString();
        }

        public void Plus(int amount) {
            DrawNumber(score + amount);
        }

        public IEnumerator Plus(int amount, int timeToSpend) {
            // TODO
            yield return 0;
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

        public IEnumerator ClearScore(int timeToSpend) {
            // TODO
            yield return 0;
        }
    }
}