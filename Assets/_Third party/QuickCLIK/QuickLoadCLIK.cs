using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrazyLabsHubs
{
    public class QuickLoadCLIK : MonoBehaviour
    {
        public string sceneToLoadName;
        public float timeToWaitBeforeLoadingScene = 0.1f;

        void Awake()
        {
#if TTP_ANALYTICS
            Tabtale.TTPlugins.TTPCore.Setup();
#endif
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(timeToWaitBeforeLoadingScene);

            if (!string.IsNullOrEmpty(sceneToLoadName))
            {
                SceneManager.LoadScene(sceneToLoadName, LoadSceneMode.Single);
            }
        }
    }
}
