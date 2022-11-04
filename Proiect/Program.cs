using OpenTK;
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
    class Program : GameWindow
    {
        KeyboardState lastKeyPress;
        private float q;
        private float f;
        public Program() : base(900, 700)
        {
            VSync = VSyncMode.On;
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

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 5, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

        }
        private void DrawObject()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.LoadIdentity();

            GL.Color3(Color.Black);

            GL.Vertex3(-5.0f + q, -5.0f + f, -5.0f);
            GL.Vertex3(-5.0f + q, -5.0f + f, 5.0f);
            GL.Vertex3(5.0f + q, -5.0f + f, 5.0f);

            GL.Vertex3(5.0f + q, -5.0f + f, 5.0f);
            GL.Vertex3(5.0f + q, -5.0f + f, -5.0f);
            GL.Vertex3(-5.0f + q, -5.0f + f, -5.0f);

            GL.Color3(Color.DarkSeaGreen);
            GL.Vertex3(-5.0f + q, -5.0f + f, -5.0f);
            GL.Vertex3(-0.05f + q, 5.05f + f, 0.0f);
            GL.Vertex3(5.0f + q, -5.0f + f, -5.0f);

            GL.Color3(Color.LightSalmon);
            GL.Vertex3(5.0f + q, -5.0f + f, -5.0f);
            GL.Vertex3(-0.05f + q, 5.05f + f, 0.0f);
            GL.Vertex3(5.0f + q, -5.0f + f, 5.0f);

            GL.Color3(Color.DarkSeaGreen);
            GL.Vertex3(5.0f + q, -5.0f + f, 5.0f);
            GL.Vertex3(-0.05f + q, 5.05f + f, 0.0f);
            GL.Vertex3(-5.0f + q, -5.0f + f, 5.0f);

            GL.Color3(Color.LightSalmon);
            GL.Vertex3(-5.0f + q, -5.0f + f, 5.0f);
            GL.Vertex3(-0.05f + q, 5.05f + f, 0.0f);
            GL.Vertex3(-5.0f + q, -5.0f + f, -5.0f);

            GL.End();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(15, 50, 15, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
            DrawObject();


            SwapBuffers();
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            MouseState mouse = OpenTK.Input.Mouse.GetState();
            int x_click = mouse.X;
            int y_click = mouse.Y;

           
            ///iesire din program la apasarea tastei esc
            if (keyboard[OpenTK.Input.Key.Escape])
            {
                this.Exit();
                return;
            }

            ///miscarea obiectului folosind mouse ul
            if (keyboard[OpenTK.Input.Key.X])
            {
                GL.Rotate(-1, 1, 1, 1);
            }
            else if ((x_click != X || y_click != Y) && mouse[MouseButton.Left])
            {
                GL.Viewport(x_click, -y_click, Width, Height);
            }

            //miscarea obiectului folosind tastele up si down
            if (keyboard[Key.Down])
            {
                f -= 0.05f;
            }
            if (keyboard[Key.Up])
            {
                f += 0.05f;
            }

            lastKeyPress = keyboard;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("\n------------------MENU-------------------");
            Console.WriteLine("\n Miscarea obiectului se face folosind mouse-ul sau tastele UP si DOWN "); 
            using (Program example = new Program())
            {

                example.Run(30.0, 0.0);
            }

            
        }
    }
}
