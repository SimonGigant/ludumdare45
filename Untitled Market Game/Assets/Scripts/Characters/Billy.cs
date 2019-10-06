using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billy : MonoBehaviour
{
    public GameObject revue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.GetComponent<Object>() != null && other.transform.parent.GetComponent<Object>().type == ObjectType.Balle)
        {
            Quaternion quat = Quaternion.identity;
            quat.x = -90;
            GameObject g = GameObject.Instantiate(revue, transform.position - Vector3.up * 1.5f,quat);
            g.transform.rotation = Quaternion.Euler(-90,0,0) ;
            Destroy(transform.parent.gameObject);
        }
    }
}
