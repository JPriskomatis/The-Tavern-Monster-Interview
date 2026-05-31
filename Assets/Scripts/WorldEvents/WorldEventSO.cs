using UnityEngine;

[CreateAssetMenu(fileName = "WorldEvent", menuName = "World/Event")]
public class WorldEventSO : ScriptableObject
{
    public string eventId;

    [Header("Newspaper Data")]
    [TextArea] public string title;
    [TextArea] public string description;
}
