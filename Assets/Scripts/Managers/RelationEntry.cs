using UnityEngine;

[System.Serializable]
public class RelationEntry
{
    public MonsterType monsterType;
    public NpcType npcType;

    [Range(-1f, 1f)]
    public float affinity;
}