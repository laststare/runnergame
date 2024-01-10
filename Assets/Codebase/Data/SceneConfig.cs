using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.Data
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "GameData/SceneConfig")]
    public class SceneConfig : ScriptableObject
    {
        [SerializeField] private Scene[] scenes;
        
        public Scene GetRandomScene()
        {
            return scenes[Random.Range(0, scenes.Length)];
        }
    }
}