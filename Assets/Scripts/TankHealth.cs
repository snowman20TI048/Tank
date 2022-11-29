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

    // ���ǉ�
    // HP�̍ő�l��ݒ肷��i�ő�l�͎��R�j
    public int tankMaxHP = 5;

    void Start()
    {
        // ���ǉ�
        tankHP = tankMaxHP;

        ShowHPLabel();
    }

    private void ShowHPLabel() //������g���R�[�h�̓��\�b�h������
    {
        HPLabel.text = "HP : " + tankHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        // �������Ԃ����Ă��������Tag���hEnemyShell�h�ł������Ȃ�΁i�����j
        if (other.gameObject.tag == "EnemyShell")
        {
            // HP���P������������B
            tankHP -= 1;

            ShowHPLabel();

            // �Ԃ����Ă���������i�G�̖C�e�j��j�󂷂�B
            Destroy(other.gameObject);

            if (tankHP > 0) //���@�̗̑͂��O��葽���ꍇ
            {
                GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity); // Instantiate(�����������Q�[���I�u�W�F�N�g, ��������ꏊ, ��]���邩�ۂ�(Vecter3�^�̏ꍇ�͕K���K�v))
                Destroy(effect1, 1.0f);
            }
            else //���@�̗̑͂��O�ȉ��̏ꍇ
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // �v���[���[��j�󂷂�B
                // Destroy(gameObject);


                // �v���[���[��j�󂹂��ɉ�ʂ��猩���Ȃ�����i�|�C���g�E�e�N�j�b�N�j
                // �v���[���[��j�󂷂�ƁA���̎��_�Ń������[�ォ�������̂ŁA�ȍ~�̃R�[�h�����s����Ȃ��Ȃ�B
                mainListener.enabled = true; // �I���ɂ���
                this.gameObject.SetActive(false);  //�����Ȃ�����
               

                // ���ǉ�
                // 1.5�b��ɁuGoToGameOver()�v���\�b�h�����s����B
                Invoke("GoToGameOver", 1.5f);

            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // ���ǉ�
    // public�����邱�Ɓi�d�v�|�C���g�j
    public void AddHP(int amount)
    {
        tankHP += amount;

        // �����͉����R���g���[�����Ă���l���Ă݂܂��傤�I
        if (tankHP > tankMaxHP)
        {
            tankHP = tankMaxHP;
        }

        HPLabel.text = "HP:" + tankHP;
    }

}
