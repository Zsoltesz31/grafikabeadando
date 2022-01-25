namespace OszlopEpito
{
    partial class Form2
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
            this.exitBtn = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.requiredHeightTxt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentHeightTxt = new System.Windows.Forms.Label();
            this.heightSelection = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.leiras = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(626, 473);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(183, 60);
            this.exitBtn.TabIndex = 0;
            this.exitBtn.Text = "Kilépés";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(38, 46);
            this.canvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(566, 487);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // requiredHeightTxt
            // 
            this.requiredHeightTxt.AutoSize = true;
            this.requiredHeightTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.requiredHeightTxt.Location = new System.Drawing.Point(622, 46);
            this.requiredHeightTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.requiredHeightTxt.Name = "requiredHeightTxt";
            this.requiredHeightTxt.Size = new System.Drawing.Size(173, 20);
            this.requiredHeightTxt.TabIndex = 2;
            this.requiredHeightTxt.Text = "Elérendő magasság:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(38, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Játékmező";
            // 
            // currentHeightTxt
            // 
            this.currentHeightTxt.AutoSize = true;
            this.currentHeightTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentHeightTxt.Location = new System.Drawing.Point(622, 90);
            this.currentHeightTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentHeightTxt.Name = "currentHeightTxt";
            this.currentHeightTxt.Size = new System.Drawing.Size(172, 20);
            this.currentHeightTxt.TabIndex = 4;
            this.currentHeightTxt.Text = "Jelenlegi magasság:";
            // 
            // heightSelection
            // 
            this.heightSelection.FormattingEnabled = true;
            this.heightSelection.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.heightSelection.Location = new System.Drawing.Point(626, 197);
            this.heightSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.heightSelection.Name = "heightSelection";
            this.heightSelection.Size = new System.Drawing.Size(170, 21);
            this.heightSelection.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(626, 234);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Játék";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // leiras
            // 
            this.leiras.AutoSize = true;
            this.leiras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.leiras.Location = new System.Drawing.Point(619, 167);
            this.leiras.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.leiras.Name = "leiras";
            this.leiras.Size = new System.Drawing.Size(193, 17);
            this.leiras.TabIndex = 7;
            this.leiras.Text = "Válaszd ki a magasságot:";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(625, 269);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 31);
            this.button2.TabIndex = 8;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 556);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.leiras);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.heightSelection);
            this.Controls.Add(this.currentHeightTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.requiredHeightTxt);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.exitBtn);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label requiredHeightTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentHeightTxt;
        private System.Windows.Forms.ComboBox heightSelection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label leiras;
        private System.Windows.Forms.Button button2;
    }
}