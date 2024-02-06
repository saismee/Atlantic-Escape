using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxScale;
    private int offset;
    private float yOffset;

    private void Start()
    {
        yOffset = transform.position.y;
    }

    private void Update()
    {
        transform.position = transform.parent.position * parallaxScale + new Vector3(90 * offset, yOffset, 0);
        if (transform.position.x < -45)
        {
            offset += 1;
        }
    }
}
