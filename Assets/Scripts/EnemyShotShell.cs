using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;
    [SerializeField]
    private GameObject enemyShellPrefab;
    [SerializeField]
    private AudioClip shotSound;
    private int timer;
    [SerializeField]
    private int interval;

    // ���ǉ�
    // ���b�Ԓ�~�����邩�͎��R
    public float stopTimer = 5.0f;

    // ���ǉ�
    [SerializeField]
    private Text stopLabel;


    void Update()
    {
        timer += 1;

        // ���ǉ�
        stopTimer -= Time.deltaTime;
        // �^�C�}�[��0�����ɂȂ�����A0�Ŏ~�߂�B
        if (stopTimer < 0)
        {
            stopTimer = 0;
        }

        // ���ǉ�
        stopLabel.text = "" + stopTimer.ToString("0"); // �����_�ȉ��͐؂�̂�

        if (timer % interval == 0 && stopTimer <= 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forward��Z�������i�������j�E�E�E�����̕����ɗ͂�������B
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);  //AudioSource.PlayClipAtPoint(�w�肵������, �w�肵���ʒu�ŗ���)

            Destroy(enemyShell, 3.0f);
        }
    }

    // ���ǉ�
    // �G�̍U�����X�g�b�v�����郁�\�b�h�iTimer�̎��Ԃ𑝉������邱�ƂōU���̒�~���Ԃ�L�΂��j
    // �i�l�����jHP�𑝉�������A�C�e�����Ɠ���
    // ���̃A�C�e���𕡐��擾����ƁA���ꂾ���U����~���Ԃ��u���Z�v�����B
    public void AddStopTimer(float amount)
    {
        stopTimer += amount;

        // ���ǉ�
        stopLabel.text = "" + stopTimer.ToString("0");
    }

    

}