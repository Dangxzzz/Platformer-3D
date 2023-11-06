﻿using UnityEngine;

namespace Platformer.Services.InputService
{
    public class StandaloneInputService : IInputService
    {
        #region Properties

        public Vector2 Axes => new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        public bool IsJump => UnityEngine.Input.GetButtonDown("Jump");

        #endregion
    }
}