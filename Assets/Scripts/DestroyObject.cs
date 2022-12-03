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

    // ������
    // �z��̒�`�E�E�E�������̃f�[�^�����邱�Ƃ̂ł��锠�̍쐬
    [SerializeField]
    private GameObject[] itemPrefabs;

    // ���ǉ�
    [SerializeField]
    private int scoreValue;  // ���ꂪ�G��|���Ɠ�����_���ɂȂ�
    private ScoreManager sm;

    // ���ǉ�
    void Start()
    {
        // �uScoreLabel�I�u�W�F�N�g�v�ɕt���Ă���uScoreManager�X�N���v�g�v�̏����擾���āusm�v�̔��ɓ����B
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }



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
            else
            {
                Destroy(other.gameObject);

                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);
                Destroy(this.gameObject);

                // ���ǉ�
                // �A�C�e�������u3�v�̏ꍇ�AitemNumber�̒��ɂ́u0�v�u1�v�u2�v�̂����ꂩ�̐���������B
                int itemNumber = Random.Range(0, itemPrefabs.Length);

                Vector3 pos = transform.position;

                // ������
                if (itemPrefabs.Length != 0)
                {
                    // �i�|�C���g�jitemNumber�̐����ɂ���ďo��A�C�e�����ω�����B
                    Instantiate(itemPrefabs[itemNumber], new Vector3(pos.x, pos.y + 0.6f, pos.z), Quaternion.identity);

                    // ���ǉ�
                    sm.AddScore(scoreValue);
                }
            }
        }
    }
}