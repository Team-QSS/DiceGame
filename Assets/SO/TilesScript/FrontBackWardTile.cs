
using UnityEngine;
[CreateAssetMenu(menuName = "Tiles/FrontBackWardTile")]
public class FrontBackWardTile:UniqueTile
{
    public override void SetEffect()
    {
        int modIdx = Random.Range(-6, 7);
        Debug.Log($"moved: {modIdx}");
        Select.SelectedCharacterObject.playerMove(modIdx);
        EventBus.Publish(new PlayerMoveRequestEvent(modIdx));
        //대충 이런식으로
    }
}
