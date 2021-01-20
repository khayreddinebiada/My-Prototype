using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main.management
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
            InstanceCurrentLevel();
        }

        public void InstanceCurrentLevel()
        {
            if (_testMode)
                Instantiate(_levelsData[_indexLevelTesting].levelPrefab);
            else
            {
                if (GlobalData.IsRandomChoiceLevels())
                {
                    _indexCurrentLevel = Random.Range(2, _levelsData.Length);
                    Instantiate(_levelsData[_indexCurrentLevel].levelPrefab);
                }
                else
                {
                    _indexCurrentLevel = GlobalData.indexCurrentLevel;
                    Instantiate(_levelsData[_indexCurrentLevel].levelPrefab);
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
