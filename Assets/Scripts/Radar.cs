using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // �uOnTriggerStay�v�̓g���K�[�����̃R���C�_�[�ɐG��Ă���Ԓ����s����郁�\�b�h�i�|�C���g�j
    private void OnTriggerStay(Collider other)
    {
        // ���������̃I�u�W�F�N�g�ɁuPlayer�v�Ƃ���Tag�i�^�O�j���t���Ă����Ȃ�΁i�����j
        if (other.CompareTag("Player"))
        {
            // �uroot�v���g���Ɓu�e�i�ŏ�ʂ̐e�j�v�̏����擾���邱�Ƃ��ł���i�|�C���g�j
            // LookAt()���\�b�h�͎w�肵�������ɃI�u�W�F�N�g�̌�������]�����邱�Ƃ��ł���i�|�C���g�j
            transform.root.LookAt(target);
        }
    }
}