using UnityEngine;

[CreateAssetMenu(fileName = "NpcSO", menuName = "NPC/NpcSO")]
public class NpcSO : ScriptableObject
{
    [Header("Identity")]
    public string npcName;
    public GameObject npcObject;


    [Header("Type")]
    public NpcType type;

    public MonsterType hostileWith;
    public MonsterType friendWith;
}
