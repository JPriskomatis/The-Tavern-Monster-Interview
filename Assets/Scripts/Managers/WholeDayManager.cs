using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DayManager", menuName = "World/DayManager")]
public class WholeDayManager : ScriptableObject
{
    //Current Day
    public IntVariable CurrentDay;

    [Space(10)]
    [Header("Monsters")]
    //All Monsters
    public MonsterSO[] TotalMonsters;
    //Monsters for today;
    public List<MonsterSO> TodaysMonsters;

    [Space(10)]
    [Header("NPCs")]
    //NPCs for today;
    public NpcSO[] TotalNpcs;
    //Customers for today;
    public List<NpcSO> TodaysNPCs;

    [Space(10)]
    [Header("Force Day")]

    public BooleanVariable ForceDay;
    public List<NpcSO> ForcedNPCs;
    public List<MonsterSO> ForcedMonsters;

}
