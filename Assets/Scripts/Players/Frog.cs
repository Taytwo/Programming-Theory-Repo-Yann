using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Frog : Animal
{

    private float speed = 0f;
    private float jumpForceVertical = 700f;
    private float jumpForceHorizontal = 400f;

 
    // Start is called before the first frame update
    private void Awake() 
    {
        gameOverScreen = GameOver.instance.gameObject;
    }
    
    void Start()
    {
        gameOverScreen.SetActive(false);
        animalRB = GetComponent<Rigidbody>(); 
        animator = gameObject.GetComponent<Animator>();
        lossParticle = GameObject.Find("LossParticle").GetComponent<ParticleSystem>();
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

    //POLYMORPHISM
    public override void jump(float jumpForce)
    {
        base.jump(jumpForce);
        animalRB.AddForce(movementDirection * jumpForceHorizontal, ForceMode.Impulse);
    }
}
