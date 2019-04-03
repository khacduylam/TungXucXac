namespace client
{
    partial class frm_Board
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
            this.lbl_Money = new System.Windows.Forms.Label();
            this.lbl_EnemyPoint = new System.Windows.Forms.Label();
            this.lbl_PlayerPoint = new System.Windows.Forms.Label();
            this.txt_Money = new System.Windows.Forms.TextBox();
            this.txt_EnemyPoint = new System.Windows.Forms.TextBox();
            this.txt_PlayerPoint = new System.Windows.Forms.TextBox();
            this.btn_Continue = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Money
            // 
            this.lbl_Money.AutoSize = true;
            this.lbl_Money.Location = new System.Drawing.Point(57, 29);
            this.lbl_Money.Name = "lbl_Money";
            this.lbl_Money.Size = new System.Drawing.Size(74, 13);
            this.lbl_Money.TabIndex = 0;
            this.lbl_Money.Text = "Số tiền còn lại";
            // 
            // lbl_EnemyPoint
            // 
            this.lbl_EnemyPoint.AutoSize = true;
            this.lbl_EnemyPoint.Location = new System.Drawing.Point(57, 117);
            this.lbl_EnemyPoint.Name = "lbl_EnemyPoint";
            this.lbl_EnemyPoint.Size = new System.Drawing.Size(82, 13);
            this.lbl_EnemyPoint.TabIndex = 1;
            this.lbl_EnemyPoint.Text = "Số điểm đối thủ";
            // 
            // lbl_PlayerPoint
            // 
            this.lbl_PlayerPoint.AutoSize = true;
            this.lbl_PlayerPoint.Location = new System.Drawing.Point(57, 197);
            this.lbl_PlayerPoint.Name = "lbl_PlayerPoint";
            this.lbl_PlayerPoint.Size = new System.Drawing.Size(98, 13);
            this.lbl_PlayerPoint.TabIndex = 2;
            this.lbl_PlayerPoint.Text = "Số điểm người chơi";
            // 
            // txt_Money
            // 
            this.txt_Money.Location = new System.Drawing.Point(201, 29);
            this.txt_Money.Name = "txt_Money";
            this.txt_Money.Size = new System.Drawing.Size(100, 20);
            this.txt_Money.TabIndex = 3;
            // 
            // txt_EnemyPoint
            // 
            this.txt_EnemyPoint.Location = new System.Drawing.Point(201, 114);
            this.txt_EnemyPoint.Name = "txt_EnemyPoint";
            this.txt_EnemyPoint.Size = new System.Drawing.Size(100, 20);
            this.txt_EnemyPoint.TabIndex = 4;
            // 
            // txt_PlayerPoint
            // 
            this.txt_PlayerPoint.Location = new System.Drawing.Point(201, 194);
            this.txt_PlayerPoint.Name = "txt_PlayerPoint";
            this.txt_PlayerPoint.Size = new System.Drawing.Size(100, 20);
            this.txt_PlayerPoint.TabIndex = 5;
            // 
            // btn_Continue
            // 
            this.btn_Continue.Location = new System.Drawing.Point(99, 284);
            this.btn_Continue.Name = "btn_Continue";
            this.btn_Continue.Size = new System.Drawing.Size(104, 23);
            this.btn_Continue.TabIndex = 6;
            this.btn_Continue.Text = "Chơi tiếp";
            this.btn_Continue.UseVisualStyleBackColor = true;
            this.btn_Continue.Click += new System.EventHandler(this.btn_Continue_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(235, 284);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(104, 23);
            this.btn_Play.TabIndex = 7;
            this.btn_Play.Text = "Tung Xí Ngầu";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // frm_Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 450);
            this.Controls.Add(this.btn_Play);
            this.Controls.Add(this.btn_Continue);
            this.Controls.Add(this.txt_PlayerPoint);
            this.Controls.Add(this.txt_EnemyPoint);
            this.Controls.Add(this.txt_Money);
            this.Controls.Add(this.lbl_PlayerPoint);
            this.Controls.Add(this.lbl_EnemyPoint);
            this.Controls.Add(this.lbl_Money);
            this.Name = "frm_Board";
            this.Text = "frm_Board";
            this.Load += new System.EventHandler(this.frm_Board_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Money;
        private System.Windows.Forms.Label lbl_EnemyPoint;
        private System.Windows.Forms.Label lbl_PlayerPoint;
        private System.Windows.Forms.TextBox txt_Money;
        private System.Windows.Forms.TextBox txt_EnemyPoint;
        private System.Windows.Forms.TextBox txt_PlayerPoint;
        private System.Windows.Forms.Button btn_Continue;
        private System.Windows.Forms.Button btn_Play;
    }
}