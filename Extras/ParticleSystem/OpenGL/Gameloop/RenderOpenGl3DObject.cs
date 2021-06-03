﻿using GLFW;
using System;
using System.Collections.Generic;
using System.Numerics;
using static GameEngine.OpenGL.GL;

namespace GameEngine
{
    class RenderOpenGl3DObject : RenderOpenGL
    {
        uint vao;
        uint vbo;
        private KeyStrokes myKeystrokes = new KeyStrokes();
        private MouseButtons myMouseButtons = new MouseButtons();
        double mouseXpos, mouseYpos;
        double mousePrevXpos, mousePrevYpos;
        private Matrix4x4 sceneRotation = Matrix4x4.CreateFromYawPitchRoll(0.0f, 0.0f, 0.0f);
        private Matrix4x4 scenePosition = Matrix4x4.CreateTranslation(0.0f, 0.0f, 0.0f);

        List<IRenderableGeo> myParticleSystems = new List<IRenderableGeo>();
        List<float> myVaoList = new List<float>();
        float[] vertices;
        Shader shader;

        Camera3D cam;
        public RenderOpenGl3DObject(List<IRenderableGeo> inParticleSystems, float inFps, int initialWindowWidth, int initialWindowHeight, string initialWindowTitle) : base(initialWindowWidth, initialWindowHeight, initialWindowTitle)
        {
            myParticleSystems = inParticleSystems;
            fps = inFps;
        }

        protected override void Initialize()
        {
            //DisplayManager.CreateWindow(InitialWindowWidth, InitialWindowHeight, InitialWindowTitle);
            shader = new Shader();
            shader.Load();
            glEnable(GL_DEPTH_TEST);
            vao = glGenVertexArray();
            vbo = glGenBuffer();
            glBindVertexArray(vao);
            glBindBuffer(GL_ARRAY_BUFFER, vao);
        }
        protected unsafe override void LoadContent()
        {            

        }

        protected unsafe override void Update()
        {
            glBindBuffer(GL_ARRAY_BUFFER, vao);

            if (GameTime.isNewFrame) {
                myVaoList.Clear();
                for (int i = 0; i < myParticleSystems.Count; i++)
                {
                    myParticleSystems[i].Update();
                    myVaoList.AddRange(myParticleSystems[i].GetVAO());
                }
                vertices = myVaoList.ToArray();
                List<InputState> mouseButtonStateList = new List<InputState>();
                mouseButtonStateList.Add(Glfw.GetMouseButton(DisplayManager.Window, MouseButton.Left));
                mouseButtonStateList.Add(Glfw.GetMouseButton(DisplayManager.Window, MouseButton.Middle));
                mouseButtonStateList.Add(Glfw.GetMouseButton(DisplayManager.Window, MouseButton.Right));
                int mouseButton = myMouseButtons.TestKeys(mouseButtonStateList, true);
                if (mouseButton == 0)//mouseButtonLeft
                {
                    Glfw.GetCursorPosition(DisplayManager.Window, out mouseXpos, out mouseYpos);
                    double mouseXmove = mouseXpos - mousePrevXpos;
                    double mouseYmove = mouseYpos - mousePrevYpos;
                    sceneRotation = Matrix4x4.CreateFromYawPitchRoll((float)mouseXmove * 0.01f, 0.0f, 0.0f) * sceneRotation;
                    sceneRotation = Matrix4x4.CreateFromYawPitchRoll(0.0f, (float)mouseYmove * 0.01f, 0.0f) * sceneRotation;
                    mousePrevXpos = mouseXpos;
                    mousePrevYpos = mouseYpos;
                }
                else if (mouseButton == 1)//mouseButtonMiddle
                {
                    Glfw.GetCursorPosition(DisplayManager.Window, out mouseXpos, out mouseYpos);
                    double mouseXmove = mouseXpos - mousePrevXpos;
                    double mouseYmove = mouseYpos - mousePrevYpos;
                    scenePosition = Matrix4x4.CreateTranslation((float)mouseXmove * 0.006f, 0.0f, 0.0f) * scenePosition;
                    scenePosition = Matrix4x4.CreateTranslation(0.0f, 0.0f, (float)mouseYmove * 0.01f) * scenePosition;
                    mousePrevXpos = mouseXpos;
                    mousePrevYpos = mouseYpos;
                }
                else if (mouseButton == 2)//mouseButtonRight
                {
                    Glfw.GetCursorPosition(DisplayManager.Window, out mouseXpos, out mouseYpos);
                    double mouseXmove = mouseXpos - mousePrevXpos;
                    double mouseYmove = mouseYpos - mousePrevYpos;
                    //scenePosition = Matrix4x4.CreateTranslation((float)mouseXmove * 0.001f, 0.0f, 0.0f) * scenePosition;
                    scenePosition = Matrix4x4.CreateTranslation(0.0f, (float)mouseYmove * -0.005f, 0.0f) * scenePosition;
                    mousePrevXpos = mouseXpos;
                    mousePrevYpos = mouseYpos;
                }
                else
                {
                    Glfw.GetCursorPosition(DisplayManager.Window, out mousePrevXpos, out mousePrevYpos);
                }


                List<InputState> stateList = new List<InputState>();
                stateList.Add(Glfw.GetKey(DisplayManager.Window, Keys.Left));
                stateList.Add(Glfw.GetKey(DisplayManager.Window, Keys.Right));
                stateList.Add(Glfw.GetKey(DisplayManager.Window, Keys.Up));
                stateList.Add(Glfw.GetKey(DisplayManager.Window, Keys.Down));
                stateList.Add(Glfw.GetKey(DisplayManager.Window, Keys.A));
                stateList.Add(Glfw.GetKey(DisplayManager.Window, Keys.D));
                stateList.Add(Glfw.GetKey(DisplayManager.Window, Keys.W));
                stateList.Add(Glfw.GetKey(DisplayManager.Window, Keys.S));
                //stateList.Add(Glfw.GetMouseButton(DisplayManager.Window, MouseButton.Left));
                //stateList.Add(Glfw.GetMouseButton(DisplayManager.Window, MouseButton.Right));


                int keyNum = myKeystrokes.TestKeys(stateList, true);
                if(keyNum == 0)
                {
                    sceneRotation = Matrix4x4.CreateFromYawPitchRoll(0.004f, 0.0f, 0.0f) * sceneRotation;
                }
                if (keyNum == 1)
                {
                    sceneRotation = Matrix4x4.CreateFromYawPitchRoll(-0.004f, 0.0f, 0.0f) * sceneRotation;
                }
                if (keyNum == 2)
                {
                    sceneRotation = Matrix4x4.CreateFromYawPitchRoll(0.0f, -0.004f, -0.0f) * sceneRotation;
                }
                if (keyNum == 3)
                {
                    sceneRotation = Matrix4x4.CreateFromYawPitchRoll(0.0f, 0.004f, 0.0f) * sceneRotation;
                }
                if (keyNum == 4)
                {
                    sceneRotation = Matrix4x4.CreateTranslation(-0.05f, 0.0f, 0.0f) * sceneRotation;
                }
                if (keyNum == 5)
                {
                    sceneRotation = Matrix4x4.CreateTranslation(0.05f, 0.0f, 0.0f) * sceneRotation;
                }
                if (keyNum == 6)
                {
                    sceneRotation = Matrix4x4.CreateTranslation(0.0f, 0.0f, -0.05f) * sceneRotation;
                }
                if (keyNum == 7)
                {
                    sceneRotation = Matrix4x4.CreateTranslation(0.0f, 0.0f, 0.05f) * sceneRotation;
                }


                //mousePrevXpos = 0;
                //mousePrevYpos = 0;

            }
            
            fixed (float* v = &vertices[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_DYNAMIC_DRAW);
            }

            glVertexAttribPointer(0, 3, GL_FLOAT, false, 6 * sizeof(float), (void*)0);// index, 3D positions (x and y), type, not normalized, stride(aantal bytes tot de volgende vertex): 5 X float, vertexes start on: 0(casted to some type of pointer)
            glEnableVertexAttribArray(0);
            glVertexAttribPointer(1, 3, GL_FLOAT, false, 6 * sizeof(float), (void*)(3 * sizeof(float))); //index 1, size 3 (3 colorvalues), floats, not normalized, stride(bytes tot volgende lijn), 2 size of float (cast to pointer): first colorvalue starts at...
            glEnableVertexAttribArray(1);
            glBindVertexArray(vao);
            glDrawArrays(GL_TRIANGLES, 0, vertices.Length * 6); //GL_TRIANGLES

            //unbind vertex arrays
            glBindBuffer(GL_ARRAY_BUFFER, 0);
            glBindVertexArray(0);
            Vector3 cameraposition = new Vector3(DisplayManager.WindowSize.X, DisplayManager.WindowSize.Y, 0);
            cam = new Camera3D(cameraposition / 2f, 1f);
        }
        protected override void Render()
        {
            glClearColor(0.2f, 0.2f, 0.3f, 1);
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
            Update();
            Vector3 position = new Vector3(0, 0, -5);
            Vector3 scale = new Vector3(1, 1, 1);


            Matrix4x4 trans = Matrix4x4.CreateTranslation(position.X, position.Y, position.Z);
            Matrix4x4 sca = Matrix4x4.CreateScale(scale.X, scale.Y, scale.Z);
            Matrix4x4 rot = Matrix4x4.CreateRotationY(MathF.PI * 2);

            shader.SetMatrix4x4("view", sceneRotation * scenePosition);
            shader.Use();
            shader.SetMatrix4x4("projection", rot * cam.GetProjectionMatrix());


            Glfw.SwapBuffers(DisplayManager.Window);
            glFlush();
            glFinish();

            glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
            byte[] data = new byte[4];
            glReadPixels(1024 / 2, 768 / 2, 1, 1, GL_RGBA, GL_UNSIGNED_BYTE, data);
        }
    }
}
