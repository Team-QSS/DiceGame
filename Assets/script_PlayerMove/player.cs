using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int playerPosition = 1;
    [SerializeField] private List<Transform> platform = new List<Transform>(40);

    private void Awake()
    {
        playerPosition = 1;
    }

    public void PlayerMove(int moveCount)
    {
        StartCoroutine(PlayerMoveCoroutine(moveCount));
        playerPosition+=moveCount;
    }

    public void PlayerLadderMove(int endIndex)
    {
        StartCoroutine(PlayerLadderMoveCoroutine(endIndex));
    }

    //플래이어 보드 이동
    IEnumerator PlayerMoveCoroutine(int moveCount)
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
    }
    
    //플래이어 사다리 이동
    IEnumerator PlayerLadderMoveCoroutine(int endIndex)
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