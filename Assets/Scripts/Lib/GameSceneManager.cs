using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace management
{
    public class GameSceneManager : MonoBehaviour
    {
        [SerializeField]
        private bool _useWaiting = false;
        [SerializeField]
        private float _waitAndScene = 1;

        public void Replay()
        {
            if (_useWaiting)
                StartCoroutine(WaitAndGoScene(SceneManager.GetActiveScene().name, false));
            else
                GoScene(SceneManager.GetActiveScene().name, false);
        }

        public void ReplayAsync()
        {
            if (_useWaiting)
                StartCoroutine(WaitAndGoScene(SceneManager.GetActiveScene().name, true));
            else
                GoScene(SceneManager.GetActiveScene().name, true);
        }

        public void GoScene(string sceneName)
        {
            if (_useWaiting)
                StartCoroutine(WaitAndGoScene(sceneName, false));
            else
                GoScene(sceneName, false);
        }

        public void GoSceneAsync(string sceneName)
        {
            if (_useWaiting)
                StartCoroutine(WaitAndGoScene(sceneName, true));
            else
                GoScene(sceneName, true);
        }

        private IEnumerator WaitAndGoScene(string sceneName, bool async)
        {
            yield return new WaitForSeconds(_waitAndScene);
            
            if (async)
                SceneManager.LoadSceneAsync(sceneName);
            else
                SceneManager.LoadScene(sceneName);
        }

        private void GoScene(string sceneName, bool async)
        {
            if (async)
                SceneManager.LoadSceneAsync(sceneName);
            else
                SceneManager.LoadScene(sceneName);
        }
    }
}
