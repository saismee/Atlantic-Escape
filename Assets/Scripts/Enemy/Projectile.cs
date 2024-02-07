using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float punishment = 3f;
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;
        collider.gameObject.GetComponent<CharacterController>().Punish(punishment);
        //GameManager.GameOver();
    }
}
