using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumController : MonoBehaviour
{
    [SerializeField] float angle = 0;
    [SerializeField] float speed = 2f;
    [SerializeField] float StartAngle = 0;      // 정확한 단위는 연구 필요!

    private float lerpTime = 0;

    private void Awake()
    {
        lerpTime += StartAngle;        
    }

    private void Update()
    {
        lerpTime += Time.deltaTime * speed;
        transform.rotation = CalculateMovementOfPendulum();
    }

    Quaternion CalculateMovementOfPendulum()
    {
        return Quaternion.Lerp(Quaternion.Euler(Vector3.forward * angle),
            Quaternion.Euler(Vector3.back * angle), GetLerpTParam());
    }

    float GetLerpTParam()
    {
        return (Mathf.Sin(lerpTime) + 1) * 0.5f;
    }
}
