using UnityEngine;

public class ColorChange : MonoBehaviour
{

    [SerializeField]
    float changeDuration;
    [SerializeField]
    float levelDuration;

    [SerializeField]
    Color[] colors = new Color[5];
    Color color1, color2;

    GameObject[] backgrounds;
    SpriteRenderer[] spriteRenderers;


    float t = 0f;
    int i = 1;

    float startTime;
    void Start()
    {
        startTime = Time.time;

        color1 = colors[0];
        color2 = colors[1];

        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        spriteRenderers = new SpriteRenderer[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            spriteRenderers[i] = backgrounds[i].GetComponent<SpriteRenderer>();
        }

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = colors[0];
        }

    }

    void Update()
    {
        if (Time.time - startTime >= levelDuration)
        {
            if (ChangeColor())
            {
                i++;
                if (i < colors.Length)
                {
                    color1 = color2;
                    color2 = colors[i];
                    t = 0f;
                }
                startTime = Time.time;
            }
        }
    }

   public bool ChangeColor()
    {
        if (t <= 1)
        {
            Color color = Color.Lerp(color1, color2, t);
            t += Time.deltaTime / changeDuration;

            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].color = color;
            }
            return false;
        } else
        {
            return true;
        }
    }
}