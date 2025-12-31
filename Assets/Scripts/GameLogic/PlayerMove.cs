using System.Collections;
using System.Collections.Generic;
using Ladder;
using UnityEngine;

namespace GameLogic
{
    public class PlayerMove : MonoBehaviour
    {
        public int playerPosition = 1;
        private LadderCalculator _ladderCalculator;
        [SerializeField] private List<Transform> platform = new List<Transform>(40);

        private void Awake()
        {
            _ladderCalculator = new LadderCalculator(new LadderValue());
            playerPosition = 1;
        }

        public void playerMove(int moveCount)
        {
            StartCoroutine(playerMoveCoroutine(moveCount));
            playerPosition+=moveCount;
        }

        public void playerLadderMove(int endIndex)
        {
            StartCoroutine(playerLadderMoveCoroutine(endIndex));
            playerPosition = endIndex;
        }

        //플래이어 보드 이동
        IEnumerator playerMoveCoroutine(int moveCount)
        {
            int targetIndex = playerPosition - 1 + moveCount;

            for (int i = playerPosition - 1; (i < targetIndex) && (i<platform.Count-1); i++)
            {
                Transform now = platform[i];

                Vector3 start = transform.position;
                Vector3 end = new Vector3(
                    platform[i+1].position.x,
                    platform[i+1].position.y + 1f,
                    -1f
                );
            
                if (now.position.x > end.x)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (now.position.x < end.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            
                Vector3 control = (start + end) * 0.5f + Vector3.up * 1.2f;
            
                float t = 0f;
                float moveTime = 0.4f;

                while (t < 1f)
                {
                    t += Time.deltaTime / moveTime;

                    Vector3 pos =
                        Mathf.Pow(1 - t, 2) * start +
                        2 * (1 - t) * t * control +
                        Mathf.Pow(t, 2) * end;

                    transform.position = pos;
                    yield return null;
                }

                transform.position = end;

                yield return new WaitForSeconds(0.1f);
            }
            if (_ladderCalculator.CalculateLadder(playerPosition) != playerPosition)
                playerLadderMove(_ladderCalculator.CalculateLadder(playerPosition));
        }
    
        //플래이어 사다리 이동
        IEnumerator playerLadderMoveCoroutine(int endIndex)
        {
            Vector3 start = transform.position;
            Vector3 end = new Vector3(
                platform[endIndex-1].position.x,
                platform[endIndex-1].position.y + 1f,
                -1f
            );

            float t = 0f;
            float moveTime = 0.6f;

            while (t < 1f)
            {
                t += Time.deltaTime / moveTime;
                transform.position = Vector3.Lerp(start, end, t);
                yield return null;
            }

            transform.position = end;
        }
    }
}