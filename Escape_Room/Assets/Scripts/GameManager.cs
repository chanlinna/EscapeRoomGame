using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool HasKey = false;

    public static bool CheckForKeyStatus()
    {
        return HasKey;
    }
}