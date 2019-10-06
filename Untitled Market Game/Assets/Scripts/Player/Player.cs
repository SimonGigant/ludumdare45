using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed;
    public Camera cam;
    public Material shaderSelection;
    public ObjectType inventory = ObjectType.None;
    public GameObject balle;

    private Transform _selection;
    private Material defaultMaterial;
    private float yvalue = 0f;

    private CharacterController _controller;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    public void AddTouillette()
    {
        AddToInventory(ObjectType.Touillette);
    }

    public void AddToInventory(ObjectType obj)
    {
        if (inventory == ObjectType.None || inventory == ObjectType.Balle)
        {
            inventory = obj;
        }
    }

    void Update()
    {
        yvalue += Physics.gravity.y * Time.deltaTime * 5f;
        Vector3 move = Vector3.up * yvalue + (Input.GetAxis("Horizontal") * new Vector3(cam.transform.right.x, 0, cam.transform.right.z) + Input.GetAxis("Vertical") * new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z)).normalized;
        _controller.Move(move * Time.deltaTime * speed);


        if (_selection != null && (_selection.CompareTag("Pickable") || _selection.CompareTag("Activable")))
        {
            Renderer selectionRenderer = _selection.parent.GetComponentInChildren<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        if (inventory == ObjectType.Balle && Input.GetButtonDown("Fire1"))
        {
            inventory = ObjectType.None;
            GameObject thrown = GameObject.Instantiate(balle, transform.position + cam.transform.forward * 1.5f + Vector3.up * 1.5f, transform.rotation);
            Rigidbody rigidbody = thrown.GetComponentInChildren<Rigidbody>();
            rigidbody.AddForce(cam.transform.forward * 2000);
            return;
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
                if (Input.GetButtonDown("Fire1") && thisChar != null)
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
                    if (Input.GetButtonDown("Fire1")) {
                        AddToInventory(thisObject.type);
                        Destroy(g);
                    }
                }
            }else if (_selection.CompareTag("Activable"))
            {
                GameObject g = _selection.transform.parent.gameObject;
                Renderer selectionRenderer = _selection.parent.GetComponentInChildren<Renderer>();
                defaultMaterial = selectionRenderer.material;
                selectionRenderer.material = shaderSelection;
                if (Input.GetButtonDown("Fire1"))
                {
                    Activable act = _selection.parent.GetComponentInChildren<Activable>();
                    if (act.Activate(inventory))
                    {
                        inventory = ObjectType.None;
                    }
                }
            }
        }
    }
}
