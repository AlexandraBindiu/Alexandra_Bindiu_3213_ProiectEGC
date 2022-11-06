using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{ 
    class Triangle
    {
        private Vector3 PointA;
        private Vector3 PointB;
        private Vector3 PointC;
        private Color color;
        private bool visibility;
        private float linewidth;
        private float pointsize;
        private PolygonMode polMode;
        public float q;
        public float f;
        public Triangle(Vector3 a, Vector3 b, Vector3 c)
        {
            PointA = a;
            PointB = b;
            PointC = c;

            color = Color.FromArgb(0, 0, 0);

            Inits();
        }
        private void Inits()
        {
            visibility = true;
            linewidth = 3.0f;
            pointsize = 3.0f;
            polMode = PolygonMode.Fill;
        }
        public void DrawObject()
        {
            if (visibility)
            {
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);
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
        }

        public void DiscoMode(Randomizer _r)
        {
            color = _r.RandomColor();
        }
         public void MoveUp()
        {
             f += 0.05f;
        }
        public void MoveDown()
        {
           f -= 0.05f;
        }

    }
}
