using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public Sprite carryingSprite;
    public Sprite normalSprite;
    private SpriteRenderer spriteRenderer;
        public GameHandler gameHandlerObj;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("GameHandler") != null){ 
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandlerObj.getPlayerCarryingBody()){
            spriteRenderer.sprite = carryingSprite;
        } else {
            spriteRenderer.sprite = normalSprite;
        }
    }
}
