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
    private float delayTime = 10;

    public static event Action<int> NarrativeFinished;
    public static event Action<int> NarrativeStarted;
    // Start is called before the first frame update
    void Start()
    {
        midLeveltext[0] = "meow 1";
        midLeveltext[1] = "M E O W 2";
        midLeveltext[2] = "mEoW 3";
        midLeveltext[3] = "gav 4";
        midLeveltext[4] = "your parents don't love you 5";
        narText.text = "";

        LevelController.LevelChanged += OnLevelChange;
    }

    public void OnLevelChange(int lvl)
    {
        Debug.Log("waiting");
        if (NarrativeStarted != null)
            NarrativeStarted(lvl);
        var narrativeCorutine = ShowText(lvl);
        StartCoroutine(narrativeCorutine);
    }

    /*private void ShowText(int lvl)
    {
        narText.text = midLeveltext[lvl];
    }*/

    IEnumerator ShowText(int lvl)
    {
        if (lvl < midLeveltext.Length)
            narText.text = midLeveltext[lvl];

        yield return new WaitForSeconds(delayTime);
        narText.text = "";
        if (NarrativeFinished != null)
            NarrativeFinished(lvl);
    }

    public void HideText()
    {
        narText.text = "";
    }

    void Update()
    {
    }
}