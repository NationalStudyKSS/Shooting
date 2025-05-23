using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMesh scoreText;
    public float gameTime;

    // Update is called once per frame
    void Update()
    {
        gameTime = Time.time;
        scoreText.text = "SCORE : " + (int)gameTime + "S";
    }
}
