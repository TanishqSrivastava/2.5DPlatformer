using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public bool changeSpeed;
    public Rigidbody rbOfPowerup;
    public NewBehaviourScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        rbOfPowerup = GetComponent<Rigidbody>();
        playerScript = FindObjectOfType<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        

          


        
        rbOfPowerup.AddForce(-500 * Time.deltaTime, 0, 0);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") {
            Destroy(gameObject);
            

        }

    }
    
}
