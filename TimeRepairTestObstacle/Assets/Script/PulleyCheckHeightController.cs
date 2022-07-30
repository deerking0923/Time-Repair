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
        if (collision == parent.LeftCollider) // || collision == parent.RightCollider)
        {
            Debug.Log("왼쪽이 닿아서 멈춤");
            parent.Stop = true;
            parent.MovingLeftDown = true; // 다음에 움직일 순서 : 왼쪽 아래
        }

        else if (collision == parent.RightCollider)
        {
            Debug.Log("오른쪽이 닿아서 멈춤");
            parent.Stop = true;
            parent.MovingLeftDown = false; // 다음에 움직일 순서 : 오른쪽 아래
        }
    }
}
