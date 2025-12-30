public class MoveEvent : IEvent
{
    private int delta;

    public MoveEvent(int delta)
    {
        this.delta = delta;
    }  

    public void Execute(/*PlayerStat player*/)
    {
        /*player.RequestMove(delta);*/
    }
}