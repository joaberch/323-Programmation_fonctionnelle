namespace KochSnowlake
{
    partial class Form1
    {
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
            //Panel
            Panel drawingPanel = new Panel()
            {
                Location = new Point(90, 59),
                Name = "drawingPanel",
                Size = new Size(800, 600),
                TabIndex = 0,
            };
            drawingPanel.Paint += DrawingPanel_Paint;
            this.Controls.Add(drawingPanel);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Blue, 1))
            {
                e.Graphics.DrawLine(pen, new Point(50, 50), new Point(75, 65));
            }
        }
    }
}
