using System;
using System.Linq;
using UnityEngine;

public class TavernSimulator : MonoBehaviour
{
    [SerializeField] private TavernMonsters monsters;
    [SerializeField] public WholeDayManager WholeDayManager;

    public StringVariable TonightsOutcome;


    private enum TavernState
    {
        Safe,
        Tension,
        Chaos
    }

    public void CalculateTension()
    {

        foreach (NpcSO customer in WholeDayManager.TodaysNPCs)
        {
            customer.tension = 0;

            foreach(MonsterSO monster in monsters.acceptedMonsters)
            {
                if (customer.relations.hostile.Contains(monster.monsterType))
                {
                    customer.tension += 3;
                    Debug.Log("Customers tension increased...");
                }
            }
            Debug.Log(customer.npcName + " tension: " + customer.tension);
        }

        int overallTension = 0;
        foreach (NpcSO npc in WholeDayManager.TodaysNPCs)
        {
            overallTension = overallTension + npc.tension;
        }

        TonightsOutcome.Value = "Your tension is "+ overallTension.ToString();


    }
}
