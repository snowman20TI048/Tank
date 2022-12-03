using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellItem : MonoBehaviour
{
    [SerializeField]
    private AudioClip getSound;
    [SerializeField]
    private GameObject effectPrefab;
    private ShotShell ss;
    private int reward = 5; // �e���������񕜂����邩�͎��R�Ɍ���

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // �i�d�v�|�C���g�j
            // Find()���\�b�h�́A�u���O�v�ŃI�u�W�F�N�g��T�����肵�܂��B
            // �uShotShell�v�I�u�W�F�N�g��T���o���āA����ɕt���Ă���uShotShell�v�X�N���v�g�icomponent�j�̃f�[�^���擾�B
            // �擾�����f�[�^���uss�v�̔��̒��ɓ����B
            ss = other.gameObject.transform.GetChild(3).gameObject.GetComponent<ShotShell>(); //GameObject.Find("ShotShell").GetComponent<ShotShell>()

            //  ShotShell�X�N���v�g�̒��ɋL�ڂ���Ă���uAddShell���\�b�h�v���Ăяo���B
            // reward�Őݒ肵�����l�������e�����񕜂���B
            ss.AddShell(reward);

            // �A�C�e���Q�b�g�����o���B
            AudioSource.PlayClipAtPoint(getSound, transform.position);

            // �A�C�e���Q�b�g���ɃG�t�F�N�g�𔭐�������B
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            // �G�t�F�N�g��0.5�b��ɏ����B
            Destroy(effect, 0.5f);

            // �A�C�e������ʂ���폜����B
            Destroy(gameObject);
        }
    }
}