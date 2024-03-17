namespace CapaPresentacion.Modales
{
    partial class MyMessageBoxForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMessageBoxForm));
            this.lblMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picSi = new System.Windows.Forms.PictureBox();
            this.picNo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.White;
            this.lblMessage.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(120, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(340, 36);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "NECESITA MAS TIEMPO?";
            // 
            // picSi
            // 
            this.picSi.BackColor = System.Drawing.Color.White;
            this.picSi.Image = ((System.Drawing.Image)(resources.GetObject("picSi.Image")));
            this.picSi.Location = new System.Drawing.Point(4, 239);
            this.picSi.Name = "picSi";
            this.picSi.Size = new System.Drawing.Size(112, 92);
            this.picSi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSi.TabIndex = 3;
            this.picSi.TabStop = false;
            this.picSi.Click += new System.EventHandler(this.picSi_Click);
            // 
            // picNo
            // 
            this.picNo.BackColor = System.Drawing.Color.White;
            this.picNo.Image = ((System.Drawing.Image)(resources.GetObject("picNo.Image")));
            this.picNo.Location = new System.Drawing.Point(469, 240);
            this.picNo.Name = "picNo";
            this.picNo.Size = new System.Drawing.Size(112, 92);
            this.picNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNo.TabIndex = 4;
            this.picNo.TabStop = false;
            this.picNo.Click += new System.EventHandler(this.picNo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(584, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // MyMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 337);
            this.Controls.Add(this.picNo);
            this.Controls.Add(this.picSi);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyMessageBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMessageBoxForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyMessageBoxForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyMessageBoxForm_FormClosed);
            this.Load += new System.EventHandler(this.MyMessageBoxForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picSi;
        private System.Windows.Forms.PictureBox picNo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}