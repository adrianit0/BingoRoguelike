using System.Collections.Generic;
using BingoObjects;
using Enums;
using Structure;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace GameComponents {
    
    [System.Serializable]
    public class ScoreboardManager : IGameComponent {

        public Scoreboard scoreboardScore;
        public Scoreboard scoreboardObjetive;
        public Scoreboard scoreboardYourScore;
        public Scoreboard scoreboardLevel;
        public Scoreboard ScoreboardDraw;

        private List<Scoreboard> includesScoreboards;

        public void InitComponent() {
            includesScoreboards = new List<Scoreboard>() {
                scoreboardScore,
                scoreboardObjetive,
                scoreboardYourScore,
                scoreboardLevel,
                ScoreboardDraw
            };
        
            includesScoreboards.ForEach(sb => sb.ClearScore());
            
            // TODO: Incluir en el futuro editor de niveles
            DrawText(ScoreboardType.Objective, "1000");
            DrawText(ScoreboardType.Level, "1");
            DrawText(ScoreboardType.Draw, "10");
            DrawText(ScoreboardType.Score, "0");
        }
        
        public void DrawText(ScoreboardType marker, string text) {
            switch (marker) {
                case ScoreboardType.Score:
                    scoreboardScore.Draw(text);
                    break;

                case ScoreboardType.Objective:
                    scoreboardObjetive.Draw(text);
                    break;

                case ScoreboardType.YourScore:
                    scoreboardYourScore.Draw(text);
                    break;

                case ScoreboardType.Level:
                    scoreboardLevel.Draw(text);
                    break;

                case ScoreboardType.Draw:
                    ScoreboardDraw.Draw(text);
                    break;

                default:
                    Debug.LogWarning("Estado desconocido.");
                    break;
            }
        }
        
    }
}
