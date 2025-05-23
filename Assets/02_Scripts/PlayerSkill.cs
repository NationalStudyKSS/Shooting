using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject allyFlight;
    public void Skill1()
    {
        List<float> list = new List<float> { -2.5f, -1.25f, 0, 1.25f, 2.5f };
        foreach (var item in list)
        {
            Vector3 vec = new Vector3(item, transform.position.x, transform.position.z);
            Instantiate(allyFlight, vec, transform.rotation);
        }
            
    }
}
