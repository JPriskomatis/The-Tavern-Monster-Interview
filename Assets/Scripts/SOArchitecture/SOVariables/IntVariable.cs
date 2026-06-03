using UnityEngine;

[CreateAssetMenu(fileName = "IntVariable", menuName = "GameVariables/IntVariable")]
public class IntVariable : ScriptableObject
{
    
    public int InitialValue;
    public int Value;

    private void OnEnable()
    {
        Value = InitialValue;
    }

}

