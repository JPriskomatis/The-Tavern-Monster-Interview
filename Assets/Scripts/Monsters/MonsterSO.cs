using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "MonsterData/CreepyDemon")]
public class MonsterSO : ScriptableObject
{
    public string monsterName;
    public MonsterType monsterType;
    public MonsterTraitSO[] monsterTraits;
}
