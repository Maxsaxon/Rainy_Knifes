using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed = 3f; // f adds decimal point value

    private bool canMove = true;

    private string horizontalAxis = "Horizontal";
    private string Knife_Tag = "Knife";

    
    private SpriteRenderer sr; // It is better to use Scale when your player has a weapons, etc with him instead of using flip
    private Animator playerAnim;
    private string Walk_Animation_Parameter = "Walk";

    [SerializeField]
    private float min_X = 0f, max_X = 0f;

    //private int timer = 5;
    void Awake() // more optimized for getting component than start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }
    
    void Start() // initialization function
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Move();
      PlayerBounds();
    }

    void Move()
    {
        if (!canMove) // ! symbol means we test opposite value of variable
            return;

        float h = Input.GetAxisRaw(horizontalAxis);
        Vector2 tempPos = transform.position;
        Vector2 tempScale = transform.localScale;

        if(h > 0)
        {  
            tempPos.x += movementSpeed * Time.deltaTime; 
            sr.flipX = false;

            playerAnim.SetBool(Walk_Animation_Parameter, true);
        }
        else if(h < 0)
        {
            tempPos.x -= movementSpeed * Time.deltaTime;
            sr.flipX = true;

           playerAnim.SetBool(Walk_Animation_Parameter, true);

        }
        else
        {
            playerAnim.SetBool(Walk_Animation_Parameter, false);
        }
        transform.position = tempPos;
        
    }

    void PlayerBounds() 
    {
        Vector2 tempPos = transform.position;

        if (tempPos.x > max_X) 
            tempPos.x = max_X; // means we don't allow player to move outside of created bounds
        
        else if (tempPos.x < min_X) // we don't put brackets, because of having same value of tempPos, have one line of code in functions
        
            tempPos.x = min_X;
        

        transform.position = tempPos;
    }

    IEnumerator RestartGame() // coroutine
    {
        yield return new WaitForSecondsRealtime(2f); // we are using real time instead of scale time
        Time.timeScale = 1f;

        SceneManager.LoadScene("GamePlay"); // pass the name of a scene you want to restart
    }

    void OnTriggerEnter2D(Collider2D collision) // if player collides with knifes
    {
        if (collision.CompareTag(Knife_Tag))
        {
            Time.timeScale = 0f;
            canMove = false;

            StartCoroutine(RestartGame());
        }
    }

}
