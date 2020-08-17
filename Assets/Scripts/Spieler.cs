using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler : MonoBehaviour
{
    Rigidbody rb;
    float speed = 2;
    float yRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move with 2 speed forwards or backwards, pressing W or S, else stay still
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * (speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.forward * (-speed);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        
        // Rotate left and right, not influenced by frame Rate
        if (Input.GetKey(KeyCode.D))
        {
            yRotation += 300 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.rotation.x, yRotation, transform.rotation.z);
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            yRotation -= 300 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.rotation.x, yRotation, transform.rotation.z);
            
        }
    }
}
