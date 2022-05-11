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

    public void HandleSceneChange(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            Debug.Log("Pause");
            HandleSceneChange("Menu");
        }
        
    }
}
