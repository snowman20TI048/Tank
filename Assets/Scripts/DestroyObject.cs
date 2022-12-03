using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private GameObject effectPrefab2; // 2種類目のエフェクトを入れるための箱
    public int objectHP;

    // ★改良
    // 配列の定義・・・＞複数のデータを入れることのできる箱の作成
    [SerializeField]
    private GameObject[] itemPrefabs;

    // ★追加
    [SerializeField]
    private int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;

    // ★追加
    void Start()
    {
        // 「ScoreLabelオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            // ★★追加
            // オブジェクトのHPを１ずつ減少させる。
            objectHP -= 1;

            // ★★追加
            // もしもHPが0よりも大きい場合には（条件）
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

                // ★追加
                // アイテム数が「3個」の場合、itemNumberの中には「0」「1」「2」のいずれかの数字が入る。
                int itemNumber = Random.Range(0, itemPrefabs.Length);

                Vector3 pos = transform.position;

                // ★改良
                if (itemPrefabs.Length != 0)
                {
                    // （ポイント）itemNumberの数字によって出るアイテムが変化する。
                    Instantiate(itemPrefabs[itemNumber], new Vector3(pos.x, pos.y + 0.6f, pos.z), Quaternion.identity);

                    // ★追加
                    sm.AddScore(scoreValue);
                }
            }
        }
    }
}