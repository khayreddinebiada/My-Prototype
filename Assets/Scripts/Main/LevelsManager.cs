using data;
using UnityEngine;

namespace management
{
    public class LevelsManager : MonoBehaviour
    {
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

        private GameManager _gameManager;

        // Start is called before the first frame update
        private void Start()
        {
            _gameManager = GameManager.instance;

            _gameManager.onStart.AddListener(() => ActiveCurrentLevel());
            _gameManager.onWin.AddListener(() => OnWin());
            _gameManager.onGoHome.AddListener(() => OnGoHome());
        }

        public void ActiveCurrentLevel()
        {
            if (_levelsData.Length == 0)
                return;

            if (_testMode)
                _levelsData[_indexLevelTesting].gameObject.SetActive(true);
            else
            {
                if (GlobalData.IsRandomChoiceLevels())
                {
                    _indexCurrentLevel = Random.Range(2, _levelsData.Length);
                    _levelsData[_indexCurrentLevel].gameObject.SetActive(true);
                }
                else
                {
                    _indexCurrentLevel = GlobalData.indexCurrentLevel;
                    _levelsData[_indexCurrentLevel].gameObject.SetActive(true);
                }
            }
        }

        private void OnGoHome()
        {
            foreach (LevelData item in _levelsData)
            {
                item.gameObject.SetActive(false);
            }
        }

        private void OnWin()
        {
            GlobalData.playerCurrentLevel++;

            if (_indexCurrentLevel == _levelsData.Length - 1)
            {
                GlobalData.SetRandomChoiceLevels();
            }
            else
            {
                GlobalData.indexCurrentLevel++;
            }
        }

    }
}
