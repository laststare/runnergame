using Codebase.Utilities;
using UnityEngine;

namespace Codebase.Views
{
    public abstract class Trigger : ViewBase
    {
        protected virtual void OnTriggerEnter(Collider other)
        {
            
        }
    }
}