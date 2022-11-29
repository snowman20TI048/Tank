using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab1;
    [SerializeField]
    private GameObject effectPrefab2;
    public int tankHP;

    [SerializeField]
    private AudioListener mainListener;

    [SerializeField]
    private Text HPLabel;

    // ★追加
    // HPの最大値を設定する（最大値は自由）
    public int tankMaxHP = 5;

    void Start()
    {
        // ★追加
        tankHP = tankMaxHP;

        ShowHPLabel();
    }

    private void ShowHPLabel() //複数回使うコードはメソッド化する
    {
        HPLabel.text = "HP : " + tankHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかってきた相手のTagが”EnemyShell”であったならば（条件）
        if (other.gameObject.tag == "EnemyShell")
        {
            // HPを１ずつ減少させる。
            tankHP -= 1;

            ShowHPLabel();

            // ぶつかってきた相手方（敵の砲弾）を破壊する。
            Destroy(other.gameObject);

            if (tankHP > 0) //自機の体力が０より多い場合
            {
                GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity); // Instantiate(生成したいゲームオブジェクト, 生成する場所, 回転するか否か(Vecter3型の場合は必ず必要))
                Destroy(effect1, 1.0f);
            }
            else //自機の体力が０以下の場合
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // プレーヤーを破壊する。
                // Destroy(gameObject);


                // プレーヤーを破壊せずに画面から見えなくする（ポイント・テクニック）
                // プレーヤーを破壊すると、その時点でメモリー上から消えるので、以降のコードが実行されなくなる。
                mainListener.enabled = true; // オンにする
                this.gameObject.SetActive(false);  //見えなくする
               

                // ★追加
                // 1.5秒後に「GoToGameOver()」メソッドを実行する。
                Invoke("GoToGameOver", 1.5f);

            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // ★追加
    // publicをつけること（重要ポイント）
    public void AddHP(int amount)
    {
        tankHP += amount;

        // ここは何をコントロールしている考えてみましょう！
        if (tankHP > tankMaxHP)
        {
            tankHP = tankMaxHP;
        }

        HPLabel.text = "HP:" + tankHP;
    }

}
