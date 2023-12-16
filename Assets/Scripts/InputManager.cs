using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    public Joystick joystickMove;
    public Joystick joystickLook;
    public Button buttonInteract;
    public Button buttonRun;
    public Button buttonJump;
    

    // Start is called before the first frame update
    void Start()
    {
        //saber si el tamaño de la pantalla chica, quite el joystick
        // joystickMove = GameObject.Find("Fixed Joystick Move").GetComponent<Joystick>();
        // joystickLook = GameObject.Find("Fixed Joystick Look").GetComponent<Joystick>();
        // buttonInteract = GameObject.Find("Inreactable").GetComponent<Button>();
        // buttonRun = GameObject.Find("Run").GetComponent<Button>();
        // buttonJump = GameObject.Find("Jump").GetComponent<Button>();
        // Debug.Log(Screen.width);
        // if (Screen.width <= 1536)
        // {
        //     joystickMove.gameObject.SetActive(true);
        //     joystickLook.gameObject.SetActive(true);
        //     buttonInteract.gameObject.SetActive(true);
        //     buttonRun.gameObject.SetActive(true);
        //     buttonJump.gameObject.SetActive(true);
        // }else{
        //     joystickMove.gameObject.SetActive(false);
        //     joystickLook.gameObject.SetActive(false);
        //     buttonInteract.gameObject.SetActive(false);
        //     buttonRun.gameObject.SetActive(false);
        //     buttonJump.gameObject.SetActive(false);
        // }   
    }
    
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        
        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Crouch.performed += ctx => motor.Crouch();

        onFoot.Sprint.performed += ctx => motor.Sprint();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Tell the playermotor to move using the values from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>().x, onFoot.Movement.ReadValue<Vector2>().y);
        // motor.ProcessMove(joystickMove.Horizontal, joystickMove.Vertical);
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>().x, onFoot.Look.ReadValue<Vector2>().y);
        // look.ProcessLook(joystickLook.Horizontal, joystickLook.Vertical);
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
    public void Jump()
    {
        motor.Jump();
    }
    public void Crouch()
    {
        motor.Crouch();
    }
    public void Sprint()
    {
        motor.Sprint();
    }
}