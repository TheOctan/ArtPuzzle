using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OctanGames.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public void OnGameOver()
		{
            SceneManager.LoadScene("FinalScene");
		}
    }
}
