using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    public AbhinavFollow fol;
    public Text livesString;
    public float lives;       // livesString will be converted to float to be stored in this variable
    // Use this for initialization
    void Start()
    {
        lives = 5;
        fol = FindObjectOfType<AbhinavFollow>();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerCameraStop") {
            fol.target = null;



        }
    }
    void Update()
    {
        if (livesString.text == "1" && transform.position.y < -12.70) {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
            

        }
        livesString.text = lives.ToString();
        if (transform.position.y < -12.73) {       // Respawning whenever the character 
            Respawn();                                       // reaches a certain point on the -y axis 


        }
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
    void Respawn() {
        transform.position = new Vector3(-52f, 2.3f, -5.42f);   
        fol.target = gameObject.transform;   //Set the target of the AbhinavFollow script back to what it was before
        lives--;                             // so that the player could respawn WITHOUT reloading the scene

    }
    void SpeedMovement()
    {
        speed = 15;


    }
}
