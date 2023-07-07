using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Transform tr;
    Animation anim;
    Rigidbody rg;
    public float moveSpeed = 10f;
    public float turnSpeed = 1000f;
    //public float jumpForce = 10000;
    // Start is called before the first frame update

    readonly float initHp = 100f;
    public float currHp;

    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;
    IEnumerator Start()
    {
        currHp = initHp;

        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        rg = GetComponent<Rigidbody>();

        anim.Play("Idle");
        turnSpeed = 0f;
        yield return new WaitForSeconds(0.3f);
        turnSpeed = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //float j = Input.GetAxis("Jump");
        float r = Input.GetAxis("Mouse X");
        //Vector3.foward = (0,0,1)
        //Vector3.right = (1,0,0)

        //this.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * moveSpeed);
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h); //이동 방향

        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);
        tr.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r);
        //if (tr.position.y <= 0)
        //    rg.AddForce(Vector3.up * j * Time.deltaTime * jumpForce);

        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        if (v >= 0.1)
        {
            anim.CrossFade("RunF", 0.25f);
        }
        else if (v <= -0.1)
        {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1)
        {
            anim.CrossFade("RunR", 0.25f);
        }
        else if (h <= -0.1)
        {
            anim.CrossFade("RunL", 0.25f);
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(currHp>=0.0f && other.CompareTag("PUNCH"))
        {
            currHp -= 10f;
            Debug.Log($"Player hp = {currHp / initHp}");

            if(currHp <= 0f)
            {
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {
        Debug.Log("Player Die !");

        //GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");

        //foreach(var e in monsters)
        //{
        //    e.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        //}

        OnPlayerDie();
    }
}
