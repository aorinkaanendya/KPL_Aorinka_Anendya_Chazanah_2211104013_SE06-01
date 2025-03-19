namespace tpmodul3_2211104013
{
    partial class Form1
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
            submit_btn = new Button();
            txtInput = new TextBox();
            label_output = new Label();
            SuspendLayout();
            // 
            // submit_btn
            // 
            submit_btn.BackColor = Color.ForestGreen;
            submit_btn.Font = new Font("Arial Narrow", 10F, FontStyle.Bold);
            submit_btn.ForeColor = SystemColors.ButtonFace;
            submit_btn.Location = new Point(752, 180);
            submit_btn.Margin = new Padding(5, 6, 5, 6);
            submit_btn.Name = "submit_btn";
            submit_btn.Size = new Size(120, 35);
            submit_btn.TabIndex = 0;
            submit_btn.Text = "Submit";
            submit_btn.UseVisualStyleBackColor = false;
            submit_btn.Click += button1_Click;
            // 
            // txtInput
            // 
            txtInput.BackColor = Color.LightCoral;
            txtInput.Font = new Font("Arial Narrow", 10F, FontStyle.Bold);
            txtInput.ForeColor = SystemColors.Menu;
            txtInput.Location = new Point(207, 180);
            txtInput.Margin = new Padding(5, 6, 5, 6);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(451, 30);
            txtInput.TabIndex = 1;
            txtInput.Text = "Masukkan Nama Anda";
            txtInput.TextAlign = HorizontalAlignment.Center;
            txtInput.TextChanged += txtInput_TextChanged;
            // 
            // label_output
            // 
            label_output.AutoSize = true;
            label_output.BackColor = Color.LightCoral;
            label_output.BorderStyle = BorderStyle.Fixed3D;
            label_output.Font = new Font("Arial Narrow", 10F, FontStyle.Bold);
            label_output.ForeColor = SystemColors.ControlLightLight;
            label_output.Location = new Point(207, 261);
            label_output.Margin = new Padding(5, 0, 5, 0);
            label_output.Name = "label_output";
            label_output.Size = new Size(65, 26);
            label_output.TabIndex = 2;
            label_output.Text = "Output";
            label_output.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1152, 528);
            Controls.Add(label_output);
            Controls.Add(txtInput);
            Controls.Add(submit_btn);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label_output;
    }
}