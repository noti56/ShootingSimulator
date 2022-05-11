using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class uiManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string youDeadText= "Hey u dead!";
    [SerializeField] UnityEngine.UI.Text textGameObj;

    private void OnEnable()
    {
        PlayerContoller.OnDeathEvent += displayDeathText;
    }
    private void OnDisable()
    {
        PlayerContoller.OnDeathEvent -= displayDeathText;
    }

    void Start()
    {
        
    }

    void displayDeathText() {
        Debug.Log("dddeead");
     
        
            Canvas canvas = GetComponent<Canvas>();
        textGameObj.text = youDeadText;
           

    }
    
    void Update()
    {
        
        
    }
}
