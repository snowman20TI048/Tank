using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;
    [SerializeField]
    private AudioClip getSound;
    private TankHealth th;
    private int reward = 3; // �����񕜂����邩�͎��R�I

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Find()���\�b�h�̎g�������}�X�^�[���邱��
            th = GameObject.Find("Tank").GetComponent<TankHealth>();

            // AddHP()���\�b�h���Ăяo���āu�����v��reward��^���Ă���B
            th.AddHP(reward);

            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
        }
    }
}