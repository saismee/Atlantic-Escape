using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    private float blinkTime;

    private void Update()
    {
        blinkTime += Time.deltaTime;
        if (blinkTime < 1f) return;
        blinkTime = 0f;


    }
}
