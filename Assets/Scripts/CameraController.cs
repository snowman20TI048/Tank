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

    // ���ǉ�
    [SerializeField]
    private AudioListener mainListener;
    [SerializeField]
    private AudioListener FPSListener;

    // ���ǉ�
    [SerializeField]
    private GameObject aimImage;


    void Start()
    {
        mainCamera.enabled = true;
        FPSCamera.enabled = false;

        // ���ǉ�
        mainListener.enabled = true; // �I���ɂ���
        FPSListener.enabled = false; // �I�t�ɂ���

        // ���ǉ�
        // �i���z�j��σJ�����iFPS�J�����j���I���̎������A�Ə�����I���ɂ���B
        aimImage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && mainCameraON == true)
        {
            mainCamera.enabled = false;
            FPSCamera.enabled = true;
            mainCameraON = false;

            mainListener.enabled = false; // �I�t�ɂ���
            FPSListener.enabled = true; // �I���ɂ���

            // ���ǉ�
            aimImage.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.C) && mainCameraON == false)
        {
            mainCamera.enabled = true;
            FPSCamera.enabled = false;
            mainCameraON = true;

            // ���ǉ�
            mainListener.enabled = true; // �I���ɂ���
            FPSListener.enabled = false; // �I�t�ɂ���

            // ���ǉ�
            aimImage.SetActive(false);
        }
    }
}