using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMovement : MonoBehaviour
{
    public float moveInputX;
    public Rigidbody rb;
    public float moveInputY;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");
        transform.Translate(moveInputX * 10 * Time.deltaTime, 0, moveInputY * 10 * Time.deltaTime);
        
    }
}
