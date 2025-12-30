namespace Resources.Space
{
    public class GameController
    {
        public static GameController Instance { get; } = new();

        private const int StartTile = 0;

        private ITile[] _board;

        public void SetBoard(ITile[] tiles)
        {
            _board = tiles;
        }

        /*public void EnqueueMove(PlayerStat player, int delta)
    {
        int target = player.CurrentTile + delta;
        MoveTo(player, target);
    }

    public void MoveToStart(PlayerStat player)
    {
        MoveTo(player, START_TILE);
    }

    private void MoveTo(PlayerStat player, int tileIndex)
    {
        player.SetTile(tileIndex);
        Debug.Log($"이동 완료 → {tileIndex}번 칸");

        board[tileIndex].OnEnter(player, this);
    }*/   
    }
}