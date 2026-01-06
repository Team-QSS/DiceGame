using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ResultManager : MonoBehaviour
    {
        public static readonly List<Character> Players = new(new Character[] {new(0), new(1), new(2)});
        public TextMeshPro[] ranking;

        private void Start()
        {
            for (var i = 0; i < Players.Count; i++) Players[i].Text = ranking[i];
            Players.Sort((a, b) => b.Score.CompareTo(a.Score));
            for (var i = 0; i < Players.Count; i++)
            {
                var score = Players[i].Score;
                var index = i - 1;
                while (index >= 0 && score == Players[index].Score) index--;
                Players[i].Text.text = FormatText(index + 2, Players[i].Score);
            }
        }

        private static string FormatText(int rank, int score)
        {
            return $"<color=#{GetColor(rank)}>#{rank}</color>\n<size=2>Score: {score}</size>";
        }
        
        private static string GetColor(int rank)
        {
            return rank switch
            {
                1 => "FF0",
                2 => "AAA",
                3 => "933",
                _ => "FFF"
            };
        }

        public void Restart()
        {
            foreach (var character in Players) character.Score = 0;
            Players.Sort((a, b) => a.PlayerId.CompareTo(b.PlayerId));
            SceneManager.LoadScene("Map");
        }
    }

    public class Character
    {
        public int PlayerId;
        public int Score;
        public TextMeshPro Text;

        public Character(int playerId) => PlayerId = playerId;
    }
}
