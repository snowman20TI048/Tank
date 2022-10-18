using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 offset;

    void Start()
    {
        // �J�����ƃ^�[�Q�b�g�̍ŏ��̈ʒu�֌W�i�����j���擾����B
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        if (target != null)
        {
            // �ŏ��Ɏ擾�����ʒu�֌W�𑫂����Ƃŏ�Ɉ��̋������ێ�����i�|�C���g�j
            transform.position = target.transform.position + offset;
        }
    }
}