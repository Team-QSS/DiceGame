namespace Ladder
{
    public class LadderCalculator
    {
        private LadderValue _ladderValue;

        public LadderCalculator(LadderValue ladderDict)
        {
            _ladderValue = ladderDict;
        }
        public int CalculateLadder(int number)
        {
            foreach (var (a,(value, move)) in _ladderValue.Value)
            {
                if (number == a)
                {
                    return value;
                }
            }
            return number;
        }
    }
}
