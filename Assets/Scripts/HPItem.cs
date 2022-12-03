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
    private int reward = 5; // いくつ回復させるかは自由！

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Find()メソッドの使い方をマスターすること
            th = other.gameObject.GetComponent<TankHealth>(); // GameObject.Find("Tank").GetComponent<TankHealth>()でも可。

            // AddHP()メソッドを呼び出して「引数」にrewardを与えている。
            th.AddHP(reward);

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            Destroy(gameObject);
        }
    }
}