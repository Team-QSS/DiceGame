using UnityEngine;

public enum BoardEventType
{
    Score,
    Move,
    Reset
}

[CreateAssetMenu(fileName = "EventData", menuName = "Board/Event Data")]
public class BoardEventData : ScriptableObject
{
    public BoardEventType eventType;

    [Header("공용")]
    public float weight = 1f;

    [Header("Score Event")]
    public int scoreValue;

    [Header("Move Event")]
    public int moveDelta;

    [Header("Reset Event")]
    public int startTileIndex;
}