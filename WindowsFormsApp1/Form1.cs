using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Global variables
        static Bitmap bitmap = new Bitmap(501, 501);
        static Bitmap texture;
        static Bitmap normalMap;
        int widthMap = 500, heightMap = 500;
        Mesh mesh = new Mesh();

        int rowIndexOfPointToMove = -1;
        int columnIndexOfPointToMove = -1;
        bool movingPoint = false;

        static bool parrarel = false;

        //Colors variables
        static Color objectColor = Color.Blue;
        static bool constObjectColor = false;
        static Color lightColor = Color.White;
        static bool constNormalVector = false;
        static bool lightStationary = true;
        static bool lightChangeColor = false;
        static double R = 200;
        static PointF lightPos = new Point(250, 250);
        static bool interpolated = false;
        static NormalVector L = new NormalVector();
        static NormalVector V = new NormalVector();
        static double Ks = 0.5;
        static double Kd = 0.5;
        static int m = 1;
        static double dLz = 0.0;

        Thread th2;
        Thread th3;

        List<PointF> points;
        List<Point> lightCirclePoints;

        //Main function
        public Form1()
        {
            //Basic initial operations
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            pictureBoxMap.Size = new Size(widthMap, heightMap);

            //Intitial controls
            PrepareValidStateOfControls();

            mesh = new Mesh(pictureBoxMap.Width, pictureBoxMap.Height, (int)numericUpDownRows.Value,
                (int)numericUpDownColumns.Value, Pens.Black);

            //Main texture
            string path = @"texture/texture.jpg";
            Image image = Image.FromFile(path);
            texture = new Bitmap(image, new Size(500, 500));

            //Basic normalMap
            path = @"normalMaps/normalMap1.jpg";
            Image image2 = Image.FromFile(path);
            normalMap = new Bitmap(image2, new Size(500, 500));

            L.X = 0.5;
            L.Y = 0.5;
            L.Z = 1;

            V.X = 0;
            V.Y = 0;
            V.Z = 1;

            //Generate point for lightSpiral
            PointF center = new PointF(250, 250);
            int A = 9;
            float start_angle = 0;
            float max_r = 250;
            points = GetSpiralPoints(center, A, start_angle, max_r);

            lightCirclePoints = GetCirclePoints();
        }

        public void PrepareValidStateOfControls()
        {
            numericUpDownRows.Value = 4;
            numericUpDownColumns.Value = 4;
            numericUpDownRows.Minimum = 2;
            numericUpDownRows.TextAlign = HorizontalAlignment.Center;
            numericUpDownColumns.Minimum = 2;
            numericUpDownColumns.TextAlign = HorizontalAlignment.Center;
            checkBoxMeshVisible.Checked = true;

            numericUpDownR.Value = 100;
            numericUpDownR.Minimum = 0;
            numericUpDownR.Maximum = 250;
            numericUpDownR.TextAlign = HorizontalAlignment.Center;

            radioButtonObjectColorT.Checked = true;
            pictureBoxObjectColor.BackColor = objectColor;

            pictureBoxLightColor.BackColor = lightColor;
            radioButtonLightStationary.Checked = true;

            //trackBarKs
            trackBarKs.Maximum = 100;
            trackBarKs.Minimum = 0;
            trackBarKs.Value = 50;
            labelKsValue.Text = Ks.ToString();
            //trackBarKd
            trackBarKd.Maximum = 100;
            trackBarKd.Minimum = 0;
            trackBarKd.Value = 50;
            labelKdValue.Text = Kd.ToString();
            //trackBarm
            trackBarm.Maximum = 100;
            trackBarm.Minimum = 1;
            trackBarm.Value = 1;
            labelmValue.Text = m.ToString();

            radioButtonLightStationary.Checked = true;
            radioButtonNormalMapFromFile.Checked = true;
            radioButtonAccurateFilling.Checked = true;
        }

        private void checkBoxMeshVisible_CheckedChanged(object sender, EventArgs e)
        {
            mesh.ChangeVisibility();
            pictureBoxMap.Invalidate();
        }

        private void pictureBoxMap_Paint(object sender, PaintEventArgs e)
        {
            mesh.Draw(e.Graphics);
            pictureBoxMap.Image = bitmap;
        }

        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mesh.visible)
            {
                (int rowIndex, int columnIndex) = mesh.SearchPointToMove(e.Location);
                if (rowIndex != -1)
                {
                    rowIndexOfPointToMove = rowIndex;
                    columnIndexOfPointToMove = columnIndex;
                    movingPoint = true;
                }
            }
        }

        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && movingPoint)
            {
                if (e.Location.X > 5 && e.Location.X < widthMap - 5 && e.Location.Y > 5 && e.Location.Y < heightMap - 5)
                    mesh.ChangePointLocation(rowIndexOfPointToMove, columnIndexOfPointToMove, e.Location);
                pictureBoxMap.Invalidate();
            }
        }

        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            rowIndexOfPointToMove = -1;
            columnIndexOfPointToMove = -1;
            movingPoint = false;
        }

        private void buttonNewMesh_Click(object sender, EventArgs e)
        {
            mesh.ChangeRowsAndColumns((int)numericUpDownRows.Value, (int)numericUpDownColumns.Value);
            pictureBoxMap.Invalidate();
        }

        class Mesh
        {
            public Point[,] points;
            private int widthMap;
            private int heightMap;
            public int rows;
            public int columns;
            private Pen pen;
            Graphics graphics;
            public bool visible = true;
            public Triangle[,] triangles;

            public Mesh(int widthMap, int heightMap, int rows, int columns, Pen pen)
            {
                this.widthMap = widthMap;
                this.heightMap = heightMap;
                this.rows = rows;
                this.columns = columns;
                this.pen = pen;
                this.points = new Point[rows + 1, columns + 1];

                GeneratePoints();
                GenerateTriangles();
            }

            public Mesh() { }

            private void GeneratePoints()
            {
                double dx = (double)widthMap / (double)columns;
                double dy = (double)heightMap / (double)rows;

                //basic
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        points[i, j] = new Point((int)(j * dx), (int)(i * dy));
                    }
                }
                //last column
                for (int i = 0; i < rows; i++)
                {
                    points[i, columns] = new Point(widthMap - 1, (int)(i * dy));
                }
                //last row
                for (int j = 0; j < columns; j++)
                {
                    points[rows, j] = new Point((int)(j * dx), heightMap - 1);
                }
                //bottom right point
                points[rows, columns] = new Point(widthMap - 1, heightMap - 1);
            }

            private void GenerateTriangles()
            {
                triangles = new Triangle[rows, 2 * columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Point p1 = points[i + 1, j];
                        Point p2 = points[i, j + 1];
                        Point p3 = points[i, j];
                        triangles[i, 2 * j] = new Triangle(p1, p2, p3);
                        p3 = points[i + 1, j + 1];
                        triangles[i, 2 * j + 1] = new Triangle(p1, p2, p3);
                    }
                }
            }

            public void Draw(Graphics graphics)
            {
                this.graphics = graphics;

                //Fill
                if (parrarel == true)
                {
                    Parallel.For(0, rows, (i) =>
                    {
                        Parallel.For(0, columns, (j) =>
                        {
                            triangles[i, 2 * j].Fill(graphics);
                            triangles[i, 2 * j + 1].Fill(graphics);
                        });
                    });
                }
                else
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            triangles[i, 2 * j].Fill(graphics);
                            triangles[i, 2 * j + 1].Fill(graphics);
                        }
                    }
                }

                //Lines
                DrawLines(graphics);
            }

            public void DrawLines(Graphics graphics)
            {
                if (!visible)
                    return;

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //first row
                for (int j = 0; j < columns; j++)
                {
                    graphics.DrawLine(pen, points[0, j], points[0, j + 1]);
                }
                //last right column
                for (int i = 0; i < rows; i++)
                {
                    graphics.DrawLine(pen, points[i, columns], points[i + 1, columns]);
                }
                //others
                for (int i = 1; i < rows + 1; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        graphics.DrawLine(pen, points[i, j], points[i - 1, j]);
                        graphics.DrawLine(pen, points[i, j], points[i - 1, j + 1]);
                        graphics.DrawLine(pen, points[i, j], points[i, j + 1]);
                    }
                }
            }

            public void ChangeVisibility()
            {
                visible = !visible;
            }

            public void ChangeRowsAndColumns(int newRows, int newColumns)
            {
                this.rows = newRows;
                this.columns = newColumns;
                points = new Point[newRows + 1, newColumns + 1];
                GeneratePoints();
                GenerateTriangles();
            }

            public void ChangePointLocation(int rowIndex, int columnIndex, Point point)
            {
                //change point
                points[rowIndex, columnIndex] = point;

                //change relevant triangles
                int r = rowIndex;
                int c = columnIndex;

                triangles[r, 2 * c].ChangePoint(point, 3);
                c--;
                triangles[r, 2 * c].ChangePoint(point, 2);
                triangles[r, 2 * c + 1].ChangePoint(point, 2);
                r--;
                triangles[r, 2 * c + 1].ChangePoint(point, 3);
                c++;
                triangles[r, 2 * c].ChangePoint(point, 1);
                triangles[r, 2 * c + 1].ChangePoint(point, 1);
            }

            public void Redraw(int rowIndex, int columnIndex, Graphics graphics)
            {
                int r = rowIndex;
                int c = columnIndex;

                triangles[r, 2 * c].Draw(graphics);
                c--;
                triangles[r, 2 * c].Draw(graphics);
                triangles[r, 2 * c + 1].Draw(graphics);
                r--;
                triangles[r, 2 * c + 1].Draw(graphics);
                c++;
                triangles[r, 2 * c].Draw(graphics);
                triangles[r, 2 * c + 1].Draw(graphics);

                DrawLines(graphics);
            }

            public (int rowIndex, int columnIndex) SearchPointToMove(Point point)
            {
                for (int i = 1; i < rows; i++)
                {
                    for (int j = 1; j < columns; j++)
                    {
                        if (PointDistances(point, points[i, j]) < 4)
                        {
                            return (i, j);
                        }
                    }
                }
                return (-1, -1);
            }

            public static int PointDistances(Point p1, Point p2)
            {
                return (int)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            }

            public static int PointDistances(Point p1, PointF p2)
            {
                return (int)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            }
        }

        class Edge
        {
            public Point p1, p2;
            public double x;

            public int MinY
            {
                get { return Math.Min(p1.Y, p2.Y); }
            }

            public int MaxY
            {
                get { return Math.Max(p1.X, p2.X); }
            }

            public double m
            {
                get
                {
                    if (p1.X == p2.X)
                        return 0;
                    return 1.0 / ((double)(p2.Y - p1.Y) / (double)(p2.X - p1.X));
                }
            }

            public Edge(Point p1, Point p2)
            {
                this.p1 = p1;
                this.p2 = p2;
                this.x = p1.X;
            }
        }

        class MyPoint
        {
            public Point point;
            public int index;

            public int NextIndex
            {
                get { return (index + 1) % 3; }
            }

            public int PreviousIndex
            {
                get
                {
                    if (index == 0)
                        return 2;
                    return index - 1;
                }
            }

            public MyPoint(Point point, int index)
            {
                this.point = point;
                this.index = index;
            }
        }

        private void radioButtonConstObjectColor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonConstObjectColor.Checked == false)
                return;
            constObjectColor = true;
        }

        private void radioButtonObjectColorT_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonObjectColorT.Checked == false)
                return;
            constObjectColor = false;
        }

        private void pictureBoxObjectColor_Click(object sender, EventArgs e)
        {
            parrarel = true;
            if (colorDialogObjectColor.ShowDialog() == DialogResult.OK)
            {
                objectColor = colorDialogObjectColor.Color;
                pictureBoxObjectColor.BackColor = objectColor;
            }
            parrarel = false;
        }

        private void pictureBoxLightColor_Click(object sender, EventArgs e)
        {
            parrarel = true;
            if (colorDialogObjectColor.ShowDialog() == DialogResult.OK)
            {
                lightColor = colorDialogObjectColor.Color;
                pictureBoxLightColor.BackColor = lightColor;
            }
            parrarel = false;
        }

        private void trackBarKs_Scroll(object sender, EventArgs e)
        {
            Ks = (double)trackBarKs.Value / (double)100;
            labelKsValue.Text = Ks.ToString();
            pictureBoxMap.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Kd = (double)trackBarKd.Value / (double)100;
            labelKdValue.Text = Kd.ToString();
            pictureBoxMap.Invalidate();
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            m = trackBarm.Value;
            labelmValue.Text = m.ToString();
            pictureBoxMap.Invalidate();
        }

        private void buttonChangeTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string path = @"normalMaps";
            path = Path.GetFullPath(path);
            dialog.InitialDirectory = path;
            dialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(dialog.FileName);
                normalMap = new Bitmap(img, new Size(500, 500));
            }
            pictureBoxMap.Invalidate();
        }

        class NormalVector
        {
            private double x, y, z;
            public double X
            {
                get { return x; }
                set { x = value; }
            }

            public double Y
            {
                get { return y; }
                set { y = value; }
            }

            public double Z
            {
                get { return z; }
                set { z = value; }
            }
        }

        private void radioButtonNormalMapConst_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNormalMapConst.Checked)
                constNormalVector = true;
        }

        private void radioButtonNormalMapFromFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNormalMapFromFile.Checked)
                constNormalVector = false;
        }

        private void radioButtonLightStationary_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLightStationary.Checked)
            {
                lightColor = pictureBoxLightColor.BackColor;
                lightStationary = true;
                lightChangeColor = false;
                th2 = null;
                th3 = null;
                pictureBoxMap.Invalidate();
            }
        }

        private void radioButtonLightRotating_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLightRotating.Checked)
            {
                lightColor = pictureBoxLightColor.BackColor;
                lightStationary = false;
                lightChangeColor = false;

                th3 = null;
                th2 = new Thread(new ThreadStart(RotateLight));
                th2.Start();
            }
        }

        private void RotateLight()
        {
            for (int i = 0; i < points.Count; i++) 
            {
                if (lightStationary != false)
                {
                    pictureBoxMap.Invalidate();
                    return;
                }
                dLz = (double)i / (double)points.Count;
                lightPos = points[i];
                Thread.Sleep(100);
            }
            th2 = new Thread(new ThreadStart(RotateLight));
            th2.Start();
        }

        private void ChangeColorsLight()
        {
            for (int i = 0; i < lightCirclePoints.Count; i++)
            {
                if (lightChangeColor == false)
                {
                    pictureBoxMap.Invalidate();
                    return;
                }
                dLz = (double)i / (double)points.Count;
                lightPos = lightCirclePoints[i];
                if (lightPos.X > 250)
                    lightColor = Color.Red;
                else if (lightPos.Y > 250)
                    lightColor = Color.Green;
                else
                    lightColor = Color.Blue;
                Thread.Sleep(100);
            }
            th3 = new Thread(new ThreadStart(ChangeColorsLight));
            th3.Start();
        }

        private void radioButtonAccurateFilling_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAccurateFilling.Checked)
            {
                interpolated = false;
                pictureBoxMap.Invalidate();
            }
        }

        private void radioButtonInterpolatedFilling_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInterpolatedFilling.Checked)
            {
                interpolated = true;
                pictureBoxMap.Invalidate();
            }
        }

        // Return points that define a spiral.
        private List<PointF> GetSpiralPoints(PointF center, float A, float angle_offset, float max_r)
        {
            // Get the points.
            points = new List<PointF>();
            const float dtheta = (float)(5 * Math.PI / 180);    // Five degrees.
            for (float theta = 0; ; theta += dtheta)
            {
                // Calculate r.
                float r = A * theta;

                // Convert to Cartesian coordinates.
                float x, y;
                PolarToCartesian(r, theta + angle_offset, out x, out y);

                // Center.
                x += center.X;
                y += center.Y;

                // Create the point.
                points.Add(new PointF((float)x, (float)y));

                // If we have gone far enough, stop.
                if (r > max_r) break;
            }
            return points;
        }

        // Convert polar coordinates into Cartesian coordinates.
        private void PolarToCartesian(float r, float theta,
            out float x, out float y)
        {
            x = (float)(r * Math.Cos(theta));
            y = (float)(r * Math.Sin(theta));
        }

        private List<Point> GetCirclePoints()
        {
            double slice = 2 * Math.PI / 360;
            double radius = R;
            Point center = new Point(250, 250);
            List<Point> points = new List<Point>();
            for (int i = 0; i < 360; i++)
            {
                double angle = slice * i;
                int newX = (int)(center.X + radius * Math.Cos(angle));
                int newY = (int)(center.Y + radius * Math.Sin(angle));
                Point p = new Point(newX, newY);
                points.Add(p);
            }
            return points;
        }

        private void DrawSpiral(Graphics graphics)
        {
            PointF center = new PointF(250, 250);
            int A = 9;
            float start_angle = 0;
            float max_r = 250;
            List<PointF> points = GetSpiralPoints(center, A, start_angle, max_r);
            graphics.DrawLines(Pens.Red,points.ToArray());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            parrarel = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            parrarel = false;
        }

        private void radioButtonChanginColorRotating_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonChanginColorRotating.Checked)
            {
                lightChangeColor = true;
                lightStationary = false;

                th3 = new Thread(new ThreadStart(ChangeColorsLight));
                th3.Start();
            }
        }

        private void numericUpDownR_ValueChanged(object sender, EventArgs e)
        {
            R = (int)numericUpDownR.Value;
        }

        class Triangle
        {
            //p1 - down in diagonal, p2 - up in diagonal, p3 - other
            private MyPoint[] points = new MyPoint[3];
            private List<Edge> AET = new List<Edge>();
            private Color[] colorsInPoints = new Color[3];
            private double area;

            public Triangle(Point p1, Point p2, Point p3)
            {
                points[0] = new MyPoint(p1, 0);
                points[1] = new MyPoint(p2, 1);
                points[2] = new MyPoint(p3, 2);
            }

            public void ChangePoint(Point p, int i)
            {
                if (i < 1 || i > 3)
                    return;

                points[i - 1].point = p;
            }

            public void Draw(Graphics graphics)
            {
                graphics.DrawLine(Pens.Black, points[0].point, points[1].point);
                graphics.DrawLine(Pens.Black, points[1].point, points[2].point);
                graphics.DrawLine(Pens.Black, points[2].point, points[0].point);
            }

            private void RemoveEdge(Point p1, Point p2)
            {
                for (int i = 0; i < AET.Count; i++)
                {
                    if (AET[i].p1.X == p1.X && AET[i].p1.Y == p1.Y && AET[i].p2.X == p2.X && AET[i].p2.Y == p2.Y)
                    {
                        AET.RemoveAt(i);
                        break;
                    }
                }
            }

            private double CalculateArea(Point p1, Point p2, Point p3)
            {
                double area = Math.Abs((p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X)) / 2.0;
                return area;
            }

            private NormalVector ConvertNormalMapToNormalVector(int x, int y)
            {
                Color c;
                lock (normalMap)
                {
                    c = normalMap.GetPixel(x, y);
                }
                NormalVector N = new NormalVector();

                N.X = c.R / 127.0 - 1.0;
                N.Y = c.G / 127.0 - 1.0;
                N.Z = c.B / 255.0;

                return N;
            }

            private Color CalculateColorForXandY(int x, int y)
            {
                Color objCol;
                if (constObjectColor)
                    objCol = objectColor;
                else
                    lock (texture)
                    {
                        objCol = texture.GetPixel(x, y);
                    }

                //Vector N
                NormalVector N = new NormalVector();
                if (constNormalVector)
                {
                    N.X = 0;
                    N.Y = 0;
                    N.Z = 1;
                }
                else
                    N = ConvertNormalMapToNormalVector(x, y);

                if (lightStationary == false)
                {
                    double d = Mesh.PointDistances(new Point(x, y), lightPos);
                    double k = d / 50;
                    if (d < 50)
                        L.Z = 1 - k * 3 * (d / 707) + dLz;
                    else
                        L.Z = 1 - k * 5 * (d / 707) + dLz;
                    if (L.Z > 1)
                        L.Z = 1;
                    if (L.Z < 0)
                        L.Z = 0;
                }
                else 
                    L.Z = 1;

                double mdx = Math.Max(500 - lightPos.X, lightPos.X);
                double mdy = Math.Max(500 - lightPos.Y, lightPos.Y);
                L.X = (lightPos.X - x) / mdx;
                L.Y = (lightPos.Y - y) / mdy;

                //CosNL
                double cosNL = (N.X * L.X + N.Y * L.Y + N.Z * L.Z);
                
                //R
                NormalVector R = new NormalVector();
                R.X = cosNL * N.X - L.X;
                R.Y = cosNL * N.Y - L.Y;
                R.Z = cosNL * N.Z - L.Z;

                double cosVR = (V.X * R.X + V.Y * R.Y + V.Z * R.Z);

                double X;
                X = Kd * lightColor.R / 255 * objCol.R / 255 * cosNL + Ks * lightColor.R / 255 * objCol.R / 255 * Math.Pow(cosVR, m);
                if (X > 1)
                    X = 1;
                if (X < 0)
                    X = 0;
                double Y;
                Y = Kd * lightColor.G / 255 * objCol.G / 255 * cosNL + Ks * lightColor.G / 255 * objCol.G / 255 * Math.Pow(cosVR, m);
                if (Y > 1)
                    Y = 1;
                if (Y < 0)
                    Y = 0;
                double Z;
                Z = Kd * lightColor.B / 255 * objCol.B / 255 * cosNL + Ks * lightColor.B / 255 * objCol.B / 255 * Math.Pow(cosVR, m);
                if (Z > 1)
                    Z = 1;
                if (Z < 0)
                    Z = 0;

                Color col = Color.FromArgb((int)(X * 255), (int)(Y * 255), (int)(Z * 255));
                return col;
            }

            private (double a, double b, double g) CalculateAlphaBetaGammaForPoint(Point p)
            {
                double a, b, g;
                double areaA, areaB, areaG;
                areaA = CalculateArea(p, points[1].point, points[2].point);
                areaB = CalculateArea(p, points[0].point, points[2].point);
                areaG = CalculateArea(p, points[0].point, points[1].point);
                a = areaA / area;
                b = areaB / area;
                g = areaG / area;
                return (a, b, g);
            }

            public void Fill(Graphics graphics)
            {
                int[] indexes = GetIndexesSortedByY();
                int yMin = points[indexes[0]].point.Y;
                int yMax = points[indexes[2]].point.Y;

                if (interpolated)
                {
                    colorsInPoints[0] = CalculateColorForXandY(points[0].point.X, points[0].point.Y);
                    colorsInPoints[1] = CalculateColorForXandY(points[1].point.X, points[1].point.Y);
                    colorsInPoints[2] = CalculateColorForXandY(points[2].point.X, points[2].point.Y);
                    area = CalculateArea(points[0].point, points[1].point, points[2].point);
                }


                for (int scanY = yMin; scanY <= yMax; scanY++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (points[indexes[k]].point.Y == scanY)
                        {
                            MyPoint previous = points[points[indexes[k]].PreviousIndex];
                            if (previous.point.Y > scanY)
                                AET.Add(new Edge(points[indexes[k]].point, previous.point));
                            else if (previous.point.Y < scanY)
                                RemoveEdge(previous.point, points[indexes[k]].point);
                            MyPoint next = points[points[indexes[k]].NextIndex];
                            if (next.point.Y > scanY)
                                AET.Add(new Edge(points[indexes[k]].point, next.point));
                            else if (next.point.Y < scanY)
                                RemoveEdge(next.point, points[indexes[k]].point);
                        }
                    }

                    if (AET.Count < 2)
                        break;

                    AET.Sort((e1, e2) => e1.x.CompareTo(e2.x));
                    for (int x = (int)AET[0].x; x <= (int)AET[1].x; x++)
                    {
                        Color col;
                        if (interpolated)
                        {
                            (double alpha, double beta, double gamma) = CalculateAlphaBetaGammaForPoint(new Point(x, scanY));
                            double X;
                            X = colorsInPoints[0].R * alpha + colorsInPoints[1].R * beta + colorsInPoints[2].R * gamma;
                            if (X > 255)
                                X = 255;
                            if (X < 0)
                                X = 0;
                            double Y;
                            Y = colorsInPoints[0].G * alpha + colorsInPoints[1].G * beta + colorsInPoints[2].G * gamma;
                            if (Y > 255)
                                Y = 255;
                            if (Y < 0)
                                Y = 0;
                            double Z;
                            Z = colorsInPoints[0].B * alpha + colorsInPoints[1].B * beta + colorsInPoints[2].B * gamma;
                            if (Z > 255)
                                Z = 255;
                            if (Z < 0)
                                Z = 0;
                            col = Color.FromArgb((int)(X), (int)(Y), (int)(Z));
                        }
                        else
                            col = CalculateColorForXandY(x, scanY);

                        lock (Form1.bitmap)
                        {
                            bitmap.SetPixel(x, scanY, col);
                        }
                    }

                    foreach (var e in AET)
                    {
                        e.x += e.m;
                    }
                }
            }

            private int[] GetIndexesSortedByY()
            {
                List<MyPoint> sorted = new List<MyPoint>(points);
                sorted.Sort((p1, p2) => p1.point.Y.CompareTo(p2.point.Y));
                int[] sortedIndexes = new int[3];
                sortedIndexes[0] = sorted[0].index;
                sortedIndexes[1] = sorted[1].index;
                sortedIndexes[2] = sorted[2].index;
                return sortedIndexes;
            }
        }
    }
}
