using UnityEngine;

public class NewspaperDatabase : MonoBehaviour
{
    public GameEventDefinitionSO[] events;

    public GameEventDefinitionSO GetById(string id)
    {
        foreach (var e in events)
        {
            Debug.Log(e);
            if (e.eventId == id)
                return e;
        }

        return null;
    }
}