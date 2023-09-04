using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();   
    }
    private void move()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}
