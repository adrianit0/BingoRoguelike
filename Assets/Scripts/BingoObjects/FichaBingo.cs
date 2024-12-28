using Structure;
using TMPro;
using UnityEngine;

namespace BingoObjects {
    public class FichaBingo : BingoObject {
    
        // TODO: Diferenciar entre Ficha e Item
        
        public TMP_Text numberText;
        public TMP_Text scoreText;
        public TMP_Text multiText;

        public SpriteRenderer elementoRenderer;
        
        // TODO: Cada ficha de bingo tendrá 2 elementos extras: Uno arriba a la izquierda y otra a la derecha
        // Arriba a la derecha será si la ficha podrá moverse tras una sacada de bola o no. ( Pin or Free )

        // Valores importantes de cada ficha
        private string _number;
        private int _score;
        private int _multi;

        public void Init(string number, int score, int multi) {
            SetNumber(number);
            SetScore(score);
            SetMulti(multi);
        }

        public void SetNumber(string number) {
            _number = number;
            numberText.text = number;
        }

        public void SetScore(int score) {
            _score = score;
            scoreText.text = score.ToString();

            scoreText.gameObject.SetActive(score!=0);
        }

        public void SetMulti(int multi) {
            _multi = multi;
            multiText.text = multi.ToString();
            
            multiText.gameObject.SetActive(multi!=0);
        }

    }
}
