using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private List<string> nextDialogues;
    private string currentDialogue;

    public float delayBetweenLetters;

    private float counter = 0f;

    public void GiveDialogue(List<string> dialogues)
    {
        nextDialogues = dialogues;
        currentDialogue = nextDialogues[0];
        
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter > delayBetweenLetters)
        {
            counter = 0f;
            if(Equals(currentDialogue,""))
            {
                if (nextDialogues.Count > 0)
                {
                    currentDialogue = nextDialogues[0];
                    nextDialogues.Remove(currentDialogue);
                }
            }
            else
            {
                currentDialogue.Substring(1);
            }
        }
    }
}
