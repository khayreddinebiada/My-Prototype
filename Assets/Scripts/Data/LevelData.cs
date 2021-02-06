using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "Data/Add Level Data", order = 1)]
    public class LevelData : ScriptableObject
    {
        [SerializeField]
        private GameObject _levelPrefab;
        public GameObject levelPrefab
        {
            get { return _levelPrefab; }
        }
    }
}
