using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x > -30f) return;
        Destroy(gameObject);
    }
}
