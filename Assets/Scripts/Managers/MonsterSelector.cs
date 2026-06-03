using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MonsterSelector : MonoBehaviour
{
    /*
     * 1. Get all monsters
     *  2. Filter by rules (day, later reputation, events)
     *  3. Build weighted pool
     *  4. Pick random based on weight
     *  5. Return MonsterSO
     */

    [SerializeField] private Transform spawnLocation;

    List<MonsterSO> validMonsters = new List<MonsterSO>();

    public WholeDayManager WholeDayManager;

    public MonsterSO GetMonster(int day)
    {
        WholeDayManager.TodaysMonsters.Clear();
        if(!WholeDayManager.ForceDay.Value)
        {
            Debug.Log("Monsters array size: " + WholeDayManager.TotalMonsters.Length);

            //We add all the valid monsters into our list;

            foreach (var monster in WholeDayManager.TotalMonsters)
            {
                if (day < monster.minDay) continue;
                if (day > monster.maxDay) continue;

                validMonsters.Add(monster);
            }

            if (validMonsters.Count == 0)
            {
                Debug.LogWarning("No valid monsters for this day");
                return null;
            }

            float totalWeight = 0f;
            foreach (var monster in validMonsters)
            {
                totalWeight += monster.spawnWeight;
            }

            float roll = Random.Range(0f, totalWeight);

            float current = 0f;

            foreach (var monster in validMonsters)
            {
                current += monster.spawnWeight;

                if (roll <= current)
                {
                    WholeDayManager.TodaysMonsters.Add(monster);
                    return monster;
                }

            }


            return WholeDayManager.TotalMonsters[0];
        }
        else
        {
            if(WholeDayManager.ForcedMonsters.Count == 0)
            {
                Debug.LogWarning("You didn't place any forced monsters");
                return WholeDayManager.TodaysMonsters[0];
            }
            WholeDayManager.TodaysMonsters.Add(WholeDayManager.ForcedMonsters[0]);
            return WholeDayManager.TodaysMonsters[0];
        }
        
    }

    public GameObject SpawnMonster(MonsterSO monster)
    {
        return Instantiate(monster.monsterObject, spawnLocation);
    }
}