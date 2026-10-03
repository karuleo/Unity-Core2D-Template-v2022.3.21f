using UnityEngine;
using TMPro;

public class InteractText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText; // 화면에 표시할 UI 텍스트
    [SerializeField] private GameObject uiPanel;         // UI 전체를 켜고 끌 패널

    private void Start()
    {
        Hide();
    }

    // 상호작용 안내 텍스트 표시
    public void Show(string message)
    {
        uiPanel.SetActive(true);
        promptText.text = message;
    }

    // 감지 범위에서 벗어나면 UI 숨김
    public void Hide()
    {
        uiPanel.SetActive(false);
    }
}