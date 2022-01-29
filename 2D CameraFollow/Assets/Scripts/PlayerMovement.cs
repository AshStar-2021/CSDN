using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidB;
    private Animator myAnim;
    //public GameObject roomIn;//存储玩家在哪个房间

    private float speedX, speedY;
    // Start is called before the first frame update
    void Start()
    {
        myRigidB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
            speedX = Input.GetAxisRaw("Horizontal");
            speedY = Input.GetAxisRaw("Vertical");
            Vector2 input = new Vector2(speedX, speedY).normalized;
            myRigidB.velocity = input * speed;

            if (input != Vector2.zero)
            {
                myAnim.SetBool("IsMoving", true);
                myAnim.SetFloat("SpeedX", speedX);
                myAnim.SetFloat("SpeedY", speedY);
            }
            else
            {
                myAnim.SetBool("IsMoving", false);
            }
        }
   
}
