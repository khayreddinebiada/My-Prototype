using data;
using UnityEngine;

namespace management
{
    public class LevelsManager : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private bool _testMode = false;
        [SerializeField]
        private int _indexLevelTesting = 0;

        [SerializeField]
        private LevelData[] _levelsData;
        [SerializeField]
        public LevelData[] levelsData
        {
            get { return _levelsData; }
        }

        private int _indexCurrentLevel;
        public int indexCurrentLevel
        {
            get { return _indexCurrentLevel; }
        }

        private void Awake()
        {
            ActiveCurrentLevel();
        }

        // Start is called before the first frame update
        private void Start()
        {
            _gameManager.onWin += OnWin;
        }

        public void ActiveCurrentLevel()
        {
            if (_levelsData.Length == 0)
                return;

            foreach (var item in _levelsData)
            {
                item.gameObject.SetActive(false);
            }

            if (_testMode)
                _levelsData[_indexLevelTesting].gameObject.SetActive(true);
            else
            {
                if (_gameManager.gameData.data.isRandom)
                {
                    _indexCurrentLevel = Random.Range(2, _levelsData.Length);
                    _levelsData[_indexCurrentLevel].gameObject.SetActive(true);
                }
                else
                {
                    _indexCurrentLevel = _gameManager.gameData.data.indexCurrentLevel;
                    _levelsData[_indexCurrentLevel].gameObject.SetActive(true);
                }
            }
        }

        private void OnWin()
        {
            _gameManager.gameData.data.playerCurrentLevel++;

            if (_indexCurrentLevel == _levelsData.Length - 1)
            {
                _gameManager.gameData.data.isRandom = true;
            }
            else
            {
                _gameManager.gameData.data.indexCurrentLevel++;
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
            }
        }
#endif

    }
}
