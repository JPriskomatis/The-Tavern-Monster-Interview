using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MonsterProfileUI : MonoBehaviour
{
    public MonsterContext currentMonster;

    [SerializeField] private TextMeshProUGUI monsterName;
    [SerializeField] private TextMeshProUGUI monsterType;

    [SerializeField] private TextMeshProUGUI monsterTrait;

    [Header("UI")]
    [SerializeField] private Transform traitContainer;
    [SerializeField] private GameObject traitPrefab;

    private List<TMP_Text> spawnedTraits = new List<TMP_Text>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SetMonsterProfile(currentMonster.monster);
    }

    public void SetMonsterProfile(MonsterSO monster)
    {
        ClearTraits();

        monsterName.text = currentMonster.monster.monsterName;
        monsterType.text = currentMonster.monster.monsterType.name;

        foreach (var trait in monster.monsterTraits)
        {
            Debug.Log("Spawning trait: " + trait.name);
            GameObject textPrefab = Instantiate(traitPrefab, traitContainer);
            TextMeshProUGUI text = textPrefab.GetComponentInChildren<TextMeshProUGUI>();
            text.text = trait.name;
            


            spawnedTraits.Add(text);
        }
    }

    private void ClearTraits()
    {
        foreach (var t in spawnedTraits)
        {
            Destroy(t.gameObject);
        }

        spawnedTraits.Clear();
    }

}
