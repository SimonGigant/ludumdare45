using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerBallColor : MonoBehaviour
{
    public List<Material> colors;

    void Start()
    {
        GetComponent<Renderer>().material = colors[(int)Mathf.Floor(Random.Range(0,colors.Count))];
    }
}
