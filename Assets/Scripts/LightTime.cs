using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTime : MonoBehaviour
{
    Vector3 position1 = new Vector3(-250,220,10), position2 = new Vector3(250,240,23);
    public float speed;

    void Update()
    {
        transform.position = (Vector3.Lerp(position1, position2, (Mathf.Sin(speed * Time.time / 2))));
    }
}
