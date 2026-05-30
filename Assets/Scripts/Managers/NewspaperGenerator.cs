// NewspaperGenerator.cs
using UnityEngine;

public class NewspaperGenerator : MonoBehaviour
{

    public NewspaperData[] NewspaperData;

    public NewspaperData Generate(int day)
    {
        NewspaperData data = new NewspaperData();

        int randomIndex = Random.Range(0, NewspaperData.Length);

        data.eventTitle = NewspaperData[randomIndex].eventTitle;
        data.eventDescription = NewspaperData[randomIndex].eventDescription;

        return data;
    }
}