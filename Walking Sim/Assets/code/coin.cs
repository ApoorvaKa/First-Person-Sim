using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int speed = 30;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,speed * Time.deltaTime,0, Space.World);
    }
}
