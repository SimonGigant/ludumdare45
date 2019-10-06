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
    public float rotatBubble;
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
            Bubble.instance.GiveDialogue(text);
            if (gameObject.name.CompareTo("Lysandre") == 0 && player.GetComponent<Player>().inventory == ObjectType.Touillette)
            {
                player.GetComponent<Player>().inventory = ObjectType.Cle;
            }
            else if (gameObject.name.CompareTo("M_Sport") == 0 && player.GetComponent<Player>().inventory == ObjectType.Revue)
            {
                player.GetComponent<Player>().inventory = ObjectType.Scie;
            }
            else if (gameObject.name.CompareTo("FX_deBidoche") == 0 && player.GetComponent<Player>().inventory == ObjectType.Scie)
            {
                player.GetComponent<Player>().inventory = ObjectType.Rein;
            }
            else if (gameObject.name.CompareTo("Beatrice") == 0 && player.GetComponent<Player>().inventory == ObjectType.Rein)
            {
                player.GetComponent<Player>().inventory = ObjectType.Thune;
            }
            else if (gameObject.name.CompareTo("Sophie") == 0 && player.GetComponent<Player>().inventory == ObjectType.Thune)
            {
                player.GetComponent<Player>().inventory = ObjectType.Ticket;
            }
    }
    
}
