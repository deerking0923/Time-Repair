using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSwtichController : MonoBehaviour
{
    GameObject[] Wheel;

    void Start()
    {
        Wheel = GameObject.FindGameObjectsWithTag("Wheel");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < Wheel.Length; i++)
            {
                Wheel[i].GetComponent<WheelController>().ReverseDirection();
            }
        }
    }
}
