using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleySwtichController : MonoBehaviour
{
    [SerializeField] GameObject[] Pulleies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < Pulleies.Length; i++)
            {
                Pulleies[i].GetComponent<PulleyController>().Stop = false;
            }
        }
    }
}
