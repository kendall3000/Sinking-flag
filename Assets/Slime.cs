using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int health = 3;
    [SerializeField] float speed = 0f;
    [Header("Flavor")]
    [SerializeField] string slimeName = "Rimiru";
    [Header("Tracked Data")]
    [SerializeField] Vector3 homePostion = Vector3.zero;

    [SerializeField] GameObject box;
    Rigidbody2D rb;

    public enum SlimeMovementType{tf, physics};

    [SerializeField] SlimeMovementType movementType = SlimeMovementType.tf;
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log(health);

       rb = GetComponent<Rigidbody2D>();
       SpriteRenderer sr = box.GetComponent <SpriteRenderer>();
       sr.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
      // moveSlime(new Vector3(-1,-1,0));
    }

    public void moveSlime(Vector3 direction)
    {
        
        //rb.velocity = direction * speed;
        rb.AddForce(direction * speed);

    }

    public void moveSlimeRb(Vector3 direction)
    {


    }

    public void moveSlimeTransform(Vector3 direction){
        transform.position += direction * Time.deltaTime * speed;
    }
}
