using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public GameHandler gameHandlerObj;
    
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start(){
         if (GameObject.FindWithTag("GameHandler") != null){ 
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
          }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }
    
    void FixedUpdate()
    {
        Move();
    }
    
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D other){
          if (other.gameObject.tag == "enemy"){
               Destroy(other.gameObject);
               gameHandlerObj.AddScore(1);
          }
     }
}