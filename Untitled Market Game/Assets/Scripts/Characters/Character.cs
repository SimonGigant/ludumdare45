using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Texts
{
    public List<string> list;
}

[System.Serializable]
public class BigTexts
{
    public List<Texts> list;
    public List<List<string>> Lists()
    {
        List<List<string>> res = new List<List<string>>();
        foreach(Texts i in list)
        {
            res.Add(i.list);
        }
        return res;
    }
}

public class Character : MonoBehaviour
{
    public BigTexts dialogInInspector = new BigTexts();
    private List<List<string>> dialogue;
    private bool met;

    public GameObject bubble;
    public Player player;

    public float heightBubble;
    
    private GameObject activeBubble = null;

    private void Start()
    {
        met = false;
        dialogue = dialogInInspector.Lists();
    }

    public void MeetCharacter()
    {
        if (met)
        {
            if (dialogue.Count > (int)player.inventory) {
                Talk(dialogue[(int)player.inventory]);
            }
            else
            {
                Talk(dialogue[1]);
            }
        }
        else
        {
            Talk(dialogue[0]);
            met = true;
        }
    }

    private void Talk(List<string> text)
    {
        if(activeBubble == null)
        {
            Quaternion quat = transform.rotation;
            quat.y += -90;
            activeBubble = GameObject.Instantiate(bubble,transform.position + new Vector3(0, heightBubble, 0), quat);
            activeBubble.transform.parent = gameObject.transform;
            Bubble b = activeBubble.GetComponent<Bubble>();
            b.GiveDialogue(text);
        }
    }
}
