using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TavernCustomers", menuName = "Scriptable Objects/TavernCustomers")]
public class TavernCustomers : ScriptableObject
{
    public List<NpcSO> tavernCustomers = new List<NpcSO>();
}
