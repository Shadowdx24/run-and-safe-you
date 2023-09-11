using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    
    [SerializeField] private float speed;
    
    [SerializeField] GameObject Winscene;
    
    [SerializeField] GameObject Losescene;

    private float a1;
    
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        move();
        //win();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over!");
            //player.gravityScale*=-1;
            lose();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            Debug.Log("You Win!");
            win();
            
        }
    }
    
    private void win()
    {
        Winscene.SetActive(true);
        Time.timeScale = 0f;
       
    }
    private void lose()
    {
        Losescene.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
            //Application.Quit();
            Debug.Log("Exit");
        
    }
    public void Restart()
    {
        Debug.Log("Star Game");
    }
}
