using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public enum WarningType
    {
        Warning,
        Arrow
    }

    public WarningType warningType;
    public float yOffset;
}
