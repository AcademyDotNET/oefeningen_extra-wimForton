using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using GLFW;


namespace ParticleSystem
{
    abstract class Game
    {
        protected float fps = 25;
        int InitialWindowWidth { get; set;  }
        int InitialWindowHeight { get; set; }
        string InitialWindowTitle { get; set; }
        public Game(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle)
        {
            InitialWindowWidth = initialWindowWidth;
            InitialWindowHeight = initialWindowHeight;
            InitialWindowTitle = initialWindowTitle;
        }
        public void Run()
        {
            DisplayManager.CreateWindow(InitialWindowWidth, InitialWindowHeight, InitialWindowTitle);
            Initialize();
            
            LoadContent();
            while (!Glfw.WindowShouldClose(DisplayManager.Window))
            {
                GameTime.DeltaTime = (float)Glfw.Time - GameTime.TotalElapsedSeconds;
                GameTime.TotalElapsedSeconds = (float)Glfw.Time;
                GameTime.Frame = MathF.Floor(GameTime.TotalElapsedSeconds * fps);
                if (GameTime.Frame > GameTime.PrevFrame)
                {
                    GameTime.PrevFrame = GameTime.Frame;
                    GameTime.isNewFrame = true;
                }

                Update();
                Glfw.PollEvents();
                Render();
                GameTime.isNewFrame = false;
            }
            DisplayManager.CloseWindow();
        }
        protected abstract void Initialize();
        protected abstract void LoadContent();
        protected abstract void Update();
        protected abstract void Render();


    }
}
