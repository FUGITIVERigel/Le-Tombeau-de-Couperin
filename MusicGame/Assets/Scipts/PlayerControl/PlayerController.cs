using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]public Rigidbody2D rb;
    [HideInInspector]public Collider2D coll;
    [HideInInspector]public PlayerInput Input;
    [HideInInspector]public GameObject player;
    [HideInInspector]public GroundCheck groundCheck;
    public float moveSpeed;
    public bool isGround=>groundCheck.isGround;
    public void Awake(){
        rb=GetComponent<Rigidbody2D>();
        coll=GetComponent<Collider2D>();
        Input=GetComponent<PlayerInput>();
        player=transform.GetChild(0).gameObject;
        groundCheck=GetComponentInChildren<GroundCheck>();
    }
    public void Start(){
        Input.EnableGamePlayInput();
    }
    public void MoveX(float speedX){
        rb.velocity=new Vector2(speedX,rb.velocity.y);
        Flip();
    }
    public void MoveY(float speedY){
        rb.velocity=new Vector2(rb.velocity.x,speedY);
    }
    public void Move(Vector2 velocity){
        rb.velocity = velocity;
        Flip();
    }
    public void Flip(){
        if(Input.MoveX!=0){
            player.transform.localScale=new Vector3(Input.MoveX,1,1);
        }
    }

    #region Run
    public void Run(float speed){
        MoveX(speed * Input.MoveX);
        Flip(); 
    }
    #endregion
}
