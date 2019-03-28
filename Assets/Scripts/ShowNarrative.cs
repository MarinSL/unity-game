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
        midLeveltext[0] = "To deny what has happened is to deny a chance at recovery";
        midLeveltext[1] = "Anger is a natural response, but do not let it consume you";
        midLeveltext[2] = "Bargain all you can, but the truth remains.";
        midLeveltext[3] = "Depression is living in a body that fights to survive with a mind that tries to die";
        midLeveltext[4] = "There are things in life we do not want to happen, but have to accept. People we cannot live without but have to let go.";
        narText.text = "";

        LevelController.LevelChanged += OnLevelChange;
    }

    public void OnLevelChange(int lvl)
    {
        if (this != null)
        {
            if (NarrativeStarted != null)
                NarrativeStarted(lvl);

            curLvl = lvl;
            if (lvl < midLeveltext.Length)

                narText.text = midLeveltext[lvl];
            StartCoroutine(FadeIn(narText, fadingTime));
        }
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