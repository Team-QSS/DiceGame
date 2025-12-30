using Resources.Space;

public static class EventFactory
{
    public static IEvent Create(EventData data)
    {
        switch (data.eventType)
        {
            case BoardEventType.Score:
                return new ScoreEvent(data.scoreValue);

            case BoardEventType.Move:
                return new MoveEvent(data.moveDelta);

            case BoardEventType.Reset:
                return new ResetEvent(data.startTileIndex);
        }

        return null;
    }
}