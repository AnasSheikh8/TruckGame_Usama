using System.Collections;
using System.Collections.Generic;
using DitzeGames.MobileJoystick;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Other Settings")]
    public Joystick joystick;
    public TouchField touch;
    public ThirdPersonController thirdPersonController;

    [Header("UI Stats")]
    public Button jumpButton;

    private void Start()
    {
        instance = this;
        SetupJumpButton();
    }

    private void SetupJumpButton()
    {
        jumpButton.onClick.AddListener(() => thirdPersonController.ApplyJump());
    }
}
