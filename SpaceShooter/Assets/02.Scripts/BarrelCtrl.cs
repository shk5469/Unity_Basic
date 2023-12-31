using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEditor.AI;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;
    public Texture[] textures;
    new MeshRenderer renderer;
    public GameObject floor;

    public float radius = 10;

    NavMeshSurface surface;
    Transform tr;
    Rigidbody rb;
    int hitCount;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        surface = floor.GetComponent<NavMeshSurface>();
        renderer = GetComponentInChildren<MeshRenderer>();

        int idx = Random.Range(0, textures.Length);

        renderer.material.mainTexture = textures[idx];
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(NavUpdate());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
        surface.BuildNavMesh();
    }

    void ExpBarrel()
    {
        GameObject exp = Instantiate(expEffect, tr.position, Quaternion.identity);

        Destroy(exp, 5f);

        //rb.mass = 1.0f;
        //rb.AddForce(Vector3.up * 1500);

        IndirectDamage(tr.position);
        Destroy(gameObject, 3f);
    }

    void IndirectDamage(Vector3 pos)
    {
        Collider[] colls = Physics.OverlapSphere(pos, radius, 1 << 3);

        foreach(var coll in colls)
        {
            rb = coll.GetComponent<Rigidbody>();
            rb.mass = 1;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddExplosionForce(1500, pos, radius, 1200);
        }
    }

    IEnumerator NavUpdate()
    {
        surface.BuildNavMesh();
        yield return new WaitForSeconds(3f);

    }
}
