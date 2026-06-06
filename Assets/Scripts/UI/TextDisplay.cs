using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    public UnityEvent EndConversation;

    [TextArea]
    [SerializeField] private string[] lines;

    private int currentLine = 0;

    private void Start()
    {
        if (lines.Length > 0)
        {
            dialogueText.text = lines[0];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    private void NextLine()
    {
        currentLine++;

        if (currentLine >= lines.Length)
        {
            gameObject.SetActive(false);
            EndConversation?.Invoke();
            return;
        }

        dialogueText.text = lines[currentLine];
    }
}
