using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.Data
{
    public interface IContentProvider
    {
        public Transform GetRunner();
        public Scene GetRandomScene();
    }
}