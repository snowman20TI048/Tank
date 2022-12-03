using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private Vector3 angle;
    private AudioSource audioS;

    void Start()
    {
        // Turret�̍ŏ��̊p�x���擾����B
        angle = transform.eulerAngles;

        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ���蓖�Ă�{�^���i�L�[�j�͎��R�ɕύX�\
        if (Input.GetKey(KeyCode.P))
        {
            audioS.enabled = true;

            angle.x -= 0.5f;

            // �i�|�C���g�j�e�́u����p�x�v�ɍ��킹��̂��utransform.root.eulerAngles.y�v�̕���
            transform.eulerAngles = new Vector3(angle.x, transform.root.eulerAngles.y, 0);

            // �ړ��ł���p�x�ɐ�����������B
            if (angle.x < 70)
            {
                angle.x = 70;
            }
        }
        else if (Input.GetKey(KeyCode.L))
        {
            audioS.enabled = true;
            angle.x += 0.5f;
            transform.eulerAngles = new Vector3(angle.x, transform.root.eulerAngles.y, 0);

            if (angle.x > 90)
            {
                angle.x = 90;
            }
        }
        else
        {
            audioS.enabled = false;
        }
    }
}