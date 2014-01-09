namespace EvolveSharp.Samples.Tsp
{
    partial class DefaultForm
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
            this.generateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfPoints = new System.Windows.Forms.TextBox();
            this.numberOfGenerations = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.populationSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mutabilityPercent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(221, 115);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(264, 97);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 200);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of points";
            // 
            // numberOfPoints
            // 
            this.numberOfPoints.Location = new System.Drawing.Point(221, 31);
            this.numberOfPoints.Name = "numberOfPoints";
            this.numberOfPoints.Size = new System.Drawing.Size(129, 20);
            this.numberOfPoints.TabIndex = 3;
            this.numberOfPoints.Text = "20";
            // 
            // numberOfGenerations
            // 
            this.numberOfGenerations.Location = new System.Drawing.Point(356, 31);
            this.numberOfGenerations.Name = "numberOfGenerations";
            this.numberOfGenerations.Size = new System.Drawing.Size(129, 20);
            this.numberOfGenerations.TabIndex = 5;
            this.numberOfGenerations.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of generations";
            // 
            // populationSize
            // 
            this.populationSize.Location = new System.Drawing.Point(356, 77);
            this.populationSize.Name = "populationSize";
            this.populationSize.Size = new System.Drawing.Size(129, 20);
            this.populationSize.TabIndex = 9;
            this.populationSize.Text = "300";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Population size";
            // 
            // mutabilityPercent
            // 
            this.mutabilityPercent.Location = new System.Drawing.Point(221, 77);
            this.mutabilityPercent.Name = "mutabilityPercent";
            this.mutabilityPercent.Size = new System.Drawing.Size(129, 20);
            this.mutabilityPercent.TabIndex = 7;
            this.mutabilityPercent.Text = "0.7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mutability percent";
            // 
            // DefaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(493, 225);
            this.Controls.Add(this.populationSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mutabilityPercent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numberOfGenerations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberOfPoints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.generateButton);
            this.MaximizeBox = false;
            this.Name = "DefaultForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TSP Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DefaultForm_FormClosing);
            this.Load += new System.EventHandler(this.DefaultForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numberOfPoints;
        private System.Windows.Forms.TextBox numberOfGenerations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox populationSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mutabilityPercent;
        private System.Windows.Forms.Label label4;
    }
}

