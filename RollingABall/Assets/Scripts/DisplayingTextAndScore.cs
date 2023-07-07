using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayingTextAndScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject winText;
    public PlayerItemGet playerItemGet; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText($"Score: {playerItemGet.Score}");
        if (playerItemGet.Score == 4)
        {
            winText.SetActive(true);
        }
    }
}
