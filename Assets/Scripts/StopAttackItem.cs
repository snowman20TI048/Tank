using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttackItem : MonoBehaviour
{
    private GameObject[] targets;
    [SerializeField]
    private AudioClip getSound;
    [SerializeField]
    private GameObject effectPrefab;

    void Update()
    {
        // �uEnemyShotShell�v�I�u�W�F�N�g�ɁuEnemyShotShell�v�^�O��ݒ肵�Ă��������i�|�C���g�j
        targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < targets.Length; i++)
            {
                // �U����~���Ԃ��R�b���Z����i���b�ԉ��Z���邩�͎��R�j
                targets[i].GetComponent<EnemyShotShell>().AddStopTimer(10.0f);
            }

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}