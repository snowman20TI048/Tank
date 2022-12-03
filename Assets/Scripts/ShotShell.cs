using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;

    // private�̏�Ԃł�Inspector�ォ��ݒ�ł���悤�ɂ���e�N�j�b�N�B
    [SerializeField]
    private GameObject shellPrefab;

    [SerializeField]
    private AudioClip shotSound;

    private float timeBetweenShot = 0.75f;
    private float timer;


    public int shotCount;

    // ���ǉ�
    [SerializeField]
    private Text shellLabel;

    // ���ǉ�
    // �c�e���̍ő�l��ݒ肷��i�ő�l�͎��R�j
    public int shotMaxCount = 20;

    void Start()
    {
        // ���ǉ�
        shotCount = shotMaxCount;

        ShowshellLabel();
    }

    private void ShowshellLabel() 
    {
       
        shellLabel.text = "�C�e : " + shotCount;
    }

    void Update()
    {
        timer += Time.deltaTime;
        // ������Space�L�[���������Ȃ�΁i�����j
        // �uSpace�v�̕�����ύX���邱�Ƃő��̃L�[�ɂ��邱�Ƃ��ł���i�|�C���g�j
        if (Input.GetKeyDown(KeyCode.Space) && timer > timeBetweenShot && shotCount > 0)
        {
            shotCount -= 1;


            ShowshellLabel();


            // �^�C�}�[�̎��Ԃ��O�ɖ߂��B
            timer = 0.0f;

            // �C�e�̃v���n�u�����̉��i�C���X�^���X���j����B
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);

            // �C�e�ɕt���Ă���Rigidbody�R���|�[�l���g�ɃA�N�Z�X����B
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // forward�i����Z���j�̕����ɗ͂�������B
            shellRb.AddForce(transform.forward * shotSpeed);

            // ���˂����C�e���R�b��ɔj�󂷂�B
            // �i�d�v�ȍl�����j�s�v�ɂȂ����C�e�̓������[�ォ��폜���邱�ƁB
            Destroy(shell, 3.0f);

            // �C�e�̔��ˉ����o���B
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }

    // ���ǉ�
    // �c�e���𑝉������郁�\�b�h�i�֐��E���߃u���b�N�j
    // �O�����炱�̃��\�b�h���Ăяo����悤�Ɂupublic�v������i�d�v�|�C���g�j
    // ���́uAddShell���\�b�h�v���uShellItem�v�X�N���v�g����Ăяo���B
    public void AddShell(int amount)
    {
        // shotCount��amount�������񕜂�����
        shotCount += amount;

        // �������A�c�e�����ő�l�𒴂��Ȃ��悤����B(�ő�l�͎��R�ɐݒ�)
        if (shotCount > shotMaxCount)
        {
            shotCount = shotMaxCount;
        }

        // �񕜂�UI�ɔ��f������B
        shellLabel.text = "�C�e�F" + shotCount;
    }

}