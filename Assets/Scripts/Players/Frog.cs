using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Animal
{

    private float speed = 0f;
    private float jumpForceVertical = 700f;
    private float jumpForceHorizontal = 400f;

    private Animator frogAnimator;
    // Start is called before the first frame update
    private void Awake() 
    {
        gameOverScreen = GameOver.instance.gameObject;
        frogAnimator = gameObject.GetComponent<Animator>();
    }
    
    void Start()
    {
        gameOverScreen.SetActive(false);
        animalRB = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        move(speed);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            jump(jumpForceVertical);
        }
    }

    public override void jump(float jumpForce)
    {
        base.jump(jumpForce);
        animalRB.AddForce(movementDirection * jumpForceHorizontal, ForceMode.Impulse);
        frogAnimator.SetTrigger("Jump");

    }
}
