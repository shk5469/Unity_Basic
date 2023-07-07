using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    public float f = 1f;
    public BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(15, 30, 45) * Time.deltaTime * f;
        this.transform.Rotate(vector);

        
    }
}
