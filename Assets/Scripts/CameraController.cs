using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Camera FPSCamera;
    private bool mainCameraON = true;

    // ★追加
    [SerializeField]
    private AudioListener mainListener;
    [SerializeField]
    private AudioListener FPSListener;

    void Start()
    {
        mainCamera.enabled = true;
        FPSCamera.enabled = false;

        // ★追加
        mainListener.enabled = true; // オンにする
        FPSListener.enabled = false; // オフにする
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && mainCameraON == true)
        {
            mainCamera.enabled = false;
            FPSCamera.enabled = true;
            mainCameraON = false;

            // ★追加
            mainListener.enabled = false; // オフにする
            FPSListener.enabled = true; // オンにする
        }
        else if (Input.GetKeyDown(KeyCode.C) && mainCameraON == false)
        {
            mainCamera.enabled = true;
            FPSCamera.enabled = false;
            mainCameraON = true;

            // ★追加
            mainListener.enabled = true; // オンにする
            FPSListener.enabled = false; // オフにする
        }
    }
}