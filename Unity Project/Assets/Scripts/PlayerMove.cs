using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerStats stats;
    private float moveX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        // A(-1), D(+1) 키 입력만 감지 (W, S 및 화살표 위/아래 무시)
        moveX = Input.GetAxisRaw("Horizontal");

        // 입력 방향에 따라 캐릭터 이미지 좌우 반전
        if (moveX > 0)
            transform.localScale = new Vector3(1, 1, 1);   // 오른쪽 바라보기
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1);  // 왼쪽 바라보기
    }

    private void FixedUpdate()
    {
        // PlayerStats에서 장비/장신구 증감이 모두 계산된 최종 이동 속도(moveSpeed.Value) 적용
        rb.velocity = new Vector2(moveX * stats.moveSpeed.Value, 0f);
    }
}