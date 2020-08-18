using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler : MonoBehaviour
{
    Rigidbody rb;
    float speed = 2;
    float yRotation = 0;
    bool[] schluessel;

    public GameObject maincamera;



    // Start is called before the first frame update
    void Start()
    {
        schluessel = new bool[7];
        rb = GetComponent<Rigidbody>();
        for(int i = 0; i < schluessel.Length;i++)
        {
            schluessel[i] = false;
        }
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

        /// Camera controll via Raycast
        RaycastHit hit;
        // Shoot Raycast and save position in "hit"
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1.5f))
        {
            // if it hits something, then go to the hit point and increase y to 0.6
            maincamera.transform.position = new Vector3(hit.point.x, 0.6f, hit.point.z);
            
            maincamera.transform.LookAt(transform.position);
        }
        // Else go to the point the ray could have traveled to at max and set y again to 0.6
        else
        {
            Vector3 point = transform.position + (transform.TransformDirection(Vector3.back) * 1.5f);
            maincamera.transform.position = new Vector3(point.x, 0.6f, point.z);
            maincamera.transform.LookAt(transform.position);
        }
        /// End
    }

    private void OnTriggerEnter(Collider coll)
    {
        // If you collect a Key, only get the number and change this index in the array
        if (coll.gameObject.tag == "Schluessel")
        {
            schluessel[int.Parse(coll.gameObject.name.Substring(10, 1))] = true;
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        // If you hit a barrier , only get the number of the barrier and check if the index in the array is set to true
        if (coll.gameObject.tag == "Sperre")
        {
            if (schluessel[int.Parse(coll.gameObject.name.Substring(6,1))])
            {
                coll.gameObject.SetActive(false);
            }
        }
    }
}
