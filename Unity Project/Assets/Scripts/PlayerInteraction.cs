using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private Transform interactionPoint; // 상호작용 감지 지점
    [SerializeField] private float interactionRadius = 1.5f; // 감지 반경
    [SerializeField] private LayerMask interactableLayer; // 상호작용 레이어

    [Header("UI Reference")]
    [SerializeField] private InteractionUI interactionUI;

    private Interactable currentInteractable;

    private void Update()
    {
        DetectInteractable();
        HandleInput();
    }

    // 감지 범위 내의 가장 가까운 상호작용 오브젝트 탐색
    private void DetectInteractable()
    {
        Vector2 point = interactionPoint != null ? interactionPoint.position : transform.position;
        Collider2D collider = Physics2D.OverlapCircle(point, interactionRadius, interactableLayer);

        if (collider != null && collider.TryGetComponent(out IInteractable interactable))
        {
            // 새로운 오브젝트를 감지했거나 대상이 변경된 경우
            if (currentInteractable != interactable)
            {
                currentInteractable = interactable;
                
                interactionUI.Show(currentInteractable.GetInteractPrompt());
            }
            return;
        }

        // 범위 내에 오브젝트가 없으면 UI를 숨기고 초기화
        if (currentInteractable != null)
        {
            currentInteractable = null;
            if (interactionUI != null)
            {
                interactionUI.Hide();
            }
        }
    }

    // 입력 처리
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentInteractable.Interact();

            if (interactionUI != null)
            {
                interactionUI.Show(currentInteractable.GetInteractPrompt());
            }
        }
    }

    // 기즈모
    private void OnDrawGizmosSelected()
    {
        Vector2 point = interactionPoint != null ? interactionPoint.position : transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(point, interactionRadius);
    }
}