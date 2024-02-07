using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScrolling : MonoBehaviour
{
    [Tooltip("How fast the map moves at 1 difficulty")]
    public float scrollSpeed;

    private void Update()
    {
        transform.position += new Vector3(-Mathf.Abs(scrollSpeed) * Time.deltaTime * GameManager.Instance.difficulty, 0, 0);
        // this determines how quickly obstacles pass the player.
    }
}
