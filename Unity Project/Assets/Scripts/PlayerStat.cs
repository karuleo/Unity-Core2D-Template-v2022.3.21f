using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Move Settings")]
    public Stat moveSpeed; // 이동 속도

    [Header("DFS Settings")]
    public Stat defense;      // 방어력 

    [Header("Roll Settings")]
    public float rollSpeed;      // 구르기 속도
    public float rollDuration;   // 구르기 지속 시간
    public float rollCooldown;   // 쿨타임

    [Header("ATK Settings")]
    public Stat attackPower;
}