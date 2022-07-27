using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyController : MonoBehaviour
{
    GameObject left;
    GameObject right;
    Rigidbody2D LeftRigid;
    Rigidbody2D RightRigid;

    [SerializeField] float speed = 1.0f;

    // 테스트용
    bool test = false;
    void Start()
    {
        left = transform.GetChild(0).gameObject;
        right = transform.GetChild(1).gameObject;

        LeftRigid = left.GetComponent<Rigidbody2D>();
        RightRigid = right.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("작동");
            test = true;
        }

        if (test)
        {
            rightDown();
        }
    }

    void rightDown()
    {
        LeftRigid.velocity = Vector2.up * speed;
        RightRigid.velocity = Vector2.down * speed;
        StartCoroutine(MovingDelay());
    }

    IEnumerator MovingDelay()
    {
        yield return new WaitForSeconds(3.0f);
        LeftRigid.velocity = Vector2.zero;
        RightRigid.velocity = Vector2.zero;
        test = false;
    }
}
