using UnityEngine;

namespace editor
{
    [ExecuteInEditMode]
    public class EditorManager : MonoBehaviour
    {
        private static EditorManager _instance;
        public static EditorManager instance
        {
            get { return _instance; }
        }


        // Start is called before the first frame update
        private void OnEnable()
        {
            _instance = this;
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}