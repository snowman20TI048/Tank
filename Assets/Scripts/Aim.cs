using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �ǉ����܂��傤�i�|�C���g�j
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    [SerializeField]
    private Image aimImage;

    void Update()
    {
        // ���[�U�[�iray�j���΂��u�N�_�v�Ɓu�����v
        Ray ray = new Ray(transform.position, transform.forward);

        // �����ǉ��i���[�U�[�����������邱�Ƃ��ł���j
        Debug.DrawRay(transform.position, transform.forward * 60, Color.green);


        // ray�̂����蔻��̏������锠�����B
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 60))
        {
            string hitName = hit.transform.gameObject.tag;

            if (hitName == "Enemy")
            {
                // �Ə���̐F���u�ԁv�ɕς���i�F�͎��R�ɕύX���Ă��������B�j
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                // �Ə���̐F���u���F�v�i�F�͎��R�ɕύX���Ă��������B�j
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            // �Ə���̐F���u���F�v�i�F�͎��R�ɕύX���Ă��������B�j
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}