using TMPro;
using UnityEngine;

public class MonsterProfileUI : MonoBehaviour
{
    public CurrentMonsterSO currentMonster;

    [SerializeField] private TextMeshProUGUI monsterName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monsterName.text = currentMonster.monsterName;
    }

}
