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
        if (Input.GetKeyDown (KeyCode.E)) {
                var go = FindClosestObjectWithTag ("student");
                if (go != null) {
                        GameObject.Destroy (go);
                        gameHandlerObj.AddScore(1);
                }
                
        }
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

        

    public GameObject FindClosestObjectWithTag(string tagName)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tagName);
        GameObject closest = null;
        float distance = 3;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}