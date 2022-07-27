using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyCheckHeightController : MonoBehaviour
{
    PulleyController parent;

    void Awake()
    {
        parent = transform.parent.GetComponent<PulleyController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == parent.LeftCollider || collision == parent.RightCollider)
        {
            Debug.Log("∏ÿ√„");
            parent.StopMoving();
        }
    }
}
