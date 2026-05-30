using UnityEngine;

public class RenderNewspaper : MonoBehaviour
{
    [SerializeField] private NewspaperDaily newspaperDaily;
    private void OnEnable()
    {
        newspaperDaily.RefreshNewsPaper();
    }
}
