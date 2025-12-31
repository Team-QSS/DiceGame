using System.Collections.Generic;

namespace Ladder
{
    public class LadderValue
    {
        public readonly Dictionary<int, (int move, bool up)> Value = new Dictionary<int, (int move, bool up)>()
        { //어쩌다 보니 하드코딩
            {5, (15, true)},
            {11, (29, true)},
            {13, (6, false)},
            {38, (21, false)},
        };
    }
}
