using System.Collections.Generic;

public class EnemyMoveObserver
{
    public delegate void Operation(bool value, float downSpeed);

    public enum Destionation { Right, Left };

    //Event gameEvent;

    public Dictionary<Destionation, List<Operation>> dictionary;

    public EnemyMoveObserver(){
        dictionary = new Dictionary<Destionation, List<Operation>>
        {
            { Destionation.Left, new List<Operation>() },
            { Destionation.Right, new List<Operation>() }
        };
    }

    public void AddEvent(Destionation action, Operation operation)
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

    public void EventHappens(Destionation action, bool m_Right, float downSpeed)
    {
        if (dictionary[action].Count > 0)
        {
            dictionary[action][0](m_Right, downSpeed);
            dictionary[action].Clear();
        }
    }
    
}
