using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonController : MonoBehaviour
{
    [Header("Camera Settings")]
    public bool LockCameraPosition = false;
    public float _cinemachineTargetYaw;
    public float _cinemachineTargetPitch;
    public float touchSpeed;
    public float TopClamp = 70.0f;
    public float BottomClamp = -30.0f;
    public float CameraAngleOverride = 0.0f;
    public GameObject CinemachineCameraTarget;
    public float smoothTouch;
    private const float _threshold = 0.01f;

    [Header("Player Movement")]
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    private Animator animator;
    private float turnSmoothVelocity;
    private CharacterController characterController;
    private float smoothAnimation;

    [Header("Gravity Settings")]
    public float gravity;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask groundMask;
    public float jumpHeight;
    private bool isGrounded;
    private Vector3 velocity;

    [Header("Input Settings")]
    public bool mobileInput;
    private float horizontal;
    private float vertical;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        PlayerMovement();
        ApplyGravity();

        if (Input.GetKeyDown(KeyCode.Space) && !mobileInput)
        {
            ApplyJump();
        }
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    private void PlayerMovement()
    {
        //apply movement
        if (mobileInput)
        {
            horizontal = GameManager.instance.joystick.AxisNormalized.x;
            vertical = GameManager.instance.joystick.AxisNormalized.y;
        }
        else
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + CinemachineCameraTarget.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //apply animation
        smoothAnimation = Mathf.Lerp(smoothAnimation, direction.magnitude, 0.1f);
        animator.SetFloat("speed", smoothAnimation);
    }

    private void ApplyGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        animator.SetBool("ground", isGrounded);
    }

    public void ApplyJump()
    {
        if (isGrounded)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Movement") || animator.GetCurrentAnimatorStateInfo(0).IsName("land"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                animator.SetTrigger("jump");
            }
        }
    }

    private void CameraRotation()
    {
        if (mobileInput)
        {
            if (GameManager.instance.touch.TouchDist.sqrMagnitude >= _threshold && !LockCameraPosition)
            {
                _cinemachineTargetYaw += GameManager.instance.touch.TouchDist.x * touchSpeed * Time.deltaTime;
                _cinemachineTargetPitch += -GameManager.instance.touch.TouchDist.y * touchSpeed * Time.deltaTime;
            }
        }

        else
        {
            touchSpeed = 100;
            _cinemachineTargetYaw += Input.GetAxis("Mouse X") * touchSpeed * Time.deltaTime;
            _cinemachineTargetPitch += -Input.GetAxis("Mouse Y") * touchSpeed * Time.deltaTime;  
        }
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        Quaternion angle = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride, _cinemachineTargetYaw, 0.0f);

        CinemachineCameraTarget.transform.rotation = Quaternion.Slerp(CinemachineCameraTarget.transform.rotation, angle, smoothTouch);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}
