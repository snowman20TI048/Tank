using UnityEngine;
using System.Collections;

// ★追加
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

	// ★追加
	// 「public」を必ずつけること（ポイント）
	public void OnStartButtonClicked()
	{
		SceneManager.LoadScene("Main");
	}
}