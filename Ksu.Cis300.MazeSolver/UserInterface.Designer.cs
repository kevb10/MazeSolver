namespace Ksu.Cis300.MazeSolver
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxMaze = new Ksu.Cis300.MazeLibrary.Maze();
            this.uxButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxMaze
            // 
            this.uxMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMaze.Location = new System.Drawing.Point(12, 12);
            this.uxMaze.Name = "uxMaze";
            this.uxMaze.PathColor = System.Drawing.SystemColors.Highlight;
            this.uxMaze.Size = new System.Drawing.Size(543, 252);
            this.uxMaze.TabIndex = 0;
            this.uxMaze.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uxMaze_MouseClick);
            // 
            // uxButton
            // 
            this.uxButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButton.Location = new System.Drawing.Point(227, 270);
            this.uxButton.MinimumSize = new System.Drawing.Size(131, 37);
            this.uxButton.Name = "uxButton";
            this.uxButton.Size = new System.Drawing.Size(131, 37);
            this.uxButton.TabIndex = 1;
            this.uxButton.Text = "New Maze";
            this.uxButton.UseVisualStyleBackColor = true;
            this.uxButton.Click += new System.EventHandler(this.uxButton_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 319);
            this.Controls.Add(this.uxButton);
            this.Controls.Add(this.uxMaze);
            this.Name = "UserInterface";
            this.Text = "Maze Solver";
            this.ResumeLayout(false);

        }

        #endregion

        private MazeLibrary.Maze uxMaze;
        private System.Windows.Forms.Button uxButton;
    }
}

