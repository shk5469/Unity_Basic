using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestAnimation : MonoBehaviour
{
    public Material m;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m.SetTextureOffset("_MainTex",m.GetTextureOffset("_MainTex")+new Vector2(0,0.001f));
        
    }
}
