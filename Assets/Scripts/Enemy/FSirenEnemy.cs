using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSirenEnemy : BaseEnemy
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [Tooltip("How fast this enemy moves")]
    [SerializeField] private float moveSpeed;

    [Tooltip("A list of projectiles to throw randomly")]
    [SerializeField] private GameObject[] notes;

    //public Transform target;
    // we inherit this from BaseEnemy

    private float timeSinceLastAttack;
    [Tooltip("Time in seconds between attacks")]
    [SerializeField] private float attackCooldown;

    private float timeSinceLastMovement;
    [Tooltip("Time in seconds before this enemy swaps sides")]
    [SerializeField] private float movementCooldown;

    private float posX;

    private void Start()
    {
        // i chose to double the cooldown to give the player time to process an enemy spawning
        timeSinceLastAttack = attackCooldown * 2f;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(posX, target.position.y + Mathf.Sin(Time.time) * 2f, 0);
        rb.velocity = Vector3.ClampMagnitude(targetPosition - transform.position, 1f) * moveSpeed;

        HandleMovementSwitching();
        HandleAttacking();
        // these are looped with a variable and deltatime
    }

    private void HandleMovementSwitching()
    {
        spriteRenderer.flipX = transform.position.x < target.position.x;
        // flip the X if the enemy is on the left of the target

        timeSinceLastMovement -= Time.deltaTime;
        if (timeSinceLastMovement > 0f) return; // guard clause to reduce nesting
        timeSinceLastMovement = movementCooldown;

        posX = ( ( Camera.main.orthographicSize * Screen.width / Screen.height ) - 1f ) * ( Random.Range( 0, 2 ) - 0.5f ) * 2f;
        // this wil position the character 1 unit away from either edge of the screen, determined by ^^ this random range
    }

    private void HandleAttacking()
    {
        timeSinceLastAttack -= Time.deltaTime;
        if (timeSinceLastAttack > 0f) return; // guard clause to reduce nesting
        timeSinceLastAttack = attackCooldown + 2.25f;
        Attack();
    }

    // allows other code to begin the attack sequence easily
    public void Attack()
    {
        StartCoroutine(ThrowNote());
        // start the attack sequence
    }

    private IEnumerator ThrowNote()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newNote = Instantiate(notes[Random.Range(0, notes.Length)]);
            newNote.transform.position = transform.position;
            // clone a random note

            Rigidbody2D noteRb = newNote.GetComponent<Rigidbody2D>();
            noteRb.velocity = new Vector3(target.position.x - transform.position.x, 6, 0); // launch the note towards the player
            noteRb.angularVelocity = Random.Range(-40f, 40f); // makes the note spin slightly

            yield return new WaitForSeconds(0.75f);
            // this IEnumerator method makes the note throwing much easier as it will wait between throws
        }
    }
}
