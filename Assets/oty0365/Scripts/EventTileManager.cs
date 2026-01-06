using System.Collections.Generic;
using UnityEngine;

public class EventTileManager : SceneSingletonMonoBehavior<EventTileManager>
{
    [SerializeField] private Tiles tiles;
    private Dictionary<string, UniqueTile> _tilesDict;
    //초기화 작업 더 유연한 발동을 위해서 딕셔너리에 저장 구조는{타일 이름, 타일}임
    void Start()
    {
        _tilesDict = new Dictionary<string, UniqueTile>();
        foreach (var t in tiles.uniqueTiles)
        {
            _tilesDict.Add(t.tileName, t);
        }
    }

    public void SetEffect(string code)
    {
        _tilesDict[code].SetEffect();
    }

    public void RandomTiles()
    {
        int idx=Random.Range(0, _tilesDict.Count);
        tiles.uniqueTiles[idx].SetEffect();
    }
}
