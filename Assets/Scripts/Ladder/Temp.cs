using Ladder;
using UnityEngine;
using UnityEngine.InputSystem;

public class Temp : MonoBehaviour
{
    private LadderCalculator _ladderCalculator;
    private LadderValue _ladderValue;

    void Awake()
    {
        _ladderValue = new LadderValue();
        _ladderCalculator = new LadderCalculator(_ladderValue);
    }
    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            Debug.Log(_ladderCalculator.CalculateLadder(13));
        }
    }
}
