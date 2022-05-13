using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : Animal
{

    private float speed = 14f;
    private float jumpForce = 0f;
    // Start is called before the first frame update
    private void Awake() 
    {
        gameOverScreen = GameOver.instance.gameObject;
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
    }
}
