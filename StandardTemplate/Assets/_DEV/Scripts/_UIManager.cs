using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _UIManager : MonoBehaviour
{
    #region Singleton

    public static _UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject activityText;
    public Transform gameLog;
    public NeedsTracker ai;
    public Slider globalhunger;
    public Slider globalthirst;
    public Slider globalenergy;
    private Text previousString;
    private int timesAttempted;
    public float delayOnDestroyLogText = 20;
    public bool doesUpdateGlobal = true;

    public NeedsTracker[] allAi;

    private void Start()
    {
        previousString = null;
        timesAttempted = 0;

        globalhunger.gameObject.SetActive(doesUpdateGlobal);
        globalthirst.gameObject.SetActive(doesUpdateGlobal);
        globalenergy.gameObject.SetActive(doesUpdateGlobal);

        if (!doesUpdateGlobal)
        {
            foreach (NeedsTracker ai in allAi)
            {
                Slider[] needSliders = ai.GetComponentsInChildren<Slider>();

                for (int i = 0; i < needSliders.Length; i++)
                {
                    if (ai.needs.Length > i)
                    {
                        needSliders[i].maxValue = ai.needs[i].maxValue;
                        needSliders[i].minValue = ai.needs[i].minValue;
                        needSliders[i].value = ai.needs[i].currentValue;
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (doesUpdateGlobal)
        {
            globalhunger.value = ai.GetNeedValue("hunger");
            globalthirst.value = ai.GetNeedValue("thirst");
            globalenergy.value = ai.GetNeedValue("energy");
        }
        else
        {
            foreach (NeedsTracker ai in allAi)
            {
                if (ai != null)
                {
                    Slider[] needSliders = ai.GetComponentsInChildren<Slider>();

                    for (int i = 0; i < needSliders.Length; i++)
                    {
                        if (ai.needs.Length > i)
                        {
                            needSliders[i].value = ai.needs[i].currentValue;
                        }
                    }
                }
                
            }
        }
    }

    public void LogString(string logString)
    {

        if (previousString != null && logString.Length <= previousString.text.Length && logString == previousString.text.Substring(0,logString.Length))
        {
            timesAttempted++;
            previousString.text = logString + " x" + timesAttempted;
        }
        else
        {
            GameObject newActivityText = Instantiate(activityText, gameLog);
            timesAttempted = 1;
            previousString = newActivityText.GetComponent<Text>();
            previousString.text = logString;
            Destroy(newActivityText, delayOnDestroyLogText);

        }
    }
}
