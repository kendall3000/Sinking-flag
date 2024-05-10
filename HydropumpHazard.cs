using UnityEngine;

public class HydropumpHazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Assuming you have a method in your player's script to handle death
            collision.GetComponent<Kiko>().GameOver();
        }
    }
}
