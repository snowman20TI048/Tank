using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab1;
    [SerializeField]
    private GameObject effectPrefab2;
    public int tankHP;

    [SerializeField]
    private AudioListener mainListener;


    [SerializeField]
    private Text HPLabel;

    void Start()
    {
        HPLabel.text = "HP:" + tankHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        // �������Ԃ����Ă��������Tag���hEnemyShell�h�ł������Ȃ�΁i�����j
        if (other.gameObject.tag == "EnemyShell")
        {
            // HP���P������������B
            tankHP -= 1;

            HPLabel.text = "HP:" + tankHP;

            // �Ԃ����Ă���������i�G�̖C�e�j��j�󂷂�B
            Destroy(other.gameObject);

            if (tankHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // �v���[���[��j�󂷂�B
                // Destroy(gameObject);


                // ���ǉ�
                // �v���[���[��j�󂹂��ɉ�ʂ��猩���Ȃ�����i�|�C���g�E�e�N�j�b�N�j
                // �v���[���[��j�󂷂�ƁA���̎��_�Ń������[�ォ�������̂ŁA�ȍ~�̃R�[�h�����s����Ȃ��Ȃ�B
                mainListener.enabled = true; // �I���ɂ���
                this.gameObject.SetActive(false);
               

                // ���ǉ�
                // 1.5�b��ɁuGoToGameOver()�v���\�b�h�����s����B
                Invoke("GoToGameOver", 1.5f);

            }
        }
    }

    // ���ǉ�
    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
