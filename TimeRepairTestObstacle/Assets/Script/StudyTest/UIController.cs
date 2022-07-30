using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("버튼 입력");
            Panel.SetActive(!(Panel.activeSelf));
        }
    }
}
