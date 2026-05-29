using TMPro;
using UnityEngine;

public class MonsterProfileUI : MonoBehaviour
{
    public MonsterContext currentMonster;

    [SerializeField] private TextMeshProUGUI monsterName;
    [SerializeField] private TextMeshProUGUI monsterType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monsterName.text = currentMonster.monster.monsterName;
        monsterType.text = currentMonster.monster.monsterType.name;
    }

}
