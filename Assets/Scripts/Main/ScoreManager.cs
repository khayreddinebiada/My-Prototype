using UnityEngine;

namespace management
{
    public class ScoreManager : MonoBehaviour
    {
        private static int _currentScore = 0;
        public static int currentScore
        {
            get { return _currentScore; }
        }

        // Start is called before the first frame update
        private void Start()
        {
            _currentScore = 0;
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}
