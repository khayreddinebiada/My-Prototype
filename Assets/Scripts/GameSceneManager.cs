using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace main.lib
{
    public class GameSceneManager : MonoBehaviour
    {
        [SerializeField]
        private float _waitAndScene = 1;

        public void Replay()
        {
            StartCoroutine(WaitAndGoScene(SceneManager.GetActiveScene().name, false));
        }

        public void ReplayAsync()
        {
            StartCoroutine(WaitAndGoScene(SceneManager.GetActiveScene().name, true));
        }

        public void GoScene(string sceneName)
        {
            StartCoroutine(WaitAndGoScene(sceneName, false));
        }

        public void GoSceneAsync(string sceneName)
        {
            StartCoroutine(WaitAndGoScene(sceneName, true));
        }

        private IEnumerator WaitAndGoScene(string sceneName, bool async)
        {
            yield return new WaitForSeconds(_waitAndScene);
            
            if (async)
                SceneManager.LoadSceneAsync(sceneName);
            else
                SceneManager.LoadScene(sceneName);
        }
    }
}
