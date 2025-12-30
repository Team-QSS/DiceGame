using Resources.Space;

public class ResetEvent : IEvent
{
    private int startTile;

    public ResetEvent(int startTile)
    {
        this.startTile = startTile;
    }

    public void Execute(/*PlayerStat player, GameController controller*/)
    {
        /*controller.MoveTo(player, startTile);*/
    }
}