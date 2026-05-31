using UnityEngine;

[CreateAssetMenu(fileName = "NpcSO", menuName = "NPC/NpcSO")]
public class NpcSO : ScriptableObject
{
    [Header("Identity")]
    public string npcName;
    public GameObject npcObject;


    [Header("Relationships")]
    public NpcRelations relations = new NpcRelations();
}
