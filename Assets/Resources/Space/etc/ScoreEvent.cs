namespace Resources.Space
{
    public class ScoreEvent : IEvent
    {
        private int _value;

        public ScoreEvent(int value)
        {
            this._value = value;
        }

        //주석은 전부 임시, 연동 후 변경 예정
        public void Execute(/*PlayerStat piece, GameController controller*/)
        {
            /*player.AddScore(value);*/
        }
    }
}