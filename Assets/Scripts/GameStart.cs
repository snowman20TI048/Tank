using UnityEngine;
using System.Collections;

// ���ǉ�
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

	// ���ǉ�
	// �upublic�v��K�����邱�Ɓi�|�C���g�j
	public void OnStartButtonClicked()
	{
		SceneManager.LoadScene("Main");
	}
}