namespace SourceCode
{
    partial class mainFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrame));
            this.bunifuElipse = new ns1.BunifuElipse(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnClose = new ns1.BunifuImageButton();
            this.dragCtrHeader = new ns1.BunifuDragControl(this.components);
            this.groupBoxUM = new System.Windows.Forms.GroupBox();
            this.btnCreateUM = new ns1.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textColUM = new System.Windows.Forms.TextBox();
            this.textRowUM = new System.Windows.Forms.TextBox();
            this.dataUM = new System.Windows.Forms.DataGridView();
            this.groupBoxAFM = new System.Windows.Forms.GroupBox();
            this.btnCreateAFM = new ns1.BunifuFlatButton();
            this.dataAFM = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textRowAFM = new System.Windows.Forms.TextBox();
            this.textColAFM = new System.Windows.Forms.TextBox();
            this.groupBoxCA = new System.Windows.Forms.GroupBox();
            this.dataCA = new System.Windows.Forms.DataGridView();
            this.groupBoxAA = new System.Windows.Forms.GroupBox();
            this.dataAA = new System.Windows.Forms.DataGridView();
            this.groupBoxVF = new System.Windows.Forms.GroupBox();
            this.btnClear = new ns1.BunifuThinButton2();
            this.btnCalculate = new ns1.BunifuThinButton2();
            this.groupBoxLogs = new System.Windows.Forms.GroupBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.groupBoxUM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataUM)).BeginInit();
            this.groupBoxAFM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAFM)).BeginInit();
            this.groupBoxCA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCA)).BeginInit();
            this.groupBoxAA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAA)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 5;
            this.bunifuElipse.TargetControl = this;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1315, 42);
            this.panelHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::SourceCode.Properties.Resources.icons8_multiply_filled_black;
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(1273, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 42);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dragCtrHeader
            // 
            this.dragCtrHeader.Fixed = true;
            this.dragCtrHeader.Horizontal = true;
            this.dragCtrHeader.TargetControl = this.panelHeader;
            this.dragCtrHeader.Vertical = true;
            // 
            // groupBoxUM
            // 
            this.groupBoxUM.Controls.Add(this.btnCreateUM);
            this.groupBoxUM.Controls.Add(this.label1);
            this.groupBoxUM.Controls.Add(this.textColUM);
            this.groupBoxUM.Controls.Add(this.textRowUM);
            this.groupBoxUM.Controls.Add(this.dataUM);
            this.groupBoxUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxUM.Location = new System.Drawing.Point(14, 48);
            this.groupBoxUM.Name = "groupBoxUM";
            this.groupBoxUM.Size = new System.Drawing.Size(424, 289);
            this.groupBoxUM.TabIndex = 1;
            this.groupBoxUM.TabStop = false;
            this.groupBoxUM.Text = "Usage Matrix :";
            // 
            // btnCreateUM
            // 
            this.btnCreateUM.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCreateUM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCreateUM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateUM.BorderRadius = 0;
            this.btnCreateUM.ButtonText = "Create";
            this.btnCreateUM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateUM.DisabledColor = System.Drawing.Color.Gray;
            this.btnCreateUM.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCreateUM.Iconimage = null;
            this.btnCreateUM.Iconimage_right = null;
            this.btnCreateUM.Iconimage_right_Selected = null;
            this.btnCreateUM.Iconimage_Selected = null;
            this.btnCreateUM.IconMarginLeft = 0;
            this.btnCreateUM.IconMarginRight = 0;
            this.btnCreateUM.IconRightVisible = true;
            this.btnCreateUM.IconRightZoom = 0D;
            this.btnCreateUM.IconVisible = true;
            this.btnCreateUM.IconZoom = 90D;
            this.btnCreateUM.IsTab = false;
            this.btnCreateUM.Location = new System.Drawing.Point(134, 16);
            this.btnCreateUM.Name = "btnCreateUM";
            this.btnCreateUM.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCreateUM.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnCreateUM.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCreateUM.selected = false;
            this.btnCreateUM.Size = new System.Drawing.Size(61, 20);
            this.btnCreateUM.TabIndex = 4;
            this.btnCreateUM.Text = "Create";
            this.btnCreateUM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCreateUM.Textcolor = System.Drawing.Color.White;
            this.btnCreateUM.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateUM.Click += new System.EventHandler(this.btnCreateUM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            // 
            // textColUM
            // 
            this.textColUM.Location = new System.Drawing.Point(80, 16);
            this.textColUM.Name = "textColUM";
            this.textColUM.Size = new System.Drawing.Size(48, 20);
            this.textColUM.TabIndex = 2;
            // 
            // textRowUM
            // 
            this.textRowUM.Location = new System.Drawing.Point(6, 16);
            this.textRowUM.Name = "textRowUM";
            this.textRowUM.Size = new System.Drawing.Size(48, 20);
            this.textRowUM.TabIndex = 1;
            // 
            // dataUM
            // 
            this.dataUM.AllowUserToAddRows = false;
            this.dataUM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataUM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUM.Location = new System.Drawing.Point(6, 42);
            this.dataUM.Name = "dataUM";
            this.dataUM.Size = new System.Drawing.Size(402, 241);
            this.dataUM.TabIndex = 0;
            // 
            // groupBoxAFM
            // 
            this.groupBoxAFM.Controls.Add(this.btnCreateAFM);
            this.groupBoxAFM.Controls.Add(this.dataAFM);
            this.groupBoxAFM.Controls.Add(this.label2);
            this.groupBoxAFM.Controls.Add(this.textRowAFM);
            this.groupBoxAFM.Controls.Add(this.textColAFM);
            this.groupBoxAFM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAFM.Location = new System.Drawing.Point(14, 343);
            this.groupBoxAFM.Name = "groupBoxAFM";
            this.groupBoxAFM.Size = new System.Drawing.Size(424, 289);
            this.groupBoxAFM.TabIndex = 2;
            this.groupBoxAFM.TabStop = false;
            this.groupBoxAFM.Text = "Access Frequency :";
            // 
            // btnCreateAFM
            // 
            this.btnCreateAFM.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCreateAFM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCreateAFM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateAFM.BorderRadius = 0;
            this.btnCreateAFM.ButtonText = "Create";
            this.btnCreateAFM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateAFM.DisabledColor = System.Drawing.Color.Gray;
            this.btnCreateAFM.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCreateAFM.Iconimage = null;
            this.btnCreateAFM.Iconimage_right = null;
            this.btnCreateAFM.Iconimage_right_Selected = null;
            this.btnCreateAFM.Iconimage_Selected = null;
            this.btnCreateAFM.IconMarginLeft = 0;
            this.btnCreateAFM.IconMarginRight = 0;
            this.btnCreateAFM.IconRightVisible = true;
            this.btnCreateAFM.IconRightZoom = 0D;
            this.btnCreateAFM.IconVisible = true;
            this.btnCreateAFM.IconZoom = 90D;
            this.btnCreateAFM.IsTab = false;
            this.btnCreateAFM.Location = new System.Drawing.Point(134, 16);
            this.btnCreateAFM.Name = "btnCreateAFM";
            this.btnCreateAFM.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCreateAFM.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnCreateAFM.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCreateAFM.selected = false;
            this.btnCreateAFM.Size = new System.Drawing.Size(61, 20);
            this.btnCreateAFM.TabIndex = 9;
            this.btnCreateAFM.Text = "Create";
            this.btnCreateAFM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCreateAFM.Textcolor = System.Drawing.Color.White;
            this.btnCreateAFM.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAFM.Click += new System.EventHandler(this.btnCreateAFM_Click);
            // 
            // dataAFM
            // 
            this.dataAFM.AllowUserToAddRows = false;
            this.dataAFM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataAFM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAFM.Location = new System.Drawing.Point(6, 42);
            this.dataAFM.Name = "dataAFM";
            this.dataAFM.Size = new System.Drawing.Size(402, 241);
            this.dataAFM.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "X";
            // 
            // textRowAFM
            // 
            this.textRowAFM.Location = new System.Drawing.Point(6, 16);
            this.textRowAFM.Name = "textRowAFM";
            this.textRowAFM.Size = new System.Drawing.Size(48, 20);
            this.textRowAFM.TabIndex = 6;
            // 
            // textColAFM
            // 
            this.textColAFM.Location = new System.Drawing.Point(80, 16);
            this.textColAFM.Name = "textColAFM";
            this.textColAFM.Size = new System.Drawing.Size(48, 20);
            this.textColAFM.TabIndex = 7;
            // 
            // groupBoxCA
            // 
            this.groupBoxCA.Controls.Add(this.dataCA);
            this.groupBoxCA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCA.Location = new System.Drawing.Point(444, 343);
            this.groupBoxCA.Name = "groupBoxCA";
            this.groupBoxCA.Size = new System.Drawing.Size(424, 289);
            this.groupBoxCA.TabIndex = 4;
            this.groupBoxCA.TabStop = false;
            this.groupBoxCA.Text = "Clustered Affinity Matrix :";
            // 
            // dataCA
            // 
            this.dataCA.AllowUserToAddRows = false;
            this.dataCA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataCA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCA.Location = new System.Drawing.Point(11, 15);
            this.dataCA.Name = "dataCA";
            this.dataCA.Size = new System.Drawing.Size(402, 268);
            this.dataCA.TabIndex = 2;
            // 
            // groupBoxAA
            // 
            this.groupBoxAA.Controls.Add(this.dataAA);
            this.groupBoxAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAA.Location = new System.Drawing.Point(444, 48);
            this.groupBoxAA.Name = "groupBoxAA";
            this.groupBoxAA.Size = new System.Drawing.Size(424, 289);
            this.groupBoxAA.TabIndex = 3;
            this.groupBoxAA.TabStop = false;
            this.groupBoxAA.Text = "Attribute Affinity Matrix :";
            // 
            // dataAA
            // 
            this.dataAA.AllowUserToAddRows = false;
            this.dataAA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataAA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAA.Location = new System.Drawing.Point(11, 16);
            this.dataAA.Name = "dataAA";
            this.dataAA.Size = new System.Drawing.Size(402, 267);
            this.dataAA.TabIndex = 1;
            // 
            // groupBoxVF
            // 
            this.groupBoxVF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVF.Location = new System.Drawing.Point(874, 48);
            this.groupBoxVF.Name = "groupBoxVF";
            this.groupBoxVF.Size = new System.Drawing.Size(424, 161);
            this.groupBoxVF.TabIndex = 5;
            this.groupBoxVF.TabStop = false;
            this.groupBoxVF.Text = "Vertical Fragmentation :";
            // 
            // btnClear
            // 
            this.btnClear.ActiveBorderThickness = 1;
            this.btnClear.ActiveCornerRadius = 20;
            this.btnClear.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnClear.ActiveForecolor = System.Drawing.Color.White;
            this.btnClear.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.ButtonText = "Clear";
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnClear.IdleBorderThickness = 1;
            this.btnClear.IdleCornerRadius = 20;
            this.btnClear.IdleFillColor = System.Drawing.Color.White;
            this.btnClear.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnClear.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnClear.Location = new System.Drawing.Point(205, 640);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(181, 41);
            this.btnClear.TabIndex = 6;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.ActiveBorderThickness = 1;
            this.btnCalculate.ActiveCornerRadius = 20;
            this.btnCalculate.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnCalculate.ActiveForecolor = System.Drawing.Color.White;
            this.btnCalculate.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnCalculate.BackColor = System.Drawing.SystemColors.Control;
            this.btnCalculate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalculate.BackgroundImage")));
            this.btnCalculate.ButtonText = "Calculate";
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnCalculate.IdleBorderThickness = 1;
            this.btnCalculate.IdleCornerRadius = 20;
            this.btnCalculate.IdleFillColor = System.Drawing.Color.White;
            this.btnCalculate.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnCalculate.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnCalculate.Location = new System.Drawing.Point(14, 640);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(5);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(181, 41);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // groupBoxLogs
            // 
            this.groupBoxLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLogs.Location = new System.Drawing.Point(874, 215);
            this.groupBoxLogs.Name = "groupBoxLogs";
            this.groupBoxLogs.Size = new System.Drawing.Size(424, 417);
            this.groupBoxLogs.TabIndex = 8;
            this.groupBoxLogs.TabStop = false;
            this.groupBoxLogs.Text = "Logs :";
            // 
            // mainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 691);
            this.Controls.Add(this.groupBoxLogs);
            this.Controls.Add(this.groupBoxVF);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.groupBoxCA);
            this.Controls.Add(this.groupBoxAA);
            this.Controls.Add(this.groupBoxAFM);
            this.Controls.Add(this.groupBoxUM);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.groupBoxUM.ResumeLayout(false);
            this.groupBoxUM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataUM)).EndInit();
            this.groupBoxAFM.ResumeLayout(false);
            this.groupBoxAFM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAFM)).EndInit();
            this.groupBoxCA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataCA)).EndInit();
            this.groupBoxAA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataAA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ns1.BunifuElipse bunifuElipse;
        private ns1.BunifuImageButton btnClose;
        private System.Windows.Forms.Panel panelHeader;
        private ns1.BunifuDragControl dragCtrHeader;
        private System.Windows.Forms.GroupBox groupBoxAFM;
        private System.Windows.Forms.GroupBox groupBoxUM;
        private System.Windows.Forms.GroupBox groupBoxCA;
        private System.Windows.Forms.GroupBox groupBoxAA;
        private ns1.BunifuThinButton2 btnClear;
        private ns1.BunifuThinButton2 btnCalculate;
        private System.Windows.Forms.GroupBox groupBoxVF;
        private System.Windows.Forms.DataGridView dataUM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textColUM;
        private System.Windows.Forms.TextBox textRowUM;
        private System.Windows.Forms.DataGridView dataCA;
        private System.Windows.Forms.DataGridView dataAA;
        private System.Windows.Forms.DataGridView dataAFM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRowAFM;
        private System.Windows.Forms.TextBox textColAFM;
        private ns1.BunifuFlatButton btnCreateAFM;
        private ns1.BunifuFlatButton btnCreateUM;
        private System.Windows.Forms.GroupBox groupBoxLogs;
    }
}

