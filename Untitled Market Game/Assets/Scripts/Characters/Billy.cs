using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.GetComponent<Object>() != null && other.transform.parent.GetComponent<Object>().type == ObjectType.Balle)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
