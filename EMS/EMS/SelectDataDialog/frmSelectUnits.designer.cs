﻿namespace EMS.SelectDataDialog
{
    partial class frmSelectUnits
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectUnits));
            this.dgvSelectUnitsList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectUnitsList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSelectUnitsList
            // 
            this.dgvSelectUnitsList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSelectUnitsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectUnitsList.Location = new System.Drawing.Point(0, 0);
            this.dgvSelectUnitsList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSelectUnitsList.Name = "dgvSelectUnitsList";
            this.dgvSelectUnitsList.RowTemplate.Height = 23;
            this.dgvSelectUnitsList.Size = new System.Drawing.Size(696, 249);
            this.dgvSelectUnitsList.TabIndex = 1;
            this.dgvSelectUnitsList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectUnitsList_CellDoubleClick);
            // 
            // frmSelectUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 249);
            this.Controls.Add(this.dgvSelectUnitsList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectUnits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择－－往来单位－－";
            this.Load += new System.EventHandler(this.SelectUnits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectUnitsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelectUnitsList;
    }
}