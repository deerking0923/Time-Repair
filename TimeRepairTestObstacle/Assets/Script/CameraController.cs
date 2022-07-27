using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    float CameraZ = -10;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // 프레임 상관 없이 출력
    void FixedUpdate()
    {
        Vector3 TargetPos = new Vector3(Player.transform.position.x, Player.transform.position.y, CameraZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 3f);
    }
}
