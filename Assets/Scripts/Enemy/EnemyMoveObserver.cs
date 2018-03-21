using System.Collections.Generic;

public class DetectEnemyEdgeHit
{
    public delegate void Operation();

    public enum Edge { Right, Left };

    //Event gameEvent;

    public Dictionary<Edge, List<Operation>> dictionary;

    public DetectEnemyEdgeHit(){
        dictionary = new Dictionary<Edge, List<Operation>>
        {
            { Edge.Left, new List<Operation>() },
            { Edge.Right, new List<Operation>() }
        };
    }

    public void AddEvent(Edge action, Operation operation)
    {
        if (dictionary[action] == null)
        {
            dictionary.Add(action, new List<Operation> { operation });
        }
        else
        {
            dictionary[action].Add(operation);
        }
    }

    public void EventHappens(Edge action)
    {
        if (dictionary[action].Count > 0)
        {
            dictionary[action][0]();
            dictionary[action].Clear();
        }
    }
    
}
