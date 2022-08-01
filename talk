using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject room;
    bool follow = false;
    public static int a = 0;
    void Start()
    {
        Invoke("OnInvoke", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (follow && Input.GetKeyDown(KeyCode.LeftShift) && Score.score > 0)
        {
            room.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
        a = 1;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
        a = 0;
    }
}
