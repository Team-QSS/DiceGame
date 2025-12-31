using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ResultManager : MonoBehaviour
    {
        public static readonly List<Character> Players = new(new Character[] {new(), new(), new()});
        public TextMeshPro[] ranking;

        private void Start()
        {
            for (var i = 0; i < Players.Count; i++) Players[i].text = ranking[i];
            Players.Sort((a, b) => b.Score.CompareTo(a.Score));
            for (var i = 0; i < Players.Count; i++)
            {
                var score = Players[i].Score;
                var index = i - 1;
                while (index >= 0 && score == Players[index].Score) index--;
                Players[i].text.text = FormatText(index + 2, Players[i].Score);
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
    }

    public class Character
    {
        public int Score;
        public TextMeshPro text;
    }
}
