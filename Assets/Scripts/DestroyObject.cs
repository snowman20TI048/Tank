using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private GameObject effectPrefab2; // 2��ޖڂ̃G�t�F�N�g�����邽�߂̔�
    public int objectHP;


    // ���̃��\�b�h�̓R���C�_�[���m���Ԃ������u�ԂɌĂяo�����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            // �����ǉ�
            // �I�u�W�F�N�g��HP���P������������B
            objectHP -= 1;

            // �����ǉ�
            // ������HP��0�����傫���ꍇ�ɂ́i�����j
            if (objectHP > 0)
            {
                Destroy(other.gameObject);


                GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);


            }
            else // �����ǉ�  �����łȂ��ꍇ�iHP��0�ȉ��ɂȂ����ꍇ�j�ɂ́i�����j
            {
                Destroy(other.gameObject);

                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);
                Destroy(this.gameObject);
            }
        }
    }
}