using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class Player : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    int randMove;
    int xSpeed = 15;
    int ySpeed = -1;

    UIManager uiManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        uiManager = (UIManager)FindObjectOfType(typeof(UIManager));
        randomizeNumber();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        GetInput();
    }

    public void MovePlayer() 
    {
        if(randMove <= 5) 
        {
            rb.AddForce(new Vector2(xSpeed, ySpeed));
        }
        else
        {
            rb.AddForce(new Vector2(-xSpeed, ySpeed));
        }
    }
    void GetInput() 
    {
        if (Input.GetMouseButton(0)) 
        {
            if(randMove <= 5) 
            {
                rb.AddForce(new Vector2(-xSpeed * 3, 0));
            }
            else 
            {
                rb.AddForce(new Vector2(xSpeed * 3, 0));
            }
        }
    }

    public int randomizeNumber() 
    {
        randMove = Random.Range(1, 10);
        Debug.Log("Move Code: " + randMove);
        return randMove;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall") 
        {
            endGame();
        }
        if (other.gameObject.tag == "Changer")
        {
            randomizeNumber();
        }
    }

    public void endGame() 
    {
        player.SetActive(false);
        uiManager.GameOver();
    }

}
