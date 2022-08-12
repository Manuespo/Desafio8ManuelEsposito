using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 direction;
    public float speed = 2f;
    public float cameraAxis = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
    }
    void movimiento()
    {
        //RotatePlayer();
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (direction != Vector3.zero)
            MovePlayer(direction);
    }
    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void RotatePlayer()
    {
        cameraAxis += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(0, cameraAxis * 2f, 0);
    }
}
