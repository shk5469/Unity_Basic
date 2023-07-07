using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("BULLET"))
        {
            ContactPoint cp = collision.GetContact(0);
            Quaternion rot = Quaternion.LookRotation(-cp.normal);

            Destroy(Instantiate(sparkEffect, cp.point, rot),0.5f);
            Destroy(collision.gameObject);
        }
    }
}
