
using UnityEngine;

public class FrontBackWardTile:UniqueTile
{
    public override void SetEffect()
    {
        int modIdx = Random.Range(-6, 7);
        EventBus.Publish(new PlayerMoveRequestEvent(modIdx));
        //대충 이런식으로
    }
}
