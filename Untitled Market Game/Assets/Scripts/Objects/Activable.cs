using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActivableType{BoiteABalle};
public class Activable : MonoBehaviour
{
    public ActivableType type;
    private bool activated = false;
    public GameObject balle;

    public bool Activate(ObjectType inventory)
    {
        switch (type)
        {
            case ActivableType.BoiteABalle:
                {
                    if(activated||inventory == ObjectType.Cle)
                    {
                        activated = true;
                        GameObject thrown = GameObject.Instantiate(balle, transform.position + Vector3.up * 1.5f, transform.rotation);
                        return true;
                    }
                    break;
                }
        }
        return false;
    }
}
