using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OctanGames.Managers
{
    public class MainMenuManager : MonoBehaviour
    {
		public void OnStartGame()
		{
            SceneManager.LoadScene("GameScene");
		}
    }
}
