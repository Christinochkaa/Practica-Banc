
namespace Bank
{
    partial class Menu
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
            this.btnSio = new System.Windows.Forms.Button();
            this.btnSert = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnDo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSio
            // 
            this.btnSio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSio.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSio.Location = new System.Drawing.Point(12, 12);
            this.btnSio.Name = "btnSio";
            this.btnSio.Size = new System.Drawing.Size(410, 45);
            this.btnSio.TabIndex = 0;
            this.btnSio.Text = "Субъекты Информационного Обмена";
            this.btnSio.UseVisualStyleBackColor = true;
            this.btnSio.Click += new System.EventHandler(this.btnSio_Click);
            // 
            // btnSert
            // 
            this.btnSert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSert.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSert.Location = new System.Drawing.Point(12, 63);
            this.btnSert.Name = "btnSert";
            this.btnSert.Size = new System.Drawing.Size(410, 45);
            this.btnSert.TabIndex = 1;
            this.btnSert.Text = "Сертификаты";
            this.btnSert.UseVisualStyleBackColor = true;
            this.btnSert.Click += new System.EventHandler(this.btnSert_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUsers.Location = new System.Drawing.Point(12, 114);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(410, 44);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Пользователи";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnDo
            // 
            this.btnDo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDo.Location = new System.Drawing.Point(12, 164);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(410, 44);
            this.btnDo.TabIndex = 3;
            this.btnDo.Text = "Дополнительные Офисы";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 223);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnSert);
            this.Controls.Add(this.btnSio);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSio;
        private System.Windows.Forms.Button btnSert;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnDo;
    }
}