using GLFW;
using System;
using System.Collections.Generic;
using System.Numerics;
using static ParticleSystem.OpenGL.GL;

namespace ParticleSystem
{
    class RenderOpenGl3DObject : Game
    {
        uint vao;
        uint vbo;
        List<ParticleSystems> myParticleSystems = new List<ParticleSystems>();

        Shader shader;

        Camera3D cam;
        public RenderOpenGl3DObject(List<ParticleSystems> inParticleSystems, int initialWindowWidth, int initialWindowHeight, string initialWindowTitle) : base(initialWindowWidth, initialWindowHeight, initialWindowTitle)
        {
            myParticleSystems = inParticleSystems;
        }

        protected override void Initialize()
        {
            //myParticleSystems.Add(new ParticleEmitter("EmitterA", 100, Vector.setNew(10, 16, 5), 0.1, 0.08, 0.99, true));
            //myParticleSystems.Add(new ParticleTensionLine("RopeA", 30, Vector.setNew(10, 16, 0), Vector.setNew(40, 16, 0), 1.0, 0.004, 0.986));
            //myParticleSystems.Add(new ParticleTensionLine("RopeB", 50, Vector.setNew(10, 16, 0), Vector.setNew(20, 10, 20), 1.0, 0.004, 0.986));
        }
        protected unsafe override void LoadContent()
        {            
            shader = new Shader();
            shader.Load();

            vao = glGenVertexArray();
            vbo = glGenBuffer();
            glBindVertexArray(vao);
            glBindBuffer(GL_ARRAY_BUFFER, vao);
        }

        protected unsafe override void Update()
        {
            float step = GameTime.TotalElapsedSeconds;

            //vao and vbo created in LoadContent()
            //glBindVertexArray(vao);
            glBindBuffer(GL_ARRAY_BUFFER, vao);

            /*
            float[] verticesArray =
            {
                0.5f, 0.5f, -30.0f, 0f, 1f, 0f,// top right
                -0.5f, 0.5f, -20.0f, 1f, 0f, 0f, // top left (x, y, r, g, b)
                -0.5f, -0.5f, -20.0f, 0f, 0f, 1f, // bottom left

                0.5f, 0.5f, -30.0f, 0f, 1f, 0f,// top right
                0.5f, -0.5f, -30.0f, 0f, 1f, 1f, // bottom right
                -0.5f, -0.5f, -20.0f, 0f, 0f, 1f, // bottom left

            };
            verticesArray[1] = MathF.Sin(step) + 0.5f;
            List<float> verticesList = new List<float>();
            foreach (var item in verticesArray)
            {
                verticesList.Add(item);
            }
            float[] vertices = verticesList.ToArray();
            */
            myParticleSystems[1].myParticles[0].Pos.X = MathF.Sin(GameTime.TotalElapsedSeconds) * 10;
            myParticleSystems[1].myParticles[0].Pos.Y = MathF.Sin(GameTime.TotalElapsedSeconds * 20);
            myParticleSystems[1].myParticles[0].Pos.Z = MathF.Cos(GameTime.TotalElapsedSeconds + 0.5f) * 10 - 30;
            myParticleSystems[1].UpdateParticles();
            float[] vertices = myParticleSystems[1].createVAO();

            fixed (float* v = &vertices[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_DYNAMIC_DRAW);
                //glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
                //glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Count, null, GL_DYNAMIC_DRAW);
            }
            glVertexAttribPointer(0, 3, GL_FLOAT, false, 6 * sizeof(float), (void*)0);// index, 3D positions (x and y), type, not normalized, stride(aantal bytes tot de volgende vertex): 5 X float, vertexes start on: 0(casted to some type of pointer)
            glEnableVertexAttribArray(0);
            glVertexAttribPointer(1, 3, GL_FLOAT, false, 6 * sizeof(float), (void*)(3 * sizeof(float))); //index 1, size 3 (3 colorvalues), floats, not normalized, stride(bytes tot volgende lijn), 2 size of float (cast to pointer): first colorvalue starts at...
            glEnableVertexAttribArray(1);
            glBindVertexArray(vao);
            glDrawArrays(GL_TRIANGLES, 0, vertices.Length * 6);

            //unbind vertex arrays
            glBindBuffer(GL_ARRAY_BUFFER, 0);
            glBindVertexArray(0);
            Vector3 cameraposition = new Vector3(DisplayManager.WindowSize.X, DisplayManager.WindowSize.Y, 0);
            cam = new Camera3D(cameraposition / 2f, 1f);
        }
        protected override void Render()
        {
            //glClearColor(MathF.Sin(GameTime.TotalElapsedSeconds), 0, 0, 1);
            glClearColor(1, 0, 0, 1);
            glClear(GL_COLOR_BUFFER_BIT);
            Update();
            Vector3 position = new Vector3(0, 0, -5);
            Vector3 scale = new Vector3(1, 1, 1);
            float rotation = MathF.Sin(GameTime.TotalElapsedSeconds);
            float rotation2 = MathF.Sin(GameTime.TotalElapsedSeconds);

            Matrix4x4 trans = Matrix4x4.CreateTranslation(position.X, position.Y, position.Z);
            Matrix4x4 sca = Matrix4x4.CreateScale(scale.X, scale.Y, scale.Z);
            Matrix4x4 rot = Matrix4x4.CreateRotationY(rotation);
            Matrix4x4 rot2 = Matrix4x4.CreateRotationY(MathF.PI * 2);

            shader.SetMatrix4x4("model", sca * rot * trans);
            shader.Use();
            shader.SetMatrix4x4("projection", rot2 * cam.GetProjectionMatrix());

            //glBindVertexArray(vao);
            //glDrawArrays(GL_TRIANGLES, 0, 6);//// kunnen we dit meer keer?
            //glBindVertexArray(0);

            Glfw.SwapBuffers(DisplayManager.Window);
            glFlush();
            glFinish();

            glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
            byte[] data = new byte[4];
            glReadPixels(1024 / 2, 768 / 2, 1, 1, GL_RGBA, GL_UNSIGNED_BYTE, data);
        }
    }
}
