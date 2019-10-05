using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Camera cam;
    public Material shaderSelection;

    private CharacterController _controller;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 move = (Input.GetAxis("Horizontal") * new Vector3(cam.transform.right.x, 0, cam.transform.right.z) + Input.GetAxis("Vertical") * new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z)).normalized;
        _controller.Move(move * Time.deltaTime * speed);
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
        if (Physics.Raycast(ray, out hit))
        {
            Transform selection = hit.transform;
            if (selection.CompareTag("Selectable"))
            {
                GameObject g = selection.transform.parent.gameObject;
                Character thisChar = g.GetComponent<Character>();
                if (Input.GetButton("Fire1") && thisChar != null)
                {
                    thisChar.MeetCharacter();
                }
            }
        }
    }
}
