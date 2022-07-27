using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Vector2 CheckGround_pos;

    GameObject CheckGround;
    
    Rigidbody2D rigid2D;

    [SerializeField] float JumpForce = 7.0f, speed = 5.0f;       // 점프할 때 주는 힘
    [SerializeField] int JumpLimit = 2;
    int JumpCount = 0;
    bool isJumpDelay = false;

    int reverse = 1;

    Animator animator;

    public bool Interaction;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // CheckGround = transform.GetChild(0).gameObject;
        // CheckGround_pos = CheckGround.transform.position;  
    }


    void Update()
    {
        MoveX();
        Jump();
        // InteractionObject();
    }

    void MoveX()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        rigid2D.velocity = new Vector2(x, rigid2D.velocity.y);

        // 화면 전환
        if (x > 0) reverse = 1;
        else if (x < 0) reverse = -1;
        transform.localScale = new Vector3(reverse, 1, 1);

        if (x != 0) animator.SetBool("PlayerWalk", true);
        else animator.SetBool("PlayerWalk", false);
    }

    void Jump() {
        // 바닥에 닿으면 초기화
        if (isGround())
        {
            JumpCount = 0;
            animator.SetBool("PlayerJumpDown", false);
            animator.SetBool("PlayerJump", false);
        }

        // 조건에 맞고 스페이즈바 누르면 점프
        if (isJumpDelay == false && JumpLimit > JumpCount && Input.GetKeyDown(KeyCode.Space))  {

            // 애니매이션
            if (rigid2D.velocity.y == 0)
            {
                animator.SetBool("PlayerJump", true);
                animator.SetBool("PlayerJumpDown", false);
                StartCoroutine(JumpAnimationDelay());
            }
            // 착륙 중일 때 애니매이션 실행
            else if (rigid2D.velocity.y > 0)
            {
                animator.SetBool("PlayerJumpDown", true);
            }

            // 점프 구현
            isJumpDelay = true;
            JumpCount++;
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, JumpForce);
            Debug.Log(JumpCount);
            StartCoroutine(JumpDelay());
        }
    }
    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(0.3f);
        isJumpDelay = false;
    }

    // 점프 애니매이션 관련 Coroutine
    IEnumerator JumpAnimationDelay()
    {
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("PlayerJumpDown", true);
    }

    bool isGround() {
        if (rigid2D.velocity.y == 0)
            return true;
        else
            return false;
        // return Physics2D.OverlapCircle()...
    }

    /*
    public void InteractionObject()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Interaction = true;
            Debug.Log("상호작용 발생");
            StartCoroutine(InteractionDelay());
        }
    }

    IEnumerator InteractionDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Interaction = false;
        Debug.Log("상호작용 끝");
    }
    */
}
