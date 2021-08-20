using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cam;
    public CharacterController controller;

    public Animator Idle;

    public float speed = 10f;

    public float turnSmoothTime = 0.1f; // this will help the player turn smothly
    float TurnSmoothVelocity; // the velocity in wich the pleyer turns

  /*  //jump + double jump
    public bool onGround = true; //helps the double jump ( to know if it touched the ground).
    private Rigidbody Rb;

    //Double Jump
    private const int MAX_JUMP = 2; //the max jumps it can do at a time 
    private int currentJump = 0; //how many jumps has he done*/

    private void Start()
    {

        Idle = gameObject.GetComponent<Animator>();


    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) // used to chech if we are moving to any direction. magnitude returns the LENGTH of the vector
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //Atan2() is an inbuilt Math class method which returns the angle whose tangent is the quotient of two specified numbers.
            //Basically, it returns an angle to θ

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //makes it so that when you turn the character, it will be a smooth transition


            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //this makes the camera follow wherever the player is facing 
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }


      /*  //double jump 
        if (Input.GetButtonDown("Jump") && (onGround || MAX_JUMP > currentJump))
        {
            Rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onGround = false;
            currentJump++;
        }*/
    }

  /*  private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            onGround = true;
            currentJump = 0;
        }
    }*/
}
