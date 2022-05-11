using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSensetivity = 450f;
    // Start is called before the first frame update
    public Transform objectToMoveTransform ;
    
    float xRotation =  0f;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (!objectToMoveTransform) { Debug.Log("mouseLook script no obj"); return; }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;
        //mouseY = -mouseY;
     
        // up and down
        xRotation  -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //sides ==>
        objectToMoveTransform.Rotate(Vector3.up * mouseX);

    }
}
