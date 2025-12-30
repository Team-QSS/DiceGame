using System.Collections.Generic;
using Resources.Space;
using UnityEngine;

public class RandomEventTable
{
    private List<EventEntry> events = new List<EventEntry>();

    public void Add(IEvent ev, float weight)
    {
        events.Add(new EventEntry
        {
            Event = ev,
            Weight = weight
        });
    }

    public IEvent Pick()
    {
        float total = 0f;
        foreach (var e in events)
            total += e.Weight;

        float roll = Random.value * total;
        float acc = 0f;

        foreach (var e in events)
        {
            acc += e.Weight;
            if (roll <= acc)
                return e.Event;
        }

        return null;
    }
}