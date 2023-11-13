using UnityEngine;

namespace Platformer.Services.InputService
{
    public interface IInputService
    {
        #region Properties

        Vector2 Axes { get; }
        bool IsJump { get; }

        #endregion
    }
}