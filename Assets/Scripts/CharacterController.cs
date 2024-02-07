using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;

    private Vector2 moveVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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

        if (transform.position.x < -horizontalLimit - 1f)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
        rb.rotation = moveVector.y * 15f;
    }
}
