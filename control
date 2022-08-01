using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    float movex, movey;
    [SerializeField][Range(3f, 10f)] float moveSpeed = 5f;
    public gamemanager manager;
    GameObject scanObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);

        movex = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + movex, transform.position.y + movey);
        if (Input.GetKey(KeyCode.LeftShift) && Score.score == 0)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
