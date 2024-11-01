using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float Speed;
    private Rigidbody push;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        push = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x, z;

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        direction = transform.right * x + transform.forward * z;
        transform.position += direction * Time.deltaTime*Speed; 

    }
}
