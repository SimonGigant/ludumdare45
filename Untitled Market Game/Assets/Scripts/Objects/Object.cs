using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ObjectType{ None = 1, Touillette = 2, Cle = 3, Balle = 4, Revue = 5, Scie = 6, Rein = 7, Thune = 8, Ticket = 9};
public class Object : MonoBehaviour
{
    public ObjectType type;
}
