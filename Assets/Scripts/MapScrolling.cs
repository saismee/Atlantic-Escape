using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScrolling : MonoBehaviour
{
    public float scrollSpeed;

    private void Update()
    {
        transform.position += new Vector3(-Mathf.Abs(scrollSpeed) * Time.deltaTime, 0, 0);
        /*if (transform.position.x < -45f)
        {
            transform.position += new Vector3(90f, 0, 0);
        }*/
    }
}
