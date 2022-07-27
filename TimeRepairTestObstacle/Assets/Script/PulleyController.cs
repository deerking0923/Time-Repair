using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyController : MonoBehaviour
{
    GameObject left, right; 
    GameObject wheel;
    Rigidbody2D LeftRigid, RightRigid;
    internal Collider2D LeftCollider, RightCollider;
    Collider2D CheckHeight;

    // bool MovingRightDown = false, MovingLeftDown = false;

    [SerializeField] float speed = 100.0f;

    // 테스트용
    bool test = false;
    void Awake()
    {
        // 좌, 우의 발판 가져오기
        left = transform.GetChild(0).gameObject;
        right = transform.GetChild(1).gameObject;

        LeftRigid = left.GetComponent<Rigidbody2D>();
        RightRigid = right.GetComponent<Rigidbody2D>();

        LeftCollider = left.GetComponent<Collider2D>(); 
        RightCollider = right.GetComponent<Collider2D>();

        // CheckHeight 가져오기
        CheckHeight = transform.GetChild(2).GetComponent<Collider2D>();

        // 톱니바퀴 가져오기
        wheel = transform.GetChild(3).gameObject;
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
            LeftDown();
        }
    }

    // 1. 오른쪽이 밑으로
    void RightDown()
    {
        LeftRigid.velocity = Vector2.up * speed * Time.deltaTime;
        RightRigid.velocity = Vector2.down * speed * Time.deltaTime; 
        wheel.transform.Rotate(new Vector3(0, 0, -1), speed * Time.deltaTime);
    }

    // 2. 왼쪽이 밑으로
    void LeftDown()
    {
        RightRigid.velocity = Vector2.up * speed * Time.deltaTime;
        LeftRigid.velocity = Vector2.down * speed * Time.deltaTime;
        wheel.transform.Rotate(new Vector3(0, 0, 1), speed * Time.deltaTime);
    }

    // 3. 멈춤 : internal로 선언해서 동일 프로젝트에만 자유롭게 사용
    internal void StopMoving()
    {
        LeftRigid.velocity = Vector2.zero;
        RightRigid.velocity = Vector2.zero;
        wheel.transform.Rotate(new Vector3(0, 0, 0), 0.0f);
        test = false;           // 종료 변수 flag
    }
}
