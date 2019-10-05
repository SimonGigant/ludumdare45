using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<string> firstMeetDialogue = new List<string>();
    public List<string> dialogue = new List<string>();
    private bool met;

    public GameObject bubble;
    private GameObject activeBubble = null;

    private void Start()
    {
        met = false;
    }

    public void MeetCharacter()
    {
        if (met)
        {
            Talk(dialogue);
        }
        else
        {
            Talk(firstMeetDialogue);
            met = true;
        }
    }

    private void Talk(List<string> text)
    {
        if(activeBubble == null)
        {
            Quaternion quat = transform.rotation;
            quat.y += -90;
            activeBubble = GameObject.Instantiate(bubble,transform.position + new Vector3(0,6,0), quat);
            activeBubble.transform.parent = gameObject.transform;
            Bubble b = activeBubble.GetComponent<Bubble>();
            b.GiveDialogue(text);
        }
    }
}
