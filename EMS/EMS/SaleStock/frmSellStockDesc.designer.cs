﻿namespace EMS.SaleStock
{
    partial class frmSellStockDesc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSellStockDesc));
            this.dgvStockList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStockList
            // 
            this.dgvStockList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockList.Location = new System.Drawing.Point(-3, 0);
            this.dgvStockList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvStockList.Name = "dgvStockList";
            this.dgvStockList.RowTemplate.Height = 23;
            this.dgvStockList.Size = new System.Drawing.Size(615, 641);
            this.dgvStockList.TabIndex = 0;
            // 
            // frmSellStockDesc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 639);
            this.Controls.Add(this.dgvStockList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSellStockDesc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品销售排行榜－－销售管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvStockList;

    }
}