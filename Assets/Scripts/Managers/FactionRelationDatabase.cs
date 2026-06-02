using UnityEngine;

[CreateAssetMenu(menuName = "Simulation/FactionRelationDatabase")]
public class FactionRelationDatabase : ScriptableObject
{
    public RelationEntry[] relations;
}