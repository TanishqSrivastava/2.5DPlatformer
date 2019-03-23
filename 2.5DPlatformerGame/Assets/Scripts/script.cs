using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float RandomSide;
    public bool changeSpeed;
    public Rigidbody rbOfPowerup;
    public NewBehaviourScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        RandomSide = Random.Range(1, 2);
        Debug.Log(RandomSide);
        rbOfPowerup = GetComponent<Rigidbody>();
        playerScript = FindObjectOfType<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {




        if (RandomSide == 1)
        {

            rbOfPowerup.AddForce(-750 *Time.deltaTime, 0, 0);
        }else if (RandomSide == 2)
        {

            rbOfPowerup.AddForce(750 *Time.deltaTime, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") {
            Destroy(gameObject);
            

        }

    }
    
}
