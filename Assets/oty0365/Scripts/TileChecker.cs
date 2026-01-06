using System;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour
{
    //더 유연한 코드를 위해 정확히 필요한 부분만 짰음 더 필요한 부분은 추가로 스크립트 만들어 구현 바람
    public event Action OnEventTileEntered;
    [SerializeField] private TileIndexs tileIndex;
    private HashSet<int> _tilesDict;

    //초기화 부분 효율성을 위해 Hash사용 쉬운 변경을 위해서 스크립터블 오브젝트 사용 Hash에 등록하여 초기화하는 과정
    private void Start()
    {
        _tilesDict = new HashSet<int>();
        foreach (var idx in tileIndex.transformSlots)
        {
            _tilesDict.Add(idx);
        }
    }
    
    //플레이어가 한칸 한칸 움직여서 끝에 도달했을때 혹은 그냥 맨 마지막 이동을 마쳤을때 사용 가능
    public void PlayerMoveSet(int idx)
    {
        if (_tilesDict.Contains(idx))
        {
            OnEventTileEntered?.Invoke();
        }
    }
}
