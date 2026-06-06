using TMPro;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] tasks;

    int count = 0;
    public void CompleteTask(int taskIndex)
    {
        if (taskIndex < 0 || taskIndex >= tasks.Length)
            return;

        tasks[taskIndex].text = $"<s>{tasks[taskIndex].text}</s>";
        count++;

        if(count == tasks.Length)
        {
            gameObject.SetActive(false);
        }
    }
}
