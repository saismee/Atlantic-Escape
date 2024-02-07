using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    private float blinkTime;
    private SpriteRenderer spriteRenderer;
    private float blinkSpeed = 0.75f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        blinkTime += Time.deltaTime;
        spriteRenderer.enabled = blinkTime % blinkSpeed > blinkSpeed / 2f;
        
        if (blinkTime > 2.5f / GameManager.Instance.difficulty)
        {
            Destroy(gameObject);
        }
    }
}
