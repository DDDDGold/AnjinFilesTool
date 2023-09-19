namespace AnjinFilesTool.Forms
{
    partial class InputDialog
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
            input = new TextBox();
            okBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // input
            // 
            input.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            input.Location = new Point(85, 48);
            input.Name = "input";
            input.Size = new Size(340, 43);
            input.TabIndex = 0;
            // 
            // okBtn
            // 
            okBtn.DialogResult = DialogResult.OK;
            okBtn.Location = new Point(179, 136);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(150, 46);
            okBtn.TabIndex = 1;
            okBtn.Text = "确定";
            okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.DialogResult = DialogResult.Cancel;
            cancelBtn.Location = new Point(354, 136);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(150, 46);
            cancelBtn.TabIndex = 2;
            cancelBtn.Text = "取消";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // InputDialog
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 194);
            Controls.Add(cancelBtn);
            Controls.Add(okBtn);
            Controls.Add(input);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "InputDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "请输入新文件名";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button okBtn;
        private Button cancelBtn;
        public TextBox input;
    }
}