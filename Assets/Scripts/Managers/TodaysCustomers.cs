using System.Collections.Generic;
using UnityEngine;

public class TodaysCustomers : MonoBehaviour
{
    [Header("NPC Pool")]
    [SerializeField] private NpcSO[] allNPCs;

    [Header("NPC Count Settings")]
    [SerializeField] int customerCount;

    private List<NpcSO> tonightCustomers = new List<NpcSO>();

    [SerializeField] private Reservation[] reservations;

    [SerializeField] private TavernCustomers tavernCustomers;
    private void Awake()
    {
        allNPCs = Resources.LoadAll<NpcSO>("NPCs");
    }

    public void GenerateCustomers(int currentDay)
    {
        tonightCustomers.Clear();

        List<NpcSO> validNPCs = new List<NpcSO>();

        // Valid NPCs for the day
        foreach (var npc in allNPCs)
        {
            if (currentDay < npc.minDay)
                continue;

            validNPCs.Add(npc);
        }

        // Which NPCs to spawn based on their weight
        for (int i = 0; i < customerCount; i++)
        {
            // If we run out of unique NPCs in our pool entirely, stop rolling
            if (validNPCs.Count == 0)
                break;

            NpcSO selectedNPC = GetWeightedRandomNPC(validNPCs);

            if (selectedNPC != null)
            {
                tonightCustomers.Add(selectedNPC);

                tavernCustomers.tavernCustomers.Add(selectedNPC);

                // --- FIX 1: Remove the selected NPC from the pool so it remains unique ---
                validNPCs.Remove(selectedNPC);
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

        for (int i = 0; i < tonightCustomers.Count; i++)
        {

            // Stop if we have more customers than actual reservation card components assigned;
            if (i >= reservations.Length)
                break;

            Debug.Log("Spawning: " + tonightCustomers[i].npcName);

            // Reactivate and apply text to the specific card being used;
            reservations[i].gameObject.SetActive(true);
            reservations[i].ApplyReservation(tonightCustomers[i].npcName, tonightCustomers[i].npcType.name);
        }
    }
}