using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monologue_UI : MonoBehaviour
{
    #region Singleton

    public static Monologue_UI instance;

    private void Awake()
    {
        instance = this;
    }


    #endregion

    public string[] dialogueLines;
    public string[] speakerNames;
    public Text speakerNameUI;
    public Text dialogueUI;
    public int currentLineIndex;
    public string newScene;

    public bool utilizeImages;
    public Transform imageTarget;
    private List<CharacterImage> currentCharacters = new List<CharacterImage>();
    public CharacterImage[] allCharactersInGame;


    private void Start()
    {
        if (PlayData.instance != null)
        {
            //dialogueLines = GameData.instance.dialogueLines;
            //speakerNames = GameData.instance.speakerNames;
            //if (GameData.instance.nextScene != "")
            //{
            //    newScene = GameData.instance.nextScene;
            //}
            for (int i = 0; i < speakerNames.Length; i++)
            {
                foreach (CharacterImage character in allCharactersInGame)
                {

                    if (speakerNames[i] == character.characterName && !currentCharacters.Contains(character))
                    {
                        imageTarget.GetChild(currentCharacters.Count).gameObject.GetComponent<Image>().sprite = character.characterSprite;
                        imageTarget.GetChild(currentCharacters.Count).gameObject.name = character.characterName;

                        currentCharacters.Add(character);
                    }
                }

            }

            StartDialogue();
        }
    }

    public void StartDialogue()
    {

        if (dialogueLines.Length > 0)
        {
            GoToLine(0);
        }
        else
        {
            Debug.LogError("there are no dialogue lines here!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || 
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.D))
        {
            NextLine();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)||
                Input.GetKeyDown(KeyCode.A))
        {
            PreviousLine();
        }
    }

    public void GoToLine(int lineNumber)
    {
        currentLineIndex = lineNumber;
        if (currentLineIndex < speakerNames.Length)
        {
            speakerNameUI.text = speakerNames[lineNumber];
            dialogueUI.text = dialogueLines[lineNumber];

            if (utilizeImages)
            {

                for (int i = 0; i < imageTarget.childCount; i++)
                {
                    if (imageTarget.GetChild(i).name == speakerNames[lineNumber])
                    {
                        imageTarget.GetChild(i).gameObject.SetActive(true);
                        imageTarget.GetChild(i).gameObject.GetComponent<Image>().color = GetCharacterImageByName(speakerNames[lineNumber]).activeColor;
                    }
                    else
                    {
                        imageTarget.GetChild(i).gameObject.GetComponent<Image>().color = GetCharacterImageByName(speakerNames[lineNumber]).inactiveColor;
                    }
                }
            }
        }
        else
        {
            GameManager.instance.GoToSceneName(newScene);
        }
    }

    public void NextLine()
    {
        GoToLine(currentLineIndex + 1);
    }

    public void PreviousLine()
    {
        GoToLine(currentLineIndex - 1);
    }

    public CharacterImage GetCharacterImageByName(string characterName)
    {
        CharacterImage myImage = new CharacterImage();

        foreach (CharacterImage character in allCharactersInGame)
        {
            if (character.characterName == characterName)
            {
                myImage = character;
            }
        }

        return myImage;
    }

    public CharacterImage GetCharacterImageBySprite(Sprite characterSprite)
    {
        CharacterImage myImage = new CharacterImage();

        foreach (CharacterImage character in allCharactersInGame)
        {
            if (character.characterSprite == characterSprite)
            {
                myImage = character;
            }
        }

        return myImage;
    }
}

[System.Serializable]
public struct CharacterImage
{
    public string characterName;
    public Sprite characterSprite;
    public Color activeColor;
    public Color inactiveColor;
}
