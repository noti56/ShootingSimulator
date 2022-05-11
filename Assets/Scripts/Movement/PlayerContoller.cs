using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed = 10;
    [SerializeField] int time = 2;
    [SerializeField] float playerHeight = 2 ;
    [SerializeField] float crouchHeight = 1;
    [SerializeField] Animator anim;
    public float jumpPower = 10;
    public Transform camera;
    public GameObject gun;
    public GameObject leftHand;
    public float leftHandHoldXRotation = -158.788f;
    //public float leftHandHoldXPos = -158.788f;
    public GameObject rightHand;
    public bool isHoldingRight = false;
    public bool isJumping = false;
    public bool isActive = true;
    
    public Rigidbody rb;



    public delegate void OnDeath();
    public static OnDeath OnDeathEvent;
    public delegate void OnMovement(Transform playerTransform);
    public static OnMovement OnPlayerMovementEvent;


    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        getInput();

    }

    private void FixedUpdate()
    {

    }

    void getInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isHoldingRight = true;
            StartCoroutine(aimGun());

        }
        if (Input.GetButtonUp("Fire2")) { StopCoroutine(aimGun()); anim.SetBool("AimGun", false); }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        /*float mouseVertical = Input.GetAxis("Mouse X");
        float mouseHorizontal = Input.GetAxis("Mouse Y");
        
        camera.transform.Rotate( mouseHorizontal, mouseVertical , 0);*/
        transform.Translate(normlaizeMovement(horizontal), 0, normlaizeMovement(vertical));

        OnPlayerMovementEvent?.Invoke(gameObject.transform);

        if (Input.GetButtonDown("Jump") && !isJumping) {
            //transform.Translate(0,jumpPower, 0);
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
            OnPlayerMovementEvent?.Invoke(gameObject.transform);
        }
        if (Input.GetButtonDown("Crouch") ) {

            handleCrouch(crouchHeight);
            
        }
        if (Input.GetButtonUp("Crouch"))
        {

            handleCrouch(playerHeight);
        }


    }

   
    private void handleCrouch(float height)
    {
        Debug.Log("handleCrouch");
        GetComponent<CapsuleCollider>().height = height;
            OnPlayerMovementEvent?.Invoke(gameObject.transform);

    }

    private void retrieveGun()
    {
        if (!leftHand || !rightHand || !gun) return;
        //  xvar vec = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        gun.transform.localRotation = Quaternion.Euler(0,0,0);


    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor") {
            if(isJumping)
            {
                OnPlayerMovementEvent?.Invoke(gameObject.transform);
            }
            isJumping = false;
        }
   
            
            if (collision.gameObject.tag == "bullet")
            {
                Debug.Log("bullet hit player");
            OnDeathEvent?.Invoke();
            
            }
        
    }


    float normlaizeMovement(float number ) {
        return number * Time.deltaTime * playerSpeed;

    }



    IEnumerator aimGun()
    {
        if (leftHand && rightHand && gun && anim)
        {
            anim.SetBool("AimGun", true);
            Debug.Log("aim gun");

        //var vec = new Vector3(Screen.width / 2, Screen.height / 2, 0);
          // gun.transform.localRotation = Quaternion.Euler(camera.position.x, camera.forward.y,0f);
            //gun.transform.Rotate(vec);

        }
        yield return new WaitForSeconds(time);
        // do stuff
    }

}
