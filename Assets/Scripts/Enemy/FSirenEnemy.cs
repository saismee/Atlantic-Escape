using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSirenEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject[] notes;

    public Transform target;

    private float timeSinceLastAttack;
    [SerializeField] private float attackCooldown;

    private void Start()
    {
        timeSinceLastAttack = attackCooldown * 2f;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3((Camera.main.orthographicSize * Screen.width / Screen.height) - 1f, target.position.y + Mathf.Sin(Time.time) * 2f, 0);
        rb.velocity = Vector3.ClampMagnitude(targetPosition - transform.position, 1f) * moveSpeed;

        timeSinceLastAttack -= Time.deltaTime;
        if (timeSinceLastAttack > 0f) return;
        timeSinceLastAttack = attackCooldown + 2.25f;
        Attack();
    }

    public void Attack()
    {
        StartCoroutine(ThrowNote());
    }

    private IEnumerator ThrowNote()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newNote = Instantiate(notes[Random.Range(0, notes.Length)]);
            newNote.transform.position = transform.position;

            Rigidbody2D noteRb = newNote.GetComponent<Rigidbody2D>();
            noteRb.velocity = new Vector3(target.position.x - transform.position.x, 5, 0);
            noteRb.angularVelocity = Random.Range(-40f, 40f);

            yield return new WaitForSeconds(0.75f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        //GameManager.GameOver();
    }
}
