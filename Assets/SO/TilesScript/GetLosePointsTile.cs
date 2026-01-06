
using Managers;
using UnityEngine;
[CreateAssetMenu(menuName = "Tiles/GetLosePointsTile")]
public class GetLosePointsTile:UniqueTile
{
    public override void SetEffect()
    {
        int point = Random.Range(-10, 10)*10;
        Debug.Log($"point grant: {point}");
        ResultManager.Players[Select.SelectedCharacterObject.playerId].Score += point;
        //point 실행하는 이벤트 발행
    }
}
