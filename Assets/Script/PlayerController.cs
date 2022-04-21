using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterCon;
    public bool mouseVisibility;
    [SerializeField] private bool interaction = false;//Ongoing Interaction
    [SerializeField] private float movementSpeed = 4f;
    [SerializeField] private float additionalSpeed = 2f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float sensitivity = 3f;
    private float verticalMovement = 0f;
    private float horizontalMovement = 0f;
    private float currentHeight = 0f;
    private float mouseVertical = 0f;
    private float mouseHorizontal = 0f;
    private float mouseVerticalRange = 90f;
    static int bufer = 1;
    private void Awake()
    {
        characterCon = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (!MouseController.ShowStatus()) KeyboardController();
        if (!MouseController.isInventoryOpen) MouseControllerr();
    }
    private void KeyboardController()
    {
        verticalMovement = Input.GetAxis("Vertical") * movementSpeed;
        horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        if (Input.GetButton("Jump") && characterCon.isGrounded)
        {
            currentHeight = jumpHeight;
        }
        else if (!characterCon.isGrounded)
        {
            currentHeight += Physics.gravity.y * Time.deltaTime;
        }

        if (Input.GetButtonDown("Run"))
        {
            movementSpeed += additionalSpeed;
        }
        else if (Input.GetButtonUp("Run"))
        {
            movementSpeed -= additionalSpeed;
        }
        Vector3 move = new Vector3(horizontalMovement, currentHeight, verticalMovement);
        move = transform.rotation * move;
        characterCon.Move(move * Time.deltaTime);
    }

    private void MouseControllerr()
    {
        mouseVertical -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseHorizontal = Input.GetAxis("Mouse X") * sensitivity;

        transform.Rotate(0f, mouseHorizontal, 0f);
        mouseVertical = Mathf.Clamp(mouseVertical, -mouseVerticalRange, mouseVerticalRange);
        Camera.main.transform.localRotation = Quaternion.Euler(mouseVertical, 0f, 0f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Geometry"&&other.tag != "Player")
        {
            interaction = true;
        }
        else
        {
            interaction = false;
        }
    }

    public void SetSpeed(float speed)
    {
        movementSpeed = speed;
    }
    public float GetSpeed()
    {
        return movementSpeed;
    }
}
