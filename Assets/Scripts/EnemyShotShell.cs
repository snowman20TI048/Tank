using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;
    [SerializeField]
    private GameObject enemyShellPrefab;
    [SerializeField]
    private AudioClip shotSound;
    private int timer;
    [SerializeField]
    private int interval;

    // ★追加
    // 何秒間停止させるかは自由
    public float stopTimer = 5.0f;

    // ★追加
    [SerializeField]
    private Text stopLabel;


    void Update()
    {
        timer += 1;

        // ★追加
        stopTimer -= Time.deltaTime;
        // タイマーが0未満になったら、0で止める。
        if (stopTimer < 0)
        {
            stopTimer = 0;
        }

        // ★追加
        stopLabel.text = "" + stopTimer.ToString("0"); // 小数点以下は切り捨て

        if (timer % interval == 0 && stopTimer <= 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向（青軸方向）・・・＞この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);  //AudioSource.PlayClipAtPoint(指定した音源, 指定した位置で流す)

            Destroy(enemyShell, 3.0f);
        }
    }

    // ★追加
    // 敵の攻撃をストップさせるメソッド（Timerの時間を増加させることで攻撃の停止時間を伸ばす）
    // （考え方）HPを増加させるアイテム等と同じ
    // このアイテムを複数取得すると、それだけ攻撃停止時間も「加算」される。
    public void AddStopTimer(float amount)
    {
        stopTimer += amount;

        // ★追加
        stopLabel.text = "" + stopTimer.ToString("0");
    }

    

}