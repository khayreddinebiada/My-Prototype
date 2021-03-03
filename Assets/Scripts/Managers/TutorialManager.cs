using data;
using UnityEngine;

namespace management
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        // Start is called before the first frame update
        private void Start()
        {
            if (_gameManager.gameData.data.isShowedToturials)
            {
                Destroy(gameObject);
            }
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _gameManager.gameData.data.isShowedToturials = true;
                Destroy(gameObject);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_gameManager == null)
                _gameManager = FindObjectOfType<GameManager>();
        }
#endif
    }
}
