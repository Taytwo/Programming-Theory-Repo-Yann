using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public GameObject gameOverScreen;
    public float inputHorizontal;
    public float inputVertical;
    public Rigidbody animalRB;

    public bool isOnGround;

    public Vector3 movementDirection;

    public virtual void move(float speed)
    {
        //get inputs
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        //set movement
        movementDirection = new Vector3 (inputHorizontal, 0 , inputVertical);
        movementDirection.Normalize();
        transform.Translate(movementDirection * Time.deltaTime * speed, Space.World);

        //set direction of the player
        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }

        //keep the player inside the camera view
        Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    public virtual void jump(float jumpForce)
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
            GameManager.instance.SaveHighScore();
            gameOverScreen.gameObject.SetActive(true);
            GameManager.instance.isGameActive = false;
        }
    }
}
