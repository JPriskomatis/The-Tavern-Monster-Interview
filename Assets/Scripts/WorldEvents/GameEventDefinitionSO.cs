using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game/Event")]
public class GameEventDefinitionSO : ScriptableObject
{
    public string eventId;

    [Header("Newspaper Data")]
    [TextArea] public string title;
    [TextArea] public string description;
}
