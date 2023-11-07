using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Services.SceneLoader
{
    public class SceneLoaderService 
    {
        public async UniTask LoadSceneAsync(string sceneName)
            {
                await SceneManager.LoadSceneAsync(sceneName);
                await UniTask.Yield();
            }
        public async UniTask LoadNextSceneAsync()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            await SceneManager.LoadSceneAsync(nextSceneIndex);
            await UniTask.Yield();
        }
        
    }
}
