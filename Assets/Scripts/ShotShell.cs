using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;

    // privateの状態でもInspector上から設定できるようにするテクニック。
    [SerializeField]
    private GameObject shellPrefab;

    [SerializeField]
    private AudioClip shotSound;

    private float timeBetweenShot = 0.75f;
    private float timer;


    public int shotCount;

    // ★追加
    [SerializeField]
    private Text shellLabel;

    // ★追加
    // 残弾数の最大値を設定する（最大値は自由）
    public int shotMaxCount = 20;

    void Start()
    {
        // ★追加
        shotCount = shotMaxCount;

        ShowshellLabel();
    }

    private void ShowshellLabel() 
    {
       
        shellLabel.text = "砲弾 : " + shotCount;
    }

    void Update()
    {
        timer += Time.deltaTime;
        // もしもSpaceキーを押したならば（条件）
        // 「Space」の部分を変更することで他のキーにすることができる（ポイント）
        if (Input.GetKeyDown(KeyCode.Space) && timer > timeBetweenShot && shotCount > 0)
        {
            shotCount -= 1;


            ShowshellLabel();


            // タイマーの時間を０に戻す。
            timer = 0.0f;

            // 砲弾のプレハブを実体化（インスタンス化）する。
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);

            // 砲弾に付いているRigidbodyコンポーネントにアクセスする。
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // forward（青軸＝Z軸）の方向に力を加える。
            shellRb.AddForce(transform.forward * shotSpeed);

            // 発射した砲弾を３秒後に破壊する。
            // （重要な考え方）不要になった砲弾はメモリー上から削除すること。
            Destroy(shell, 3.0f);

            // 砲弾の発射音を出す。
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }

    // ★追加
    // 残弾数を増加させるメソッド（関数・命令ブロック）
    // 外部からこのメソッドを呼び出せるように「public」をつける（重要ポイント）
    // この「AddShellメソッド」を「ShellItem」スクリプトから呼び出す。
    public void AddShell(int amount)
    {
        // shotCountをamount分だけ回復させる
        shotCount += amount;

        // ただし、残弾数が最大値を超えないようする。(最大値は自由に設定)
        if (shotCount > shotMaxCount)
        {
            shotCount = shotMaxCount;
        }

        // 回復をUIに反映させる。
        shellLabel.text = "砲弾：" + shotCount;
    }

}