using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public int playerSpeed = 10;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
	
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    void PlayerMove(){
        //CONTROlS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("jump")){
            Jump();
        }
            
        //ANIMATIONS
         //PLAYER DIRECTION
       if (moveX < 0.0f && facingRight == false){
            FlipPlayer();
        }
       else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
      
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);  
    }

    void Jump() {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }
    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localscale = gameObject.transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }

}


