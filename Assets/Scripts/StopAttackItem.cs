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
    [SerializeField]
    private float stopTime = 10.0f;

    void Update()
    {
        // 「EnemyShotShell」オブジェクトに「EnemyShotShell」タグを設定してください（ポイント）
        targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");  //GameObject.FindGameObjectsWithTag("EnemyShotShell");によって、"EnemyShotShellのタグを持つゲームオブジェクトを配列に入れる。
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < targets.Length; i++)
            {
                // 攻撃停止時間を10秒加算する（何秒間加算するかは自由）
                targets[i].GetComponent<EnemyShotShell>().AddStopTimer(stopTime);
            }
     
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 0.5f);
        }
    }
}