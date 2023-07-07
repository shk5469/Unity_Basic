using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementForce : MonoBehaviour
{
    public float force = 1f;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(h, 0f, v) * force;
        rigidbody.AddForce(movement);
    }
}
