using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftOrRight : MonoBehaviour
{
    private float speed = 20f;
    private float xBound = 45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.x > xBound || transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
    }
}
