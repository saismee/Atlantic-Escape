using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;

    [Tooltip("Scales the knockback this projectile inflicts")]
    public float power = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
        // easiest way to remove the projectile without polling
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;
        collider.gameObject.GetComponent<CharacterController>().Punish( ( transform.position - collider.transform.position ).normalized * ( rb.velocity.magnitude * power ) );
        // apply a force on the player to knock them away from this projectile
        Destroy(this);
        // make sure they don't hit it multiple times - this only deletes the script component

        //GameManager.GameOver();
    }
}
