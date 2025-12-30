namespace Resources.Space
{
    public class MoveEvent : IEvent
    {
        private int _delta;

        public MoveEvent(int delta)
        {
            this._delta = delta;
        }  

        public void Execute(/*PlayerStat piece, GameController controller*/)
        {
            /*player.RequestMove(delta);*/
        }
    }
}