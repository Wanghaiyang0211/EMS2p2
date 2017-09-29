namespace EMS.SelectDataDialog
{
    partial class frmSelectHandle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectHandle));
            this.dgvSelectHandleList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectHandleList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSelectHandleList
            // 
            this.dgvSelectHandleList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSelectHandleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectHandleList.Location = new System.Drawing.Point(-1, 0);
            this.dgvSelectHandleList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSelectHandleList.Name = "dgvSelectHandleList";
            this.dgvSelectHandleList.RowTemplate.Height = 23;
            this.dgvSelectHandleList.Size = new System.Drawing.Size(696, 249);
            this.dgvSelectHandleList.TabIndex = 0;
            this.dgvSelectHandleList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectHandleList_CellDoubleClick);
            // 
            // frmSelectHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 246);
            this.Controls.Add(this.dgvSelectHandleList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectHandle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择--经手人--";
            this.Load += new System.EventHandler(this.selectHandle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectHandleList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelectHandleList;
    }
}