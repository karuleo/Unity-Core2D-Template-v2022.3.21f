public interface Interactable
{
    // 상호작용 실행
    void Interact();
    
    // UI에 표시할 상호작용 프롬프트 텍스트 (예: "대화하기 [E]", "열기 [E]")
    string GetInteractPrompt();
}