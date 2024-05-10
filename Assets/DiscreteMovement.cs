using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    void Start()
    {
        if (moveSpeed <= 0)
        {
            Debug.LogError("Move speed should be greater than 0.");
            moveSpeed = 1f;
        }
    }

    public void ReceiveInput(Vector2 inputDirection)
    {
        Move(inputDirection);
    }

    void Move(Vector2 inputDirection)
    {
        Vector2 targetPosition = (Vector2)transform.position + inputDirection * moveSpeed;

        StartCoroutine(MoveToTarget(targetPosition));
    }

    IEnumerator MoveToTarget(Vector2 targetPosition)
    {
        while ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
