using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRoll : MonoBehaviour
{
    // 외부(적 공격, 가시 등)에서 참조할 무적 상태 프로퍼티
    public bool IsInvincible { get; private set; } = false;

    private Rigidbody2D rb;
    private bool isRolling = false;
    private bool canRoll = true;
    private Vector2 rollDirection;
    private PlayerStat stats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        // 구르는 중에는 새로운 입력 및 방향 전환을 막음
        if (isRolling) return;

        // 구르기 키 입력 (쿨타임 미적용 상태일 때만)
        if (Input.GetKeyDown(KeyCode.LeftShift) && canRoll)
        {
            StartCoroutine(RollRoutine());
        }
    }

    private void FixedUpdate()
    {
        // 구르는 중에는 구르기 방향과 속도로 고정 이동
        if (isRolling)
        {
            rb.velocity = stats.rollDirection * stats.rollSpeed;
            return;
        }
    }

    private IEnumerator RollRoutine()
    {
        canRoll = false;
        isRolling = true;
        IsInvincible = true; // 무적 시작

        // 적 레이어와의 충돌 무시 처리 (필요시 사용)
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);

        // 구르기 지속 시간 동안 대기
        yield return new WaitForSeconds(stats.rollDuration);

        // 구르기 종료 및 무적 해제
        isRolling = false;
        IsInvincible = false;

        // 적 충돌 무시 해제
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);

        // 쿨타임 대기 (구르기 시간을 뺀 나머지 쿨타임 계산)
        yield return new WaitForSeconds(stats.rollCooldown);
        canRoll = true;
    }
}