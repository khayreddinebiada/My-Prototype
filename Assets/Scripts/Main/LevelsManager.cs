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

        // Start is called before the first frame update
        private void Start()
        {
            GameManager.instance.onWin.AddListener(() => OnWin());

            ActiveCurrentLevel();
        }

        public void ActiveCurrentLevel()
        {
            if (_levelsData.Length == 0)
                return;

            if (_testMode)
                _levelsData[_indexLevelTesting].levelPrefab.SetActive(true);
            else
            {
                if (GlobalData.IsRandomChoiceLevels())
                {
                    _indexCurrentLevel = Random.Range(2, _levelsData.Length);
                    _levelsData[_indexCurrentLevel].levelPrefab.SetActive(true);
                }
                else
                {
                    _indexCurrentLevel = GlobalData.indexCurrentLevel;
                    _levelsData[_indexCurrentLevel].levelPrefab.SetActive(true);
                }
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
