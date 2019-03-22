using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowNarrative : MonoBehaviour
{
    string[] midLeveltext = new string[5];
    public Text narText;
    [SerializeField]
    private float narrativeLength = 10;
    [SerializeField]
    private float fadingTime = 1;
    private int curLvl;

    public static event Action<int> NarrativeFinished;
    public static event Action<int> NarrativeStarted;
    // Start is called before the first frame update
    void Start()
    {
        midLeveltext[0] = "irrrrrrrr boi";
        midLeveltext[1] = "wake me up inside";
        midLeveltext[2] = "mEoW 3";
        midLeveltext[3] = "";
        midLeveltext[4] = "your parents don't love you 5";
        narText.text = "its ya boi";

        LevelController.LevelChanged += OnLevelChange;
    }

    public void OnLevelChange(int lvl)
    {
        if (NarrativeStarted != null)
            NarrativeStarted(lvl);
        var narrativeCorutine = ShowText(lvl);
        //
        curLvl = lvl;
        if (lvl < midLeveltext.Length)
            narText.text = midLeveltext[lvl];
        StartCoroutine(FadeIn(narText, fadingTime));

        //StartCoroutine(narrativeCorutine);
    }

    IEnumerator ShowText(int lvl)
    {
        if (lvl < midLeveltext.Length)
            narText.text = midLeveltext[lvl];

        // StartCoroutine(FadeIn(narText, delayTime));
        // yield return new WaitForSeconds(delayTime);
        //StartCoroutine(Wait());
        // new WaitForSeconds(10);
        // StartCoroutine(FadeOut(narText, delayTime));
        // yield return new WaitForSeconds(delayTime);
        yield return null;

        /*narText.text = "";
        if (NarrativeFinished != null)
            NarrativeFinished(lvl);*/
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(narrativeLength);
        StartCoroutine(FadeOut(narText, fadingTime));
    }

    IEnumerator FadeIn(Text txt, float t)
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0);
        while (txt.color.a <= 1.0f)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a + Time.deltaTime / t);
            yield return null;
        }
        StartCoroutine(Wait());
    }

    IEnumerator FadeOut(Text txt, float t)
    {
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1);
        while (txt.color.a >= 0f)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a - Time.deltaTime / t);
            yield return null;
        }
        //
        narText.text = "";
        if (NarrativeFinished != null)
            NarrativeFinished(curLvl);
    }

    public void HideText()
    {
        narText.text = "";
    }
}