using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �����̂P�s��Y��Ȃ����ƁB
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // �擪�Ɂupublic�v���t���Ă��邱�Ƃ��m�F����i�|�C���g�j
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}