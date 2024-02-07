using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void Collide(Collision2D collision)
    {
        collision.transform.position -= new Vector3(3f * GameManager.Instance.difficulty * Time.deltaTime, 0, 0);
        // prevent the player from phasing through everything at high difficulty
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collide(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Collide(collision);
    }
}
