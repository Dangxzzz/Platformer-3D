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
        
    }
}
