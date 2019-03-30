using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public float EnemySpeed;
    public bool turnRight;
    public bool turnLeft;
    public bool startThisShit;
    // Start is called before the first frame update
    void Start()
    {
         
        turnRight = true;
        turnLeft = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (turnRight == true && turnLeft == false && collider.tag == "EnemyZoneRight") {
            turnLeft = true;
            turnRight = false;

        }
        if (turnLeft == true && turnRight == false && collider.tag == "EnemyZoneLeft")
        {
            turnLeft = false;
            turnRight = true;
        }
       
    }
   
    // Update is called once per frame
    void Update()
    {
       
       
        if (turnRight == true && turnLeft == false)
        {
            transform.Translate(1 * EnemySpeed * Time.deltaTime, 0, 0);
           
            
            


        }
        else if (turnLeft == true && turnRight == false) {

            transform.Translate(-1 * EnemySpeed * Time.deltaTime, 0, 0);
           
            
            
        }
       
        
    }
}
