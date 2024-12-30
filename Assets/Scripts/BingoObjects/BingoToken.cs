using Enums;
using Structure;
using TMPro;
using UnityEngine;

namespace BingoObjects {
    public class BingoToken : BingoEntity {
    
        // TODO: Diferenciar entre Ficha e Item
        
        public TMP_Text numberText;
        public TMP_Text scoreText;
        public TMP_Text multiText;

        public SpriteRenderer elementRenderer;
        
        // TODO: Cada ficha de bingo tendrá 2 efectos extras con un icono: Uno arriba a la izquierda y otra a la derecha
        // Arriba a la derecha será si la ficha podrá moverse tras una sacada de bola o no. ( Pin or Free )

        // Valores importantes de cada ficha
        private string _number;
        private int _score;
        private int _multi;
        
        public void Init(string number, int score, int multi) {
            SetNumber(number);
            SetScore(score);
            SetMulti(multi);
            
            SetClickableEvents();
        }

        private void SetClickableEvents() {
            // TODO: Quitar este evento, ya que es de pruebas
            AddClickDownEvent(() => Debug.Log("Pulsado xD"));
            
            // TODO: Poner el resto de eventos clickables
        }

        public int GetNumber() {
            bool isNumber = int.TryParse(_number, out int number);

            return isNumber ? number : 999; // TODO: Mejorar esto o al menos incluirlo en una constante
        }

        private void SetNumber(string number) {
            _number = number;
            numberText.text = number;
        }

        private void SetScore(int score) {
            _score = score;
            scoreText.text = score.ToString();

            scoreText.gameObject.SetActive(score!=0);
        }

        private void SetMulti(int multi) {
            _multi = multi;
            multiText.text = multi.ToString();
            
            multiText.gameObject.SetActive(multi!=0);
        }


        public override CardType GetCardType() {
            return CardType.Token;
        }
    }
}
