using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer : MonoBehaviour
{
    Player playerScript;
    //StageManager stageManager;
    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = (Player)FindObjectOfType(typeof(Player));
        //stageManager = (StageManager)FindObjectOfType(typeof(StageManager));
        uiManager = (UIManager)FindObjectOfType(typeof(UIManager));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") 
        {
            playerScript.randomizeNumber();
            //stageManager.InstantiateStages();
            uiManager.addScore();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
