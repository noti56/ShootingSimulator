using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
  
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public static void  HandleSceneChange(string sceneName) {
        Debug.Log(sceneName+ " sceneName");
            Cursor.lockState = CursorLockMode.Locked;
        if (!sceneName.Equals( "Menu"))
        {
            Debug.Log(sceneName + " wtf");
        }
        SceneManager.LoadScene(sceneName);
  
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            Debug.Log("Pause");
            goToPause();
        }
        
    }

    public static void goToPause()
    {
        HandleSceneChange("Menu");
    }
}
