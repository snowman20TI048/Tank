using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // ���̃��\�b�h�̓R���C�_�[���m���Ԃ������u�ԂɌĂяo�����
    private void OnTriggerEnter(Collider other)
    {
        // �������Ԃ����������Tag��Shell�Ƃ������O�������Ă������Ȃ�΁i�����j
        if (other.CompareTag("Shell"))
        {
            // ���̃X�N���v�g�����Ă���I�u�W�F�N�g��j�󂷂�ithis�͏ȗ����\�j
            Destroy(this.gameObject);

            // �Ԃ����Ă����I�u�W�F�N�g��j�󂷂�
            // other���ǂ��ƌq�����Ă��邩�l���Ă݂悤�I
            Destroy(other.gameObject);
        }
    }
}