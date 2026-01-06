
using UnityEngine;
[CreateAssetMenu(menuName = "Tiles/GetLosePointsTile")]
public class GetLosePointsTile:UniqueTile
{
    public override void SetEffect()
    {
        int point = Random.Range(-10, 10)*10;
        //point 실행하는 이벤트 발행
    }
}
