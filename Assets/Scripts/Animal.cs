using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody animalRB;
    private Vector3 moveInput;

    private bool isOnGround;
    public float speedTest = 10f;
    public float jumpTest = 700f;
    
    // Start is called before the first frame update
    void Start()
    {
        animalRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        move(speedTest);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            jump(jumpTest);
        }
    }

    public void move(float speed)
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * inputHorizontal);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * inputVertical);
    }

    public void jump(float jumpForce)
    {
        isOnGround = false;
        animalRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Car")
        {
            Destroy(gameObject);
        }
    }
}
