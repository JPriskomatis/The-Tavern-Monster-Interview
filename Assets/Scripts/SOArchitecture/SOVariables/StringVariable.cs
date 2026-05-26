using UnityEngine;

[CreateAssetMenu(fileName = "StringVariable", menuName = "GameVariables/StringVariable")]
public class StringVariable : ScriptableObject
{
    public string Value;
    public string InitialValue;

    private void OnEnable()
    {
        if(InitialValue != null)
        {
            Value = InitialValue;
        }
    }
}
