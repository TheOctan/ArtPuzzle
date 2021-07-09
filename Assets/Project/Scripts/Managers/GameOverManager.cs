using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OctanGames.Managers
{
    public class GameOverManager : MonoBehaviour
    {
        public void OnRestartGame()
		{
            SceneManager.LoadScene("GameScene");
		}
    }
}
