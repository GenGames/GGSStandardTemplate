using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject creditPlatePrefab;
    public Transform creditsReel;
    public Contributor[] contributors;

    private void Start()
    {
        foreach (Contributor contributor in contributors)
        {
            GameObject newContributorCredit = Instantiate(creditPlatePrefab, creditsReel);
            Text[] text = newContributorCredit.GetComponentsInChildren<Text>();
            text[0].text = contributor.name;
            text[1].text = contributor.title;
            if (text.Length > 2 && contributor.quote != null)
            {
                text[2].text = contributor.quote;
            }
            GetComponentInChildren<Image>().sprite = contributor.developerIcon;
        }
    }
}

[System.Serializable]
public struct Contributor
{
    public string name;
    public string title;
    public Sprite developerIcon;
    public string quote;
}
