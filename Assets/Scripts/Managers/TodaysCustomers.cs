using System.Collections.Generic;
using UnityEngine;

public class TodaysCustomers : MonoBehaviour
{
    [Header("NPC Pool")]
    [SerializeField] private WholeDayManager WholeDayManager;

    [Header("NPC Count Settings")]
    [SerializeField] int maxCustomerCount;

    //private List<NpcSO> tonightCustomers = new List<NpcSO>();

    [SerializeField] private Reservation[] reservations;

    //[SerializeField] private TavernCustomers tavernCustomers;

    //private void Awake()
    //{
    //    allNPCs.TotalNpcs = Resources.LoadAll<NpcSO>("NPCs");
    //}

    public void GenerateCustomers(int currentDay)
    {
        WholeDayManager.TodaysNPCs.Clear();


        if (!WholeDayManager.ForceDay.Value)
        {
            Debug.Log("Testing");

            //Random amount of customers
            int randomCustomerCount = Random.Range(1, maxCustomerCount+1);
            

            List<NpcSO> validNPCs = new List<NpcSO>();

            // Valid NPCs for the day
            foreach (var npc in WholeDayManager.TotalNpcs)
            {
                if (currentDay < npc.minDay)
                    continue;

                validNPCs.Add(npc);
            }

            // Which NPCs to spawn based on their weight
            for (int i = 0; i < randomCustomerCount; i++)
            {
                // If we run out of unique NPCs in our pool entirely, stop rolling
                if (validNPCs.Count == 0)
                    break;

                NpcSO selectedNPC = GetWeightedRandomNPC(validNPCs);

                if (selectedNPC != null)
                {

                    WholeDayManager.TodaysNPCs.Add(selectedNPC);

                    validNPCs.Remove(selectedNPC);
                }
            }

            
        }
        else
        {
            
            foreach ( NpcSO forcedNpc in WholeDayManager.ForcedNPCs)
            {
                
                WholeDayManager.TodaysNPCs.Add(forcedNpc);
                Debug.Log("Added forcedNPCs");
            }
        }

        SpawnCustomers();

    }

    private NpcSO GetWeightedRandomNPC(List<NpcSO> npcs)
    {
        float totalWeight = 0f;

        foreach (var npc in npcs)
        {
            totalWeight += npc.spawnWeight;
        }

        float roll = Random.Range(0f, totalWeight);
        float current = 0f;

        foreach (var npc in npcs)
        {
            current += npc.spawnWeight;

            if (roll <= current)
            {
                return npc;
            }
        }

        return null;
    }

    private void SpawnCustomers()
    {
        foreach (var res in reservations)
        {
            if (res != null)
            {
                res.gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < WholeDayManager.TodaysNPCs.Count; i++)
        {

            // Stop if we have more customers than actual reservation card components assigned;
            if (i >= reservations.Length)
                break;

            Debug.Log("Spawning: " + WholeDayManager.TodaysNPCs[i].npcName);

            // Reactivate and apply text to the specific card being used;
            reservations[i].gameObject.SetActive(true);
            reservations[i].ApplyReservation(WholeDayManager.TodaysNPCs[i].npcName, WholeDayManager.TodaysNPCs[i].npcType.name);
        }
    }
}