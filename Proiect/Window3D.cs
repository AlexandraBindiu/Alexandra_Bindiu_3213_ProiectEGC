using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    
    class Window3D : GameWindow
    {
        private Color DEFAULT_BACK_COLOR = Color.FromArgb(96, 96, 96);
        private Triangle firstTriangle;
        private Randomizer rando;
        KeyboardState lastKeyPress;
        private KeyboardState previousKeyboard;
        private float q;
        private float f;

        public Window3D() : base(1000, 1000, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            rando = new Randomizer();
            firstTriangle = new Triangle(new Vector3(1, 5, 1), new Vector3(6, 1, 1), new Vector3(6, 10, 1));
           
            DisplayHelp();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.White);
            GL.Enable(EnableCap.DepthTest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // setare fundal
            GL.ClearColor(Color.WhiteSmoke);

            // setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // setare proiectie/con vizualizare
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 600);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // setare ochi
            Matrix4 ochi = Matrix4.LookAt(15, 15, 30, 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref ochi);

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(15, 50, 15, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            // RENDER CODE

            firstTriangle.DrawObject();
            // END render code
            SwapBuffers();

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState currentKeyboard = Keyboard.GetState();
           
            MouseState mouse = OpenTK.Input.Mouse.GetState();
            int x_click = mouse.X;
            int y_click = mouse.Y;


            ///iesire din program la apasarea tastei esc
            if (currentKeyboard[OpenTK.Input.Key.Escape])
            {
                this.Exit();
                return;
            }

            ///miscarea obiectului folosind mouse ul
            if (currentKeyboard[OpenTK.Input.Key.X])
            {
                GL.Rotate(-1, 1, 1, 1);
            }
            else if ((x_click != X || y_click != Y) && mouse[MouseButton.Left])
            {
                GL.Viewport(x_click, -y_click, Width, Height);
            }

            //miscarea obiectului folosind tastele up si down
            if (currentKeyboard[Key.Down])
            {
                firstTriangle.MoveDown();
            }
            if (currentKeyboard[Key.Up])
            {
                firstTriangle.MoveUp();
            }
            
            ///schimba culoarea
            
            if (currentKeyboard[Key.C] && !previousKeyboard[Key.C])
            {
                firstTriangle.DiscoMode(rando);
            }

           // lastKeyPress = currentKeyboard;
        }
        private void DisplayHelp()
        {
            Console.WriteLine("\n------------------MENU-------------------");
            Console.WriteLine("\n Miscarea obiectului se face folosind mouse-ul sau tastele UP si DOWN ");
            Console.WriteLine("\n C - schimba culoarea obiectului ");


        }
    }
}
