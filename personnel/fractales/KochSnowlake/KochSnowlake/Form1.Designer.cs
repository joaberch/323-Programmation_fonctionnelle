using System.Security.Cryptography.X509Certificates;

namespace KochSnowlake
{
    partial class Form1
    {
        public Panel drawingPanel;
        public NumericUpDown num;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //Title
            Label title = new Label()
            {
                Text = "Fractales",
                Name = "Fractales",
                Location = new Point(300, 10),
                Font = new Font("Arial", 24, FontStyle.Bold),
                Size = new Size(170, 30)
            };
            this.Controls.Add(title);

            //Number of iteration
            Label iteration = new Label()
            {
                Text = "Iteration number:",
                Location = new Point(650, 60)
            };
            num = new NumericUpDown()
            {
                Location = new Point(650, 80),
                Value = 1,
                //Minimum = 1,
            };
            num.Paint += new PaintEventHandler((sender, e) => { });
            num.ValueChanged += new EventHandler((sender, e) => DrawingPanel_koch(sender, e, 50, 50, 0));
            this.Controls.Add(num);
            this.Controls.Add(iteration);


            //Panel
            drawingPanel = new Panel()
            {
                Location = new Point(20, 59),
                Name = "drawingPanel",
                Size = new Size(600, 300),
                TabIndex = 0,
                BorderStyle = BorderStyle.FixedSingle,
            };
            drawingPanel.Paint += new PaintEventHandler((sender, e) => DrawingPanel_koch(sender, e, 50, 50, 0));

            this.Controls.Add(drawingPanel);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Fractales";
        }

        private void DrawingPanel_koch(object sender, PaintEventArgs e, int xPos, int yPos, int iteration)
        {
            Pen pen = new Pen(Color.Blue);
            int x = xPos;
            int y = yPos;

            e.Graphics.DrawLine(pen, new Point(x, y), new Point(x+= 50, y));
            pen.Color = Color.Red;
            e.Graphics.DrawLine(pen, new Point(x, y), new Point(x += 25, y -= 25));
            e.Graphics.DrawLine(pen, new Point(x, y), new Point(x += 25, y += 25));
            pen.Color = Color.Blue;
            e.Graphics.DrawLine(pen, new Point(x, y), new Point(x += 50, y));
            if (!(++iteration == num.Value))
            {
                DrawingPanel_koch(sender, e, xPos, yPos, iteration);
            }
        }
    }
}
