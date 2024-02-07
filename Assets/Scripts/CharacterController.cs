using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Tooltip("How fast the character can move")]
    public float moveSpeed;

    private Vector2 moveVector;

    private Vector2 punishment;

    public void Punish(Vector2 amount)
    // modifies the player's velocity - quickly drops off
    {
        punishment += amount;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        punishment = Vector2.Lerp(punishment, Vector2.zero, 1 - Mathf.Pow(0.03f, Time.deltaTime));
        moveVector = Vector2.Lerp(
            moveVector,
            new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized,
            1 - Mathf.Pow(0.9f, Time.deltaTime * 60f)
        );
        // might remove normalized as its an arcade game and we dont really care if they move faster if its more fun
        // should support controllers


        float horizontalLimit = (Camera.main.orthographicSize * Screen.width / Screen.height) - 0.75f;
        float verticalLimit = Camera.main.orthographicSize - 0.75f;

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -horizontalLimit - 2f, horizontalLimit),
            Mathf.Clamp(transform.position.y, -verticalLimit, verticalLimit)
        );
        // limits the player's movement to within the screen bounds, except on the left side

        if (transform.position.x < -horizontalLimit - 1f) GameManager.GameOver();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed - punishment;
        rb.rotation = moveVector.y * 15f;
        // makes the player look wobbly when moving
    }
}
