using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static bool CheckTimer(float current, float cooldown)
    {
        return current >= cooldown;
    }
}
