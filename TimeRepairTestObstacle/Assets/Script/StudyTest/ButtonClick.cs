using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    public void ClosePanel()
    {
        if (Panel.activeSelf == true)
        {
            Panel.SetActive(false);
        }
    }
}
