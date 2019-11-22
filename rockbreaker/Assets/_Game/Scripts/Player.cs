using System;
using UnityEngine;
using EZCameraShake;

public class Player : MonoBehaviour
{
    public static Player player;
    private bool isDead = false;

    private void Awake()
    {
        player = this;
    }

    private void Update()
    {
        if (isDead)
        {
            Utils.RestartLevel();
        }
    }

    public void TakeDamage(int dmg)
    {
        CameraShaker.Instance.ShakeOnce(5.0f, 1f, 0.3f, 0.3f);
        PlayerStats.score -= dmg;
        isDead = PlayerStats.score < 0;
    }
}