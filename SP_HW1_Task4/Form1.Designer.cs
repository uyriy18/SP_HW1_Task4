
namespace SP_HW1_Task4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.trvProcesses = new System.Windows.Forms.TreeView();
            this.lblCounts = new System.Windows.Forms.Label();
            this.load_btn = new System.Windows.Forms.Button();
            this.Info_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trvProcesses
            // 
            this.trvProcesses.Dock = System.Windows.Forms.DockStyle.Top;
            this.trvProcesses.Location = new System.Drawing.Point(0, 0);
            this.trvProcesses.Name = "trvProcesses";
            this.trvProcesses.Size = new System.Drawing.Size(451, 392);
            this.trvProcesses.TabIndex = 0;
            this.trvProcesses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvProcesses_AfterSelect_1);
            // 
            // lblCounts
            // 
            this.lblCounts.AutoSize = true;
            this.lblCounts.Location = new System.Drawing.Point(123, 403);
            this.lblCounts.Name = "lblCounts";
            this.lblCounts.Size = new System.Drawing.Size(0, 13);
            this.lblCounts.TabIndex = 1;
            // 
            // load_btn
            // 
            this.load_btn.Location = new System.Drawing.Point(12, 398);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(75, 23);
            this.load_btn.TabIndex = 2;
            this.load_btn.Text = "Load";
            this.load_btn.UseVisualStyleBackColor = true;
            this.load_btn.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Info_lbl
            // 
            this.Info_lbl.AutoSize = true;
            this.Info_lbl.Location = new System.Drawing.Point(117, 428);
            this.Info_lbl.Name = "Info_lbl";
            this.Info_lbl.Size = new System.Drawing.Size(0, 13);
            this.Info_lbl.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selected Node :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Info_lbl);
            this.Controls.Add(this.load_btn);
            this.Controls.Add(this.lblCounts);
            this.Controls.Add(this.trvProcesses);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvProcesses;
        private System.Windows.Forms.Label lblCounts;
        private System.Windows.Forms.Button load_btn;
        private System.Windows.Forms.Label Info_lbl;
        private System.Windows.Forms.Label label1;
    }
}

