using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Monster;
    public int monsterCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < monsterCount; i++)
        {
            Monster.transform.position = new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20));
            Instantiate(Monster, Monster.transform.position, Monster.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
