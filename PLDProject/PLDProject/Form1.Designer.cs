namespace PLDProject
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            input = new TextBox();
            Output = new ListBox();
            SuspendLayout();
            // 
            // input
            // 
            input.BackColor = SystemColors.GradientActiveCaption;
            input.Location = new Point(21, 12);
            input.Multiline = true;
            input.Name = "input";
            input.Size = new Size(380, 345);
            input.TabIndex = 0;
            input.TextChanged += input_TextChanged;
            // 
            // Output
            // 
            Output.BackColor = SystemColors.InactiveCaption;
            Output.ForeColor = SystemColors.InfoText;
            Output.FormattingEnabled = true;
            Output.Location = new Point(511, 26);
            Output.Name = "Output";
            Output.Size = new Size(393, 324);
            Output.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 450);
            Controls.Add(Output);
            Controls.Add(input);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox input;
        private ListBox Output;
    }
}
