using System.Collections.Generic;
using UnityEngine;

public class TodaysCustomers : MonoBehaviour
{
    [Header("NPC Pool")]
    [SerializeField] private NpcSO[] allNPCs;

    [Header("Spawn Settings")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] int customerCount;

    private List<NpcSO> tonightCustomers = new List<NpcSO>();
    private List<GameObject> spawnedCustomers = new List<GameObject>();

    [SerializeField] private Reservation[] reservations;

    private void Awake()
    {
        allNPCs = Resources.LoadAll<NpcSO>("NPCs");
    }

    public void GenerateCustomers(int currentDay)
    {
        ClearCustomers();
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
        // --- FIX 2: Deactivate all reservation objects first before mapping new ones ---
        foreach (var res in reservations)
        {
            if (res != null)
            {
                res.gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < tonightCustomers.Count; i++)
        {
            if (i >= spawnPoints.Length)
                break;

            // Stop if we have more customers than actual reservation card components assigned
            if (i >= reservations.Length)
                break;

            GameObject npcObject = Instantiate(
                tonightCustomers[i].npcObject,
                spawnPoints[i].position,
                spawnPoints[i].rotation
            );

            spawnedCustomers.Add(npcObject);

            Debug.Log("Spawning: " + tonightCustomers[i].npcName);

            // Reactivate and apply text to the specific card being used
            reservations[i].gameObject.SetActive(true);
            reservations[i].ApplyReservation(tonightCustomers[i].npcName);
        }
    }

    private void ClearCustomers()
    {
        foreach (var npc in spawnedCustomers)
        {
            if (npc != null)
            {
                Destroy(npc);
            }
        }

        spawnedCustomers.Clear();
    }
}