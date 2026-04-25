namespace SIPS.UI
{
    partial class Registeration
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
            label1 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(346, 126);
            label1.Name = "label1";
            label1.Size = new Size(366, 45);
            label1.TabIndex = 0;
            label1.Text = "Create a New Account";
            // 
            // button1
            // 
            button1.Location = new Point(437, 463);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(481, 239);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(329, 31);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(346, 245);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 0;
            label2.Text = "Name";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(350, 297);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 5;
            label3.Text = "Email";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(346, 348);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 6;
            label4.Text = "Password";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(346, 401);
            label5.Name = "label5";
            label5.Size = new Size(80, 25);
            label5.TabIndex = 7;
            label5.Text = "Address";
            label5.Click += label5_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(481, 395);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(329, 31);
            textBox2.TabIndex = 8;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(481, 342);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(327, 31);
            textBox3.TabIndex = 9;
            textBox3.UseSystemPasswordChar = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(481, 291);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(325, 31);
            textBox4.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(609, 521);
            button2.Name = "button2";
            button2.Size = new Size(201, 34);
            button2.TabIndex = 11;
            button2.Text = "Back to Login";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Registeration
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 744);
            Controls.Add(button2);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Registeration";
            Text = "Form1";
            Load += Registeration_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button2;
    }
}