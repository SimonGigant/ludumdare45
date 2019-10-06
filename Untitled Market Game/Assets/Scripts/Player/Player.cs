using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed;
    public Camera cam;
    public Material shaderSelection;
    public ObjectType inventory = ObjectType.None;
    private Transform _selection;
    private Material defaultMaterial;

    private CharacterController _controller;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void AddToInventory(ObjectType obj)
    {
        inventory = obj;
    }

    void Update()
    {
        Vector3 move = (Input.GetAxis("Horizontal") * new Vector3(cam.transform.right.x, 0, cam.transform.right.z) + Input.GetAxis("Vertical") * new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z)).normalized;
        _controller.Move(move * Time.deltaTime * speed);
        

        if(_selection != null && _selection.CompareTag("Pickable"))
        {
            Renderer selectionRenderer = _selection.parent.GetComponentInChildren<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
        if (Physics.Raycast(ray, out hit))
        {
            _selection = hit.transform;
            if (_selection.CompareTag("Selectable"))
            {
                GameObject g = _selection.transform.parent.gameObject;
                Character thisChar = g.GetComponent<Character>();
                if (Input.GetButton("Fire1") && thisChar != null)
                {
                    thisChar.MeetCharacter();
                }
            }else if(_selection.CompareTag("Pickable"))
            {
                GameObject g = _selection.transform.parent.gameObject;
                Object thisObject = g.GetComponent<Object>();
                if (thisObject != null) {
                    Renderer selectionRenderer = _selection.parent.GetComponentInChildren<Renderer>();
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = shaderSelection;
                    if (Input.GetButton("Fire1")) {
                        AddToInventory(thisObject.type);
                        Destroy(g);
                    }
                }
            }
        }
    }
}
