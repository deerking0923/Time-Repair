using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] float WheSpeed = 100.0f;    // 회전 속도
    [SerializeField] bool ClockWise = false;     // 처음 회전 방향
    float BaseSpeed;

    bool isStop = false;        // 멈추는 중인지 확인
    bool isReverse = false;     // 방향을 바꿔야 하는지 확인
    bool ReverseDir = false;    // 함수 실행 시작

    void Start()
    {
        BaseSpeed = WheSpeed;
    }

    void FixedUpdate()
    {
        move();
        if (ReverseDir)
        {
            ReverseRot();
        }
        
    }

    void move()
    {
        if (ClockWise == false)
        {
            transform.Rotate(new Vector3(0, 0, 1), WheSpeed * Time.deltaTime);
        }
        else if(ClockWise == true)
        {
            transform.Rotate(new Vector3(0, 0, -1), WheSpeed * Time.deltaTime);
        }
    }

    // 1. 회전 멈추기
    void RotStop()
    {
        // 멈추고 있음을 알려주는 flag
        if (isStop == false && WheSpeed == BaseSpeed)
        {
            isStop = true;
            isReverse = false;          // 초기화
            Debug.Log("멈추는 중..");
        }

        // 감속
        if (isStop == true && WheSpeed > 3.0f)
        {
            WheSpeed *= 0.98f;
        }

        else if (isStop == true)
        {
            WheSpeed = 0.0f;
            isStop = false;
            isReverse = true;
            Debug.Log("멈추기 완료");
        }

    }
    
    // 2. 회전 시작하기
    void RotStart()
    {
        // 방향을 바꿔야 한다면, 방향 반대 방향으로 바꾸기
        if (isReverse == true)
        {
            Debug.Log("방향 전환");
            ClockWise = !ClockWise;
            isReverse = false;
        }

        // 가속
        if (isStop == false && WheSpeed < BaseSpeed)
        {
            Debug.Log("가속 중");
            WheSpeed = WheSpeed * 1.02f + 0.1f;
        }

        else
        {
            Debug.Log("방향 전환 완료");
            WheSpeed = BaseSpeed;
            ReverseDir = false;              // 전환 끝내는 flag
        }
    }

    // 3. 방향 전환하는 과정 한 번에 함
    void ReverseRot()
    {
        RotStop();
        StartCoroutine(RotDelay());
        
    }

    // 3. 에 대한 Coroutine
    IEnumerator RotDelay()
    {
        // WheSpeed가 0이 될 때까지 대기 >> 잘 안됨
        // yield return new WaitUntil(() => isReverse == true);

        // 확장성은 없지만 시간으로 하기
        yield return new WaitForSeconds(4.0f);
        RotStart();
    }

    // 외부로부터 입력 받기
    public void ReverseDirection()
    {   
        ReverseDir = true;
    }
}
