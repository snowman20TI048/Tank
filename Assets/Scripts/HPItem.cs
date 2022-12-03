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
    [SerializeField]
    private int reward = 5; // �����񕜂����邩�͎��R�I

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Find()���\�b�h�̎g�������}�X�^�[���邱��
            th = other.gameObject.GetComponent<TankHealth>(); // GameObject.Find("Tank").GetComponent<TankHealth>()�ł��B

            // AddHP()���\�b�h���Ăяo���āu�����v��reward��^���Ă���B
            th.AddHP(reward);

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            Destroy(gameObject);
        }
    }
}