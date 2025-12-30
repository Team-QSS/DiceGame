using UnityEngine;
using System.Collections.Generic;

public class LadderValue
{
    public readonly Dictionary<int, (int move, bool up)> Value = new Dictionary<int, (int move, bool up)>()
    { //어쩌다 보니 하드코딩
        {5, (12, true)},
        {3, (6, true)},
        {13, (6, false)},
        {17, (9, false)},
    };
}
