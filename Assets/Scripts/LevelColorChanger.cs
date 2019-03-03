using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColorChanger : MonoBehaviour
{
    [SerializeField]
    Color[] colors = new Color[5];

    [SerializeField]
    private float changeDuration;

    private bool levelSwitching = false;

    private int currentColorInd = 0;

    private SpriteRenderer[] renderers;

    private float changingTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        LevelController.LevelChanged += this.OnLevelChanged;
        InitBackgrounds();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelSwitching)
        {
            changingTime += Time.deltaTime;
            LerpColor();
            if (changingTime >= changeDuration)
            {
                EndSwitching();
            }
        }
        
    }

    void OnLevelChanged(int lvl) {
        levelSwitching = true;
    }

    private void IterateColor()
    {
        if (currentColorInd + 1 == colors.Length)
            currentColorInd = 0;
        else
            currentColorInd++;
    }

    private void LerpColor()
    {
        Color currentColor = colors[currentColorInd];
        Color nextColor;
        if (currentColorInd + 1 == colors.Length)
            nextColor = colors[0];
        else
            nextColor = colors[currentColorInd + 1];
        
        Color color = Color.Lerp(currentColor, nextColor, changingTime / changeDuration);

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].color = color;
        }
    }

    private void EndSwitching()
    {
        levelSwitching = false;
        changingTime = 0;
        IterateColor();
    }

    private void InitBackgrounds()
    {

        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");
        renderers = new SpriteRenderer[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            renderers[i] = backgrounds[i].GetComponent<SpriteRenderer>();
            renderers[i].color = colors[currentColorInd];
        }
    }
}
