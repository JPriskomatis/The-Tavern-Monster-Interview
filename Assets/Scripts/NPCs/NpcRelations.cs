using UnityEngine;

[System.Serializable]
public class NpcRelations
{
    [Header("Friendly Towards")]
    public MonsterType[] friendly;

    [Header("Hostile Towards")]
    public MonsterType[] hostile;

}