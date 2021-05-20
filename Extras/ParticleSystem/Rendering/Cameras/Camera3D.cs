using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glfw3Dapp.Rendering.Display;

namespace Glfw3Dapp.Rendering.Cameras
{
    class Camera3D
    {
        public Vector3 FocusPosition { get; set; }
        public float Zoom { get; set; }
        public Camera3D(Vector3 focusposition, float zoom)
        {
            FocusPosition = focusposition;
            Zoom = zoom;
        }
        public Matrix4x4 GetProjectionMatrix()
        {
            float left = FocusPosition.X - DisplayManager.WindowSize.X / 2f;
            float right = FocusPosition.X + DisplayManager.WindowSize.X / 2f;
            float top = FocusPosition.Y - DisplayManager.WindowSize.Y / 2f;
            float bottom = FocusPosition.Y + DisplayManager.WindowSize.Y / 2f;
            //Matrix4x4 perspectiveMatrix = Matrix4x4.CreatePerspective(200f, 150f, 0.01f, 500f);
            Matrix4x4 perspectiveMatrix = Matrix4x4.CreatePerspectiveFieldOfView(0.1f, 1.2f, 0.1f, 100f);
            Matrix4x4 trans = Matrix4x4.CreateTranslation(0, 0, 20);
            //Matrix4x4 perspectiveMatrix = Matrix4x4.CreatePerspectiveOffCenter(-1000, 1000, -100, 100, 1.01f, 100f);
            Matrix4x4 orthoMatrix = Matrix4x4.CreateOrthographicOffCenter(left, right, bottom, top, 1.01f, 100f);
            Matrix4x4 zoomMatrix = Matrix4x4.CreateScale(Zoom);
            //return orthoMatrix * zoomMatrix;
            return perspectiveMatrix;
        }

    }
}
