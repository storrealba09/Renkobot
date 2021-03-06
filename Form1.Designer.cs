﻿namespace BitMexSampleBot
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
            this.components = new System.ComponentModel.Container();
            this.ddlNetwork = new System.Windows.Forms.ComboBox();
            this.ddlSymbol = new System.Windows.Forms.ComboBox();
            this.tmrUpdater = new System.Windows.Forms.Timer(this.components);
            this.rdoBuy = new System.Windows.Forms.RadioButton();
            this.rdoSell = new System.Windows.Forms.RadioButton();
            this.rdoSwitch = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.nudBoxSize = new System.Windows.Forms.NumericUpDown();
            this.btnAutomatedTrading = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxSize)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlNetwork
            // 
            this.ddlNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlNetwork.FormattingEnabled = true;
            this.ddlNetwork.Items.AddRange(new object[] {
            "TestNet",
            "RealNet"});
            this.ddlNetwork.Location = new System.Drawing.Point(273, 5);
            this.ddlNetwork.Name = "ddlNetwork";
            this.ddlNetwork.Size = new System.Drawing.Size(73, 21);
            this.ddlNetwork.TabIndex = 6;
            this.ddlNetwork.SelectedIndexChanged += new System.EventHandler(this.ddlNetwork_SelectedIndexChanged);
            // 
            // ddlSymbol
            // 
            this.ddlSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSymbol.FormattingEnabled = true;
            this.ddlSymbol.Location = new System.Drawing.Point(397, 5);
            this.ddlSymbol.Name = "ddlSymbol";
            this.ddlSymbol.Size = new System.Drawing.Size(73, 21);
            this.ddlSymbol.TabIndex = 7;
            this.ddlSymbol.SelectedIndexChanged += new System.EventHandler(this.ddlSymbol_SelectedIndexChanged);
            // 
            // tmrUpdater
            // 
            this.tmrUpdater.Interval = 5000;
            this.tmrUpdater.Tick += new System.EventHandler(this.tmrUpdater_Tick);
            // 
            // rdoBuy
            // 
            this.rdoBuy.AutoSize = true;
            this.rdoBuy.Checked = true;
            this.rdoBuy.Location = new System.Drawing.Point(142, 13);
            this.rdoBuy.Name = "rdoBuy";
            this.rdoBuy.Size = new System.Drawing.Size(43, 17);
            this.rdoBuy.TabIndex = 11;
            this.rdoBuy.TabStop = true;
            this.rdoBuy.Text = "Buy";
            this.rdoBuy.UseVisualStyleBackColor = true;
            // 
            // rdoSell
            // 
            this.rdoSell.AutoSize = true;
            this.rdoSell.Location = new System.Drawing.Point(142, 31);
            this.rdoSell.Name = "rdoSell";
            this.rdoSell.Size = new System.Drawing.Size(42, 17);
            this.rdoSell.TabIndex = 12;
            this.rdoSell.Text = "Sell";
            this.rdoSell.UseVisualStyleBackColor = true;
            // 
            // rdoSwitch
            // 
            this.rdoSwitch.AutoSize = true;
            this.rdoSwitch.Location = new System.Drawing.Point(142, 47);
            this.rdoSwitch.Name = "rdoSwitch";
            this.rdoSwitch.Size = new System.Drawing.Size(57, 17);
            this.rdoSwitch.TabIndex = 13;
            this.rdoSwitch.Text = "Switch";
            this.rdoSwitch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.nudBoxSize);
            this.groupBox1.Controls.Add(this.btnAutomatedTrading);
            this.groupBox1.Controls.Add(this.rdoSell);
            this.groupBox1.Controls.Add(this.rdoSwitch);
            this.groupBox1.Controls.Add(this.rdoBuy);
            this.groupBox1.Location = new System.Drawing.Point(162, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 69);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automated Trading";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(266, 12);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(67, 20);
            this.txtQty.TabIndex = 16;
            // 
            // nudBoxSize
            // 
            this.nudBoxSize.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudBoxSize.Location = new System.Drawing.Point(266, 43);
            this.nudBoxSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBoxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBoxSize.Name = "nudBoxSize";
            this.nudBoxSize.Size = new System.Drawing.Size(67, 20);
            this.nudBoxSize.TabIndex = 15;
            this.nudBoxSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnAutomatedTrading
            // 
            this.btnAutomatedTrading.BackColor = System.Drawing.Color.LightGreen;
            this.btnAutomatedTrading.Location = new System.Drawing.Point(7, 20);
            this.btnAutomatedTrading.Name = "btnAutomatedTrading";
            this.btnAutomatedTrading.Size = new System.Drawing.Size(119, 43);
            this.btnAutomatedTrading.TabIndex = 14;
            this.btnAutomatedTrading.Text = "Start";
            this.btnAutomatedTrading.UseVisualStyleBackColor = false;
            this.btnAutomatedTrading.Click += new System.EventHandler(this.btnAutomatedTrading_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 150);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ddlSymbol);
            this.Controls.Add(this.ddlNetwork);
            this.Name = "Form1";
            this.Text = "BitMex Simple Bot";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox ddlNetwork;
        private System.Windows.Forms.ComboBox ddlSymbol;
        private System.Windows.Forms.Timer tmrUpdater;
        private System.Windows.Forms.RadioButton rdoBuy;
        private System.Windows.Forms.RadioButton rdoSell;
        private System.Windows.Forms.RadioButton rdoSwitch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAutomatedTrading;
        private System.Windows.Forms.NumericUpDown nudBoxSize;
        private System.Windows.Forms.TextBox txtQty;
    }
}

