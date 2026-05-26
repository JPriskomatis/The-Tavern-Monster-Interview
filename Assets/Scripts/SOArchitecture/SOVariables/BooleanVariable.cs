using UnityEngine;

[CreateAssetMenu(fileName = "BooleanVariable", menuName = "GameVariables/BooleanVariable")]
public class BooleanVariable : ScriptableObject
{
    public bool InitialValue;
    public bool Value;

    private void OnEnable()
    {
        Value = InitialValue;
    }
}
