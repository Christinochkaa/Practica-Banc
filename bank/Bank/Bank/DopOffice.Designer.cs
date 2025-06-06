namespace Bank
{
    partial class DopOffice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DopOffice));
            this.button1obnov = new System.Windows.Forms.Button();
            this.textBox1poisk = new System.Windows.Forms.TextBox();
            this.label2poisk = new System.Windows.Forms.Label();
            this.label1nazv = new System.Windows.Forms.Label();
            this.label1nomdo = new System.Windows.Forms.Label();
            this.label2imado = new System.Windows.Forms.Label();
            this.textBox2nomdo = new System.Windows.Forms.TextBox();
            this.textBox3imado = new System.Windows.Forms.TextBox();
            this.button1dobav = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1izmen = new System.Windows.Forms.Button();
            this.button2delet = new System.Windows.Forms.Button();
            this.button3soxr = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlsUserStatus = new System.Windows.Forms.ToolStripTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1obnov
            // 
            this.button1obnov.BackColor = System.Drawing.Color.White;
            this.button1obnov.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1obnov.BackgroundImage")));
            this.button1obnov.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1obnov.Location = new System.Drawing.Point(535, 6);
            this.button1obnov.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1obnov.Name = "button1obnov";
            this.button1obnov.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1obnov.Size = new System.Drawing.Size(45, 25);
            this.button1obnov.TabIndex = 3;
            this.button1obnov.UseVisualStyleBackColor = false;
            this.button1obnov.Click += new System.EventHandler(this.button1obnov_Click);
            // 
            // textBox1poisk
            // 
            this.textBox1poisk.Location = new System.Drawing.Point(653, 6);
            this.textBox1poisk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1poisk.Name = "textBox1poisk";
            this.textBox1poisk.Size = new System.Drawing.Size(135, 22);
            this.textBox1poisk.TabIndex = 2;
            this.textBox1poisk.TextChanged += new System.EventHandler(this.textBox1poisk_TextChanged);
            // 
            // label2poisk
            // 
            this.label2poisk.AutoSize = true;
            this.label2poisk.BackColor = System.Drawing.Color.White;
            this.label2poisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2poisk.ForeColor = System.Drawing.Color.Black;
            this.label2poisk.Location = new System.Drawing.Point(587, 7);
            this.label2poisk.Name = "label2poisk";
            this.label2poisk.Size = new System.Drawing.Size(60, 20);
            this.label2poisk.TabIndex = 1;
            this.label2poisk.Text = "Поиск";
            this.label2poisk.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1nazv
            // 
            this.label1nazv.AutoSize = true;
            this.label1nazv.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1nazv.ForeColor = System.Drawing.Color.Black;
            this.label1nazv.Location = new System.Drawing.Point(11, 5);
            this.label1nazv.Name = "label1nazv";
            this.label1nazv.Size = new System.Drawing.Size(276, 21);
            this.label1nazv.TabIndex = 0;
            this.label1nazv.Text = "Дополнительные офисы (ДО)";
            // 
            // label1nomdo
            // 
            this.label1nomdo.AutoSize = true;
            this.label1nomdo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1nomdo.ForeColor = System.Drawing.Color.Black;
            this.label1nomdo.Location = new System.Drawing.Point(67, 377);
            this.label1nomdo.Name = "label1nomdo";
            this.label1nomdo.Size = new System.Drawing.Size(83, 18);
            this.label1nomdo.TabIndex = 3;
            this.label1nomdo.Text = "Номер ДО:";
            // 
            // label2imado
            // 
            this.label2imado.AutoSize = true;
            this.label2imado.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2imado.ForeColor = System.Drawing.Color.Black;
            this.label2imado.Location = new System.Drawing.Point(3, 415);
            this.label2imado.Name = "label2imado";
            this.label2imado.Size = new System.Drawing.Size(147, 18);
            this.label2imado.TabIndex = 4;
            this.label2imado.Text = "Наимаенование ДО:";
            // 
            // textBox2nomdo
            // 
            this.textBox2nomdo.Location = new System.Drawing.Point(160, 372);
            this.textBox2nomdo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2nomdo.Name = "textBox2nomdo";
            this.textBox2nomdo.Size = new System.Drawing.Size(177, 22);
            this.textBox2nomdo.TabIndex = 5;
            // 
            // textBox3imado
            // 
            this.textBox3imado.Location = new System.Drawing.Point(160, 411);
            this.textBox3imado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3imado.Name = "textBox3imado";
            this.textBox3imado.Size = new System.Drawing.Size(177, 22);
            this.textBox3imado.TabIndex = 6;
            // 
            // button1dobav
            // 
            this.button1dobav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(215)))), ((int)(((byte)(77)))));
            this.button1dobav.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1dobav.ForeColor = System.Drawing.Color.Black;
            this.button1dobav.Location = new System.Drawing.Point(353, 127);
            this.button1dobav.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1dobav.Name = "button1dobav";
            this.button1dobav.Size = new System.Drawing.Size(124, 31);
            this.button1dobav.TabIndex = 9;
            this.button1dobav.Text = "Добавить";
            this.button1dobav.UseVisualStyleBackColor = false;
            this.button1dobav.Click += new System.EventHandler(this.button1dobav_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(491, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Управление";
            // 
            // button1izmen
            // 
            this.button1izmen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(215)))), ((int)(((byte)(77)))));
            this.button1izmen.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1izmen.ForeColor = System.Drawing.Color.Black;
            this.button1izmen.Location = new System.Drawing.Point(616, 318);
            this.button1izmen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1izmen.Name = "button1izmen";
            this.button1izmen.Size = new System.Drawing.Size(116, 34);
            this.button1izmen.TabIndex = 11;
            this.button1izmen.Text = "Изменить";
            this.button1izmen.UseVisualStyleBackColor = false;
            this.button1izmen.Click += new System.EventHandler(this.button1izmen_Click);
            // 
            // button2delet
            // 
            this.button2delet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(215)))), ((int)(((byte)(77)))));
            this.button2delet.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2delet.ForeColor = System.Drawing.Color.Black;
            this.button2delet.Location = new System.Drawing.Point(616, 358);
            this.button2delet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2delet.Name = "button2delet";
            this.button2delet.Size = new System.Drawing.Size(116, 37);
            this.button2delet.TabIndex = 12;
            this.button2delet.Text = "Удалить";
            this.button2delet.UseVisualStyleBackColor = false;
            this.button2delet.Click += new System.EventHandler(this.button2delet_Click);
            // 
            // button3soxr
            // 
            this.button3soxr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(215)))), ((int)(((byte)(77)))));
            this.button3soxr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3soxr.ForeColor = System.Drawing.Color.Black;
            this.button3soxr.Location = new System.Drawing.Point(616, 401);
            this.button3soxr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3soxr.Name = "button3soxr";
            this.button3soxr.Size = new System.Drawing.Size(116, 36);
            this.button3soxr.TabIndex = 13;
            this.button3soxr.Text = "Сохранить";
            this.button3soxr.UseVisualStyleBackColor = false;
            this.button3soxr.Click += new System.EventHandler(this.button3soxr_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(121, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID:";
            // 
            // textBox1id
            // 
            this.textBox1id.Location = new System.Drawing.Point(160, 334);
            this.textBox1id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1id.Name = "textBox1id";
            this.textBox1id.Size = new System.Drawing.Size(177, 22);
            this.textBox1id.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Новый ДО";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(165)))), ((int)(((byte)(73)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsUserStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 32);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlsUserStatus
            // 
            this.tlsUserStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tlsUserStatus.BackColor = System.Drawing.Color.White;
            this.tlsUserStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tlsUserStatus.Name = "tlsUserStatus";
            this.tlsUserStatus.ReadOnly = true;
            this.tlsUserStatus.Size = new System.Drawing.Size(265, 32);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(165)))), ((int)(((byte)(73)))));
            this.panel1.Controls.Add(this.label1nazv);
            this.panel1.Controls.Add(this.textBox1poisk);
            this.panel1.Controls.Add(this.button1obnov);
            this.panel1.Controls.Add(this.label2poisk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 34);
            this.panel1.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 66);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 215);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button1dobav);
            this.panel2.Location = new System.Drawing.Point(0, 273);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 179);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(477, 273);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(321, 187);
            this.panel3.TabIndex = 21;
            // 
            // DopOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3soxr);
            this.Controls.Add(this.button2delet);
            this.Controls.Add(this.button1izmen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3imado);
            this.Controls.Add(this.textBox2nomdo);
            this.Controls.Add(this.label2imado);
            this.Controls.Add(this.label1nomdo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DopOffice";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1poisk;
        private System.Windows.Forms.Label label2poisk;
        private System.Windows.Forms.Label label1nazv;
        private System.Windows.Forms.Label label1nomdo;
        private System.Windows.Forms.Label label2imado;
        private System.Windows.Forms.TextBox textBox2nomdo;
        private System.Windows.Forms.TextBox textBox3imado;
        private System.Windows.Forms.Button button1obnov;
        private System.Windows.Forms.Button button1dobav;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1izmen;
        private System.Windows.Forms.Button button2delet;
        private System.Windows.Forms.Button button3soxr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox tlsUserStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

