using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "GameVariables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    public float InitialValue;
    public float Value;

    private void OnEnable()
    {
        Value = InitialValue;
    }

}