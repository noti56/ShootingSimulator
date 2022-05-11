using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject[] enemiesArr;

    private void OnEnable()
    {
        PlayerContoller.OnDeathEvent += loseGame;
    }
    private void OnDisable()
    {
        PlayerContoller.OnDeathEvent -= loseGame;
    }


    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;


    }

    void loseGame()
    {

        StartCoroutine(restartingGameByTime());
        


    }



    int getEnemiesArrLength() {
        return GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(getEnemiesArrLength() == 0)
        {
            Debug.Log("Killed all enemies");
        }



    }

    IEnumerator restartingGameByTime()
    {

        
        yield return new WaitForSeconds(3);
        MenuManager.goToPause();
    }



}
