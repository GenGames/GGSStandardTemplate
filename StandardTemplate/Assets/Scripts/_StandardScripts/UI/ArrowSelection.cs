using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowSelection : MonoBehaviour
{
    public DataType myDataType;
    public bool returnIndexInsteadOfSelectedValue;
    public string[] options;
    public Text targetText;
    public int currentOption;

    public bool enableImageCarousel;
    public Sprite[] imageOptions;
    public Image imageTarget;

    private void Start()
    {
        CycleOption(0);
    }

    //target this with buttons to cycle through options
    public void CycleOption(int increment)
    {
        currentOption += increment;

        if (currentOption >= options.Length)
        {
            currentOption = 0;
        } 
        else if( currentOption < 0)
        {
            currentOption = options.Length - 1;
        }

        UpdateCurrentText(currentOption);
    }

    public void UpdateCurrentText(int stringOption)
    {
        if (currentOption != stringOption)
        {
            currentOption = stringOption;
        }

        targetText.text = options[stringOption];

        if (enableImageCarousel)
        {
            imageTarget.sprite = imageOptions[stringOption];
        }
    }

    public string GetCurrentOptionAsString()
    {
        return options[currentOption];
    }

    public int GetCurrentOptionAsInt()
    {
        if (returnIndexInsteadOfSelectedValue)
        {
            return currentOption;
        }
        if (myDataType != DataType.Int)
        {
            return currentOption;
        }
        return int.Parse(options[currentOption]);
    }

    public float GetCurrentOptionAsFloat()
    {
        if (myDataType != DataType.Float)
        {
            return currentOption;
        }
        return float.Parse(options[currentOption]);
    }

    public enum DataType
    {
        String,
        Float,
        Int
    }
}
