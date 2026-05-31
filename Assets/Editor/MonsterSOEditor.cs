using UnityEditor;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[CustomEditor(typeof(MonsterSO))]
public class MonsterSOEditor : Editor
{
    private MonsterTraitSO[] allTraits;

    private void OnEnable()
    {
        allTraits = Resources.LoadAll<MonsterTraitSO>("Traits");
    }

    public override void OnInspectorGUI()
    {
        MonsterSO monster = (MonsterSO)target;

        DrawDefaultInspector();

        GUILayout.Space(10);
        GUILayout.Label("Traits Selector", EditorStyles.boldLabel);

        foreach (var trait in allTraits)
        {
            bool hasTrait = monster.monsterTraits != null &&
                            System.Array.Exists(monster.monsterTraits, t => t.Trait == trait);

            bool newValue = EditorGUILayout.ToggleLeft(trait.name, hasTrait);

            if (newValue != hasTrait)
            {
                Undo.RecordObject(monster, "Modify Traits");

                var list = new System.Collections.Generic.List<MonsterTraitValue>(
                    monster.monsterTraits ?? new MonsterTraitValue[0]
                );

                if (newValue)
                {
                    list.Add(new MonsterTraitValue
                    {
                        Trait = trait,
                        Value = 0 // default value
                    });
                }
                else
                {
                    list.RemoveAll(t => t.Trait == trait);
                }

                monster.monsterTraits = list.ToArray();

                EditorUtility.SetDirty(monster);
            }
        }
    }
}