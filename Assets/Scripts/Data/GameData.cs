using UnityEngine;

namespace data
{
    [System.Serializable]
    public class Data
    {
        #region Levels Data
        [SerializeField]
        private bool _isRandom;
        public bool isRandom
        {
            get { return _isRandom; }
            set
            {
                ObjectSaver.OnModifyValue(this, ref _isRandom, value, ObjectSaver.SaveType.JSON);
            }
        }

        [SerializeField]
        public bool _isShowedToturials = false;
        public bool isShowedToturials
        {
            get { return _isShowedToturials; }
            set
            {
                ObjectSaver.OnModifyValue(this, ref _isShowedToturials, value, ObjectSaver.SaveType.JSON);
            }
        }

        [SerializeField]
        private int _indexCurrentLevel = 0;
        public int indexCurrentLevel
        {
            get { return _indexCurrentLevel; }
            set
            {
                ObjectSaver.OnModifyValue(this, ref _indexCurrentLevel, value, ObjectSaver.SaveType.JSON);
            }
        }

        [SerializeField]
        private int _playerCurrentLevel = 0;
        public int playerCurrentLevel
        {
            get { return _playerCurrentLevel; }
            set
            {
                ObjectSaver.OnModifyValue(this, ref _playerCurrentLevel, value, ObjectSaver.SaveType.JSON);
            }
        }
        #endregion
    }

    public class GameData : MonoBehaviour
    {
        [SerializeField]
        private Data _data;
        public Data data
        {
            get { return _data; }
        }

        private void Awake()
        {
            ObjectSaver.InitObject(_data, ObjectSaver.SaveType.JSON);
        }
    }
}