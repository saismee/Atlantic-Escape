using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Tooltip("How far this object moves compared to its parent (1 is equal, 0 is not at all)")]
    [SerializeField] private float parallaxScale;
    private int offset;
    private float yOffset;

    private void Start()
    {
        yOffset = transform.position.y;
        // keep the initial offset so the layers can be repositioned in the editor
    }

    private void Update()
    {
        transform.position = transform.parent.position * parallaxScale + new Vector3(90 * offset, yOffset, 0);
        if (transform.position.x < -45)
        {
            offset += 1;
            // how many tiles this layer should be offset. the number is based on the size of the background.
        }
    }
}
