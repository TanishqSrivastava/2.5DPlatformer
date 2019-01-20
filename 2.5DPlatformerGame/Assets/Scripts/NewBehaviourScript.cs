using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    private float moveInputX;
    private float moveInputNegatX;
    public Transform tran;
    public Rigidbody rb;
    public float fallMultiplier = 2;
    public float jumpSpeed;
    public bool isGrounded;
    private bool secondJumpAvail = false;
    public float xVel;
    public float gravity;
    public float speed;
    // Use this for initialization
    void Start()
    {

        tran = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        speed = 10;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;

        }
    }
    void Update()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        if (isGrounded == false && Input.GetKeyDown("w"))
        {


        }
        if (Input.GetKeyDown("w") && isGrounded == true)
        {
            isGrounded = false;
            rb.velocity = Vector3.up * jumpSpeed;
            secondJumpAvail = true;
        }
        else
        {
            if (Input.GetKeyDown("w")) {
                if (secondJumpAvail)
                {
                    rb.velocity = Vector3.up * jumpSpeed;
                    secondJumpAvail = false;
                }
            
            }

            
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;


        }

        moveInputX = Input.GetAxisRaw("Horizontal");
        tran.Translate(moveInputX * speed * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown("d"))
        {
            Invoke("SpeedMovement", 0.2f);

        }
        if (Input.GetKeyUp("d"))
        {
            speed = 10;


        }
        if (Input.GetKeyDown("a"))
        {
            Invoke("SpeedMovement", 0.2f);

        }
        if (Input.GetKeyUp("a"))
        {
            speed = 10;


        }




    }
    void SpeedMovement()
    {
        speed = 15;


    }
}