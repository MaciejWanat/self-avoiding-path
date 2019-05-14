namespace SelfAvoidingPaths
{
    partial class WalksForm
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathLength = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.trkWalk = new System.Windows.Forms.TrackBar();
            this.lblWalkNum = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cbFixedSideSize = new System.Windows.Forms.CheckBox();
            this.cbVisualize = new System.Windows.Forms.CheckBox();
            this.lblApprox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkWalk)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(240, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(220, 220);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path length:";
            // 
            // txtPathLength
            // 
            this.txtPathLength.Location = new System.Drawing.Point(82, 12);
            this.txtPathLength.Name = "txtPathLength";
            this.txtPathLength.Size = new System.Drawing.Size(42, 20);
            this.txtPathLength.TabIndex = 2;
            this.txtPathLength.Text = "4";
            this.txtPathLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(35, 52);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 83);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(0, 13);
            this.lblResults.TabIndex = 6;
            // 
            // trkWalk
            // 
            this.trkWalk.Location = new System.Drawing.Point(12, 108);
            this.trkWalk.Name = "trkWalk";
            this.trkWalk.Size = new System.Drawing.Size(204, 45);
            this.trkWalk.TabIndex = 7;
            this.trkWalk.Visible = false;
            this.trkWalk.Scroll += new System.EventHandler(this.TrkWalk_Scroll);
            // 
            // lblWalkNum
            // 
            this.lblWalkNum.AutoSize = true;
            this.lblWalkNum.Location = new System.Drawing.Point(12, 160);
            this.lblWalkNum.Name = "lblWalkNum";
            this.lblWalkNum.Size = new System.Drawing.Size(0, 13);
            this.lblWalkNum.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Terminate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Terminate_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(-2, 228);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 10;
            // 
            // cbFixedSideSize
            // 
            this.cbFixedSideSize.AutoSize = true;
            this.cbFixedSideSize.Checked = true;
            this.cbFixedSideSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFixedSideSize.Location = new System.Drawing.Point(140, 29);
            this.cbFixedSideSize.Name = "cbFixedSideSize";
            this.cbFixedSideSize.Size = new System.Drawing.Size(94, 17);
            this.cbFixedSideSize.TabIndex = 11;
            this.cbFixedSideSize.Text = "Fixed side size";
            this.cbFixedSideSize.UseVisualStyleBackColor = true;
            // 
            // cbVisualize
            // 
            this.cbVisualize.AutoSize = true;
            this.cbVisualize.Checked = true;
            this.cbVisualize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVisualize.Location = new System.Drawing.Point(140, 11);
            this.cbVisualize.Name = "cbVisualize";
            this.cbVisualize.Size = new System.Drawing.Size(67, 17);
            this.cbVisualize.TabIndex = 12;
            this.cbVisualize.Text = "Visualize";
            this.cbVisualize.UseVisualStyleBackColor = true;
            // 
            // lblApprox
            // 
            this.lblApprox.AutoSize = true;
            this.lblApprox.Location = new System.Drawing.Point(-2, 215);
            this.lblApprox.Name = "lblApprox";
            this.lblApprox.Size = new System.Drawing.Size(0, 13);
            this.lblApprox.TabIndex = 13;
            // 
            // WalksForm
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 241);
            this.Controls.Add(this.lblApprox);
            this.Controls.Add(this.cbVisualize);
            this.Controls.Add(this.cbFixedSideSize);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblWalkNum);
            this.Controls.Add(this.trkWalk);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtPathLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "WalksForm";
            this.Text = "Self avoiding paths";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkWalk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathLength;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.TrackBar trkWalk;
        private System.Windows.Forms.Label lblWalkNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox cbFixedSideSize;
        private System.Windows.Forms.CheckBox cbVisualize;
        private System.Windows.Forms.Label lblApprox;
    }
}

