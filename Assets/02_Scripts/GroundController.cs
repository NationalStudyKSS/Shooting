using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public float scrollSpeed = 2.0f;
    public Renderer rend;
    
    // Update is called once per frame
    void Update()
    {
        //print(Time.time);
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}
