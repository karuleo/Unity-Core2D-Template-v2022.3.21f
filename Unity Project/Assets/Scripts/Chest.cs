using UnityEngine;

public class Chest : MonoBehaviour, Interaction
{
    [SerializeField] private bool isOpen = false;

    public void Interact()
    {
        if (isOpen) return;

        isOpen = true;
        Debug.Log("보물상자를 열었습니다!");
        // 애니메이션 재생, 아이템 획득 로직 추가
    }

    public string GetInteractPrompt()
    {
        return isOpen ? "이미 열린 상자입니다." : "상자 열기 [F]";
    }
}