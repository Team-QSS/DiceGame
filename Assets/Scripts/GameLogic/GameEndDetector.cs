using System;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    public class GameEndDetector : MonoBehaviour
    {
        public PlayerMove[] players;
        public int endIndex;
        private static GameEndDetector _instance;

        private void Start()
        {
            _instance = this;
        }

        public static bool CheckEnd()
        {
            return _instance.players.All(player => player.playerPosition >= _instance.endIndex);
        }
    }
}
