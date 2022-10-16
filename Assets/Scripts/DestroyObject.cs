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


    // このメソッドはコライダー同士がぶつかった瞬間に呼び出される
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
            else // ★★追加  そうでない場合（HPが0以下になった場合）には（条件）
            {
                Destroy(other.gameObject);

                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);
                Destroy(this.gameObject);
            }
        }
    }
}