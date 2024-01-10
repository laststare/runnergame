using Codebase.InterfaceAdapters.LevelBuilder;
using Codebase.Utilities;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Codebase.InterfaceAdapters.LevelMover
{
    public class LevelMoverController : DisposableBase
    {
        private bool _isAlive = true;
        private bool _worldIsMoving;
        private readonly IWorldMovable _worldMovable;
        
        public LevelMoverController(IWorldMovable worldMovable)
        {
            _worldMovable = worldMovable;
            _worldIsMoving = true;
            WorldMover();
        }

        private async void WorldMover()
        {
            while (_isAlive)
            {
                if (_worldIsMoving)
                {
                    foreach (var transform in _worldMovable.ObjectsToMove)
                    {
                        transform.Translate(-Vector3.right * Time.deltaTime * 3);
                    }
                }
                await UniTask.Yield();
            }
        }
        
        protected override void OnDispose()
        {
            _isAlive = false;
        }
    }
}