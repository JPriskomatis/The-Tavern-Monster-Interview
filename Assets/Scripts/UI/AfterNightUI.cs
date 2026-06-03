using TMPro;
using UnityEngine;

public class AfterNightUI : MonoBehaviour
{
    public StringVariable TonightsOutcome;

    [SerializeField] private TextMeshProUGUI outcomeTxt;

    public void SetUI()
    {
        outcomeTxt.text = TonightsOutcome.Value;
    }

}
