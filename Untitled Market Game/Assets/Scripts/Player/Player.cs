using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Camera cam;

    //temp
    public Character c;

    private CharacterController _controller;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = (Input.GetAxis("Horizontal") * new Vector3(cam.transform.right.x, 0, cam.transform.right.z) + Input.GetAxis("Vertical") * new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z)).normalized;
        _controller.Move(move * Time.deltaTime * speed);
        if (Input.GetButton("Fire1"))
        {
            c.MeetCharacter();
        }
    }
}
