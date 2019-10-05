using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bubble : MonoBehaviour
{
    private List<string> nextDialogues;
    private string currentDialogue;

    public float delayBetweenLetters;
    public float duration;

    private float counterDuration;

    private float counter = 0f;
    private TextMeshProUGUI TextPro;
    private int i = 0;

    private void Start()
    {
        TextPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void GiveDialogue(List<string> dialogues)
    {
        nextDialogues = new List<string>();
        for (int j = 0; j < dialogues.Count; ++j)
        {
            nextDialogues.Add(string.Copy(dialogues[j]));
        }
        currentDialogue = nextDialogues[0];
        nextDialogues.Remove(currentDialogue);
        i = 0;
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter > delayBetweenLetters/60)
        {
            counter = 0f;
            if (i <= currentDialogue.Length) {
                TextPro.text = currentDialogue.Substring(0,i);
                ++i;
                counterDuration = 0f;
            } else
            {
                ++counterDuration;
                if(counterDuration > duration)
                {
                    if (nextDialogues.Count > 0)
                    {
                        currentDialogue = nextDialogues[0];
                        nextDialogues.Remove(currentDialogue);
                        i = 0;
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}