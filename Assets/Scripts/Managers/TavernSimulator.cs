using System;
using System.Linq;
using UnityEngine;

public class TavernSimulator : MonoBehaviour
{
    [SerializeField] private TavernCustomers customers;
    [SerializeField] private TavernMonsters monsters;

    private enum TavernState
    {
        Safe,
        Tension,
        Chaos
    }

    public void CalculateTension()
    {

        foreach (NpcSO customer in customers.tavernCustomers)
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
        
    }
}
