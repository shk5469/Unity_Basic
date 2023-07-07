using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemGet : MonoBehaviour
{
    public AudioSource audio;
    public int Score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.tag == "Item"
        if (collision.gameObject.CompareTag("Item"))
        {
            audio.Play();
            Score += 1;
            Destroy(collision.gameObject);

        }
    }
}
