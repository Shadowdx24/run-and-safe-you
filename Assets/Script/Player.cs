using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    
    [SerializeField] private float speed;
    
    [SerializeField] GameObject Winscene;
    
    [SerializeField] GameObject Losescene;

    [SerializeField] GameObject ChooseInputscene;

    private bool moveUp=false;
    private bool moveDown=false;
    private bool moveLeft=false;
    private bool moveRight=false;
    private bool useKeyboardInput=true;
    // Start is called before the first frame update
    
    void Start()
    {
        chooseInput();
    }

    // Update is called once per frame
    
    void Update()
    {
        if (useKeyboardInput)
        {
            checkKeyBoardInput();
        }

        move();
        //win();
    }
    
    private void move()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (moveLeft)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (moveUp)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (moveDown)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }

    private void checkKeyBoardInput()
    {
        if (Input.GetAxis("Horizontal")>0) 
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            moveUp = true;
        }
        else
        {
            moveUp = false;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            moveDown = true;
        }
        else
        {
            moveDown = false;
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

    private void chooseInput()
    {
        ChooseInputscene.SetActive(true);
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
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void buttonInput()
    {
        Debug.Log("Star Game");
        useKeyboardInput = false;
        ChooseInputscene.SetActive(false);
        Time.timeScale = 1f;
    }

    public void keyBoardInput()
    {
        Debug.Log("Star Game");
        useKeyboardInput = true;
        ChooseInputscene.SetActive(false);
        Time.timeScale = 1f;
    }


    public void level2()
    {
        Debug.Log("Level 2");
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    //public void level3()
    //{
    //    Debug.Log("Level 3");
    //    SceneManager.LoadScene(2);
    //    Time.timeScale = 1f;
    //}

    public void moveRightInputEnter()
    {
        moveRight = true;
    }
    public void moveRightInputExit()
    {
        moveRight=false;
    }

    public void moveLeftInputEnter()
    {
         moveLeft = true;
    }
    public void moveLeftInputExit()
    {
        moveLeft = false;
    }
    public void moveUpInputEnter()
    {
        moveUp = true;
    }
    public void moveUpInputExit()
    {
        moveUp = false;
    }
    public void moveDownInputEnter()
    {
        moveDown = true;
    }
    public void moveDownInputExit()
    {
        moveDown = false;
    }

}
