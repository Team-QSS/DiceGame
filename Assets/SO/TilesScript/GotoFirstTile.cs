
using UnityEngine;
[CreateAssetMenu(menuName = "Tiles/GotoFirstTile")]
public class GotoFirstTile:UniqueTile
{
    public override void SetEffect()
    {
        Select.SelectedCharacterObject.playerLadderMove(1);
    }
}
