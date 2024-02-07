using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
// basic class for obstacles to display a warning
{
    public enum WarningType
    {
        Warning,
        Arrow
    }

    public WarningType warningType;
    public float yOffset;
}
