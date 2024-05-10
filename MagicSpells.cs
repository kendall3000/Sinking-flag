using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpells : MonoBehaviour
{
    public float speed = 5f;
    public float range = 10f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Vector3.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject); // Destroy the spell after reaching its range
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destroy enemy on hit
            Destroy(gameObject); // Destroy the spell
        }
    }
}
