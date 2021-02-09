using UnityEngine;

namespace app
{
    public class InitTenjin : MonoBehaviour
    {
        /*
        [SerializeField]
        private string appkey;

        void Start()
        {
            TenjinConnect();
        }

        void OnApplicationPause(bool pauseStatus)
        {
            if (!pauseStatus)
            {
                TenjinConnect();
            }
        }

        public void TenjinConnect()
        {
            BaseTenjin instance = Tenjin.getInstance(appkey);

#if UNITY_IOS

            // Tenjin wrapper for requestTrackingAuthorization
            instance.RequestTrackingAuthorizationWithCompletionHandler((status) => {
                Debug.Log("===> App Tracking Transparency Authorization Status: " + status);

                // Sends install/open event to Tenjin
                instance.Connect();

            });

#elif UNITY_ANDROID

      // Sends install/open event to Tenjin
      instance.Connect();

#endif
        }
        */
    }
}