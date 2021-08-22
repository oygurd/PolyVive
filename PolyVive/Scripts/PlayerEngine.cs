using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine : MonoBehaviour
{
    //movement
    float x;
    float z;
    float speed;
    
    //jump + double jump
    public bool onGround = true; //helps the double jump ( to know if it touched the ground).
    private Rigidbody Rb;

    //Double Jump
    private const int MAX_JUMP = 2; //the max jumps it can do at a time 
    private int currentJump = 0; //how many jumps has he done

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;

        Rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //movement
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(x, 0, z);

        //double jump 
        if (Input.GetButtonDown("Jump") && (onGround || MAX_JUMP > currentJump))
        {
            Rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onGround = false;
            currentJump++;
        }
       // onGround = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            onGround = true;
            currentJump = 0;
        }
    }
}
