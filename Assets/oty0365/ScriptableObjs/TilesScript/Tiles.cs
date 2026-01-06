using UnityEngine;
//나중에 에디터로 타일 모두를 집계해서 넣는걸 가능하도록 만들것..
[CreateAssetMenu(fileName = "Tiles", menuName = "Scriptable Objects/Tiles")]
public class Tiles : ScriptableObject
{
    public UniqueTile[] uniqueTiles;
}
