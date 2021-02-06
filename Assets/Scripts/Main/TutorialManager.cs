using data;
using UnityEngine;

namespace management
{
    public class TutorialManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            if (!GlobalData.ShowToturials())
            {
                Destroy(gameObject);
            }
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
            }

        }
    }
}
