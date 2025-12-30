public class ScoreEvent : IEvent
{
    private int value;

    public ScoreEvent(int value)
    {
        this.value = value;
    }

    //주석은 전부 임시, 연동 후 변경 예정
    public void Execute(/*PlayerStat player*/)
    {
        /*player.AddScore(value);*/
    }
}