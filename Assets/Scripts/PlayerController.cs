using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSmoothTime;
    private float turnSmoothVelocity;
    private Transform cameraTransform;
    [SerializeField] private float gravity ;
    [SerializeField] private float airFriction;
    [SerializeField] private float groundFriction;
    private Vector3 actualVelocity;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;
    [SerializeField] private GameObject useSkin;
    [SerializeField] private GameObject jumpSkin;
    private List<GameObject> listOfSkin = new List<GameObject>();

    private int characterColor = 0; //0 = Color for Use ; 1 = Color for Jump




    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        listOfSkin.Add(useSkin);
        listOfSkin.Add(jumpSkin);
        SwitchColor(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (characterColor == 1)
        {
            Jump();
        }
        TotalMovement();
    }

    private Vector3 PlayerMovement()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        Vector3 directionWOCam = new Vector3(horizontalAxis, 0f, verticalAxis).normalized;

        if (directionWOCam.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(directionWOCam.x, directionWOCam.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            return moveDirection.normalized * moveSpeed * Time.deltaTime;
        }
        else return Vector3.zero;
    }

    private bool CheckGround()
    {
        bool isOnGround;
        isOnGround = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        return isOnGround;
    }


    private void Jump()
    {
        if (Input.GetButtonDown("Use") && CheckGround())
        {
            actualVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private Vector3 Gravity()
    {
        actualVelocity.y += gravity * Time.deltaTime;


        if (CheckGround() && actualVelocity.y < 0)
        {
            actualVelocity.y = -2f;
        }

        return actualVelocity * Time.deltaTime;

    }

    private void TotalMovement()
    {
        Vector3 actualMovement;
        if (CheckGround())
        {
            actualMovement = PlayerMovement() * groundFriction + Gravity() ;

        }
        else
        {
            actualMovement = PlayerMovement() * airFriction + Gravity() ;
        }
        characterController.Move(actualMovement);
    }

    private void SwitchColor(int colorToSwitchTo)
    {
        for (int i = 0; i < listOfSkin.Count; i++)
        {
            if (i == colorToSwitchTo)
            {
                listOfSkin[i].SetActive(true);
            }
            else
            {
                listOfSkin[i].SetActive(false);
            }
        }
    }

    public void SetcharacterColor(int newColor)
    {
        if (characterColor != newColor)
        {
            
        }
        characterColor = newColor;
        SwitchColor(newColor);
    }

    public int GetcharacterColor()
    {
        return characterColor;
    }
}
