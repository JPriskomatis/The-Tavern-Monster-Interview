using UnityEngine;

[CreateAssetMenu(fileName = "NpcSO", menuName = "NPC/NpcSO")]
public class NpcSO : ScriptableObject
{
    [Header("Identity")]
    public string npcName;
    public NpcType npcType;
    public GameObject npcObject;

    [Header("Progression")]
    public int minDay = 1;

    [Range(0f, 1f)]
    public float spawnWeight = 1f;

    [Range(0, 10)]
    public int tension;

    [Header("Relationships")]
    public NpcRelations relations = new NpcRelations();

    private void OnEnable()
    {
        tension = 1;
    }
}
