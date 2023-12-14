
namespace Klient
{
    partial class HoroscopeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoroscopeForm));
            this.firstPersonDate = new System.Windows.Forms.TextBox();
            this.firstPersonYear = new System.Windows.Forms.TextBox();
            this.secondPersonDate = new System.Windows.Forms.TextBox();
            this.secondPersonYear = new System.Windows.Forms.TextBox();
            this.firstPersonMonth = new System.Windows.Forms.ComboBox();
            this.secondPersonMonth = new System.Windows.Forms.ComboBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.fortuneTellingStyle = new System.Windows.Forms.ComboBox();
            this.fortuneTellingResult = new System.Windows.Forms.RichTextBox();
            this.formatExplanationLabel = new System.Windows.Forms.Label();
            this.pdfButton = new System.Windows.Forms.Button();
            this.txtButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstPersonDate
            // 
            resources.ApplyResources(this.firstPersonDate, "firstPersonDate");
            this.firstPersonDate.Name = "firstPersonDate";
            this.firstPersonDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // firstPersonYear
            // 
            resources.ApplyResources(this.firstPersonYear, "firstPersonYear");
            this.firstPersonYear.Name = "firstPersonYear";
            // 
            // secondPersonDate
            // 
            resources.ApplyResources(this.secondPersonDate, "secondPersonDate");
            this.secondPersonDate.Name = "secondPersonDate";
            // 
            // secondPersonYear
            // 
            resources.ApplyResources(this.secondPersonYear, "secondPersonYear");
            this.secondPersonYear.Name = "secondPersonYear";
            // 
            // firstPersonMonth
            // 
            resources.ApplyResources(this.firstPersonMonth, "firstPersonMonth");
            this.firstPersonMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.firstPersonMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstPersonMonth.FormattingEnabled = true;
            this.firstPersonMonth.Name = "firstPersonMonth";
            // 
            // secondPersonMonth
            // 
            resources.ApplyResources(this.secondPersonMonth, "secondPersonMonth");
            this.secondPersonMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.secondPersonMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondPersonMonth.FormattingEnabled = true;
            this.secondPersonMonth.Name = "secondPersonMonth";
            // 
            // sendButton
            // 
            resources.ApplyResources(this.sendButton, "sendButton");
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.Name = "sendButton";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // fortuneTellingStyle
            // 
            resources.ApplyResources(this.fortuneTellingStyle, "fortuneTellingStyle");
            this.fortuneTellingStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fortuneTellingStyle.FormattingEnabled = true;
            this.fortuneTellingStyle.Name = "fortuneTellingStyle";
            // 
            // fortuneTellingResult
            // 
            resources.ApplyResources(this.fortuneTellingResult, "fortuneTellingResult");
            this.fortuneTellingResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fortuneTellingResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.fortuneTellingResult.Name = "fortuneTellingResult";
            this.fortuneTellingResult.ReadOnly = true;
            // 
            // formatExplanationLabel
            // 
            resources.ApplyResources(this.formatExplanationLabel, "formatExplanationLabel");
            this.formatExplanationLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formatExplanationLabel.Name = "formatExplanationLabel";
            // 
            // pdfButton
            // 
            resources.ApplyResources(this.pdfButton, "pdfButton");
            this.pdfButton.Name = "pdfButton";
            this.pdfButton.UseVisualStyleBackColor = true;
            this.pdfButton.Click += new System.EventHandler(this.pdfButton_Click);
            // 
            // txtButton
            // 
            resources.ApplyResources(this.txtButton, "txtButton");
            this.txtButton.Name = "txtButton";
            this.txtButton.UseVisualStyleBackColor = true;
            this.txtButton.Click += new System.EventHandler(this.txtButton_Click);
            // 
            // HoroscopeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtButton);
            this.Controls.Add(this.pdfButton);
            this.Controls.Add(this.formatExplanationLabel);
            this.Controls.Add(this.fortuneTellingResult);
            this.Controls.Add(this.fortuneTellingStyle);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.secondPersonMonth);
            this.Controls.Add(this.firstPersonMonth);
            this.Controls.Add(this.secondPersonYear);
            this.Controls.Add(this.secondPersonDate);
            this.Controls.Add(this.firstPersonYear);
            this.Controls.Add(this.firstPersonDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HoroscopeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox firstPersonDate;
        private System.Windows.Forms.TextBox firstPersonYear;
        private System.Windows.Forms.TextBox secondPersonDate;
        private System.Windows.Forms.TextBox secondPersonYear;
        private System.Windows.Forms.ComboBox firstPersonMonth;
        private System.Windows.Forms.ComboBox secondPersonMonth;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox fortuneTellingStyle;
        private System.Windows.Forms.RichTextBox fortuneTellingResult;
        private System.Windows.Forms.Label formatExplanationLabel;
        private System.Windows.Forms.Button pdfButton;
        private System.Windows.Forms.Button txtButton;
    }
}

