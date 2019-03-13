using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    public GameManager gm;
    
    public Transform Enemy;
    public bool LastEnemyAttack;
    public bool setSpeedTenOrTwenty;
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
    public bool onGroundTop;
    public bool lastEnemyAttack {
        get { return LastEnemyAttack;
        }

    }
    // Use this for initialization
    void Start()
    {
        if (Lives.CurLives == 0)
        {
            Lives.CurLives = 5;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);




        }
        lives = 5;
        gm = FindObjectOfType<GameManager>();
        
        fol = FindObjectOfType<AbhinavFollow>();
        tran = GetComponent<Transform>();
        speed = 10;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("I am noticing a ground");

        }
        if (collision.collider.tag == "PowerUpSpeed")
        {
            speed = 15;
            Invoke("ChangeBackToNormal", 5f);

        }
        if (collision.collider.tag == "PowerUpJumpBoost") {
            jumpSpeed = 15;
            Invoke("ChangeBackToNormalJumpBoost", 2f);
        }
        if (collision.collider.tag == "Enemy") {
            if (transform.position.x < collision.collider.transform.position.x)
            {
                rb.AddForce(-100000 * Time.deltaTime, 0, 0);
                Lives.CurLives--;
            }
            if (transform.position.x > collision.collider.transform.position.x)
            {
                rb.AddForce(100000 * Time.deltaTime, 0, 0);
                Lives.CurLives--;
            }

        }
        if (collision.collider.tag == "Enemy" && livesString.text == "1") {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");

        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerCameraStop") {
            fol.target = null;



        }
    }
    void FixedUpdate()
    {

        
        Debug.Log(speed);

        if (livesString.text == "1" && transform.position.y < -12.70)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");


        }
          
             
        livesString.text = Lives.CurLives.ToString();
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
           // Invoke("SpeedMovement", 0.2f);

        }
        
        if (Input.GetKeyDown("a"))
        {
           // Invoke("SpeedMovement", 0.2f);

        }
       




    }
    void Respawn() {
        // transform.position = new Vector3(-52, 2.3f, -5.42f);   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        fol.target = gameObject.transform;   //Set the target of the AbhinavFollow script back to what it was before
        Lives.CurLives--;
        // so that the player could respawn WITHOUT reloading the scene

    }
    void ChangeBackToNormal()
    {
        speed = 10;


    }
    void SpeedMovement()
    {
        speed = 15;


    }
    void ChangeBackToNormalJumpBoost() {
        jumpSpeed = 10;


    }
    
}
