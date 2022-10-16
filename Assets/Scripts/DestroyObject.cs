using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;


    // このメソッドはコライダー同士がぶつかった瞬間に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかった相手のTagにShellという名前が書いてあったならば（条件）
        if (other.CompareTag("Shell"))
        {
            // このスクリプトがついているオブジェクトを破壊する（thisは省略が可能）
            Destroy(this.gameObject);

            // ぶつかってきたオブジェクトを破壊する
            // otherがどこと繋がっているか考えてみよう！
            Destroy(other.gameObject);


            // エフェクトを実体化（インスタンス化）する。
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);


            // エフェクトを２秒後に画面から消す
            Destroy(effect, 2.0f);



        }
    }
}