namespace SistemaHotel.Reservas
{
    partial class FrmConsultarReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarReservas));
            this.grid = new System.Windows.Forms.DataGridView();
            this.dtBuscarInicioReserva = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.txtBuscarNome = new System.Windows.Forms.TextBox();
            this.dtBuscarReserva = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPago = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.GridColor = System.Drawing.SystemColors.Control;
            this.grid.Location = new System.Drawing.Point(12, 63);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1217, 345);
            this.grid.TabIndex = 123;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            // 
            // dtBuscarInicioReserva
            // 
            this.dtBuscarInicioReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBuscarInicioReserva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscarInicioReserva.Location = new System.Drawing.Point(745, 31);
            this.dtBuscarInicioReserva.Name = "dtBuscarInicioReserva";
            this.dtBuscarInicioReserva.Size = new System.Drawing.Size(126, 26);
            this.dtBuscarInicioReserva.TabIndex = 122;
            this.dtBuscarInicioReserva.Value = new System.DateTime(2019, 5, 5, 13, 44, 0, 0);
            this.dtBuscarInicioReserva.ValueChanged += new System.EventHandler(this.DtBuscarInicioReserva_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(742, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 121;
            this.label3.Text = "Data Inicio Reserva:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 126;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 127;
            this.label2.Text = "Status:";
            // 
            // cbStatus
            // 
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Confirmada",
            "Cancelada"});
            this.cbStatus.Location = new System.Drawing.Point(83, 29);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(152, 28);
            this.cbStatus.TabIndex = 128;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.CbStatus_SelectedIndexChanged);
            // 
            // txtBuscarNome
            // 
            this.txtBuscarNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNome.Location = new System.Drawing.Point(302, 31);
            this.txtBuscarNome.Name = "txtBuscarNome";
            this.txtBuscarNome.Size = new System.Drawing.Size(379, 26);
            this.txtBuscarNome.TabIndex = 129;
            this.txtBuscarNome.TextChanged += new System.EventHandler(this.TxtBuscarNome_TextChanged);
            // 
            // dtBuscarReserva
            // 
            this.dtBuscarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBuscarReserva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscarReserva.Location = new System.Drawing.Point(919, 31);
            this.dtBuscarReserva.Name = "dtBuscarReserva";
            this.dtBuscarReserva.Size = new System.Drawing.Size(135, 26);
            this.dtBuscarReserva.TabIndex = 131;
            this.dtBuscarReserva.Value = new System.DateTime(2019, 5, 5, 13, 44, 0, 0);
            this.dtBuscarReserva.ValueChanged += new System.EventHandler(this.DtBuscarReserva_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(916, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 130;
            this.label4.Text = "Data Reserva:";
            // 
            // btnPago
            // 
            this.btnPago.BackColor = System.Drawing.Color.Transparent;
            this.btnPago.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPago.BackgroundImage")));
            this.btnPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPago.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnPago.FlatAppearance.BorderSize = 0;
            this.btnPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPago.Location = new System.Drawing.Point(1134, 31);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(25, 25);
            this.btnPago.TabIndex = 124;
            this.btnPago.UseVisualStyleBackColor = false;
            this.btnPago.Click += new System.EventHandler(this.BtnPago_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemove.BackgroundImage")));
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(1163, 31);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(25, 25);
            this.btnRemove.TabIndex = 125;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnRel
            // 
            this.btnRel.BackColor = System.Drawing.Color.Transparent;
            this.btnRel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRel.BackgroundImage")));
            this.btnRel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRel.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRel.FlatAppearance.BorderSize = 0;
            this.btnRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRel.Location = new System.Drawing.Point(1192, 31);
            this.btnRel.Name = "btnRel";
            this.btnRel.Size = new System.Drawing.Size(25, 25);
            this.btnRel.TabIndex = 132;
            this.btnRel.UseVisualStyleBackColor = false;
            this.btnRel.Click += new System.EventHandler(this.BtnRel_Click);
            // 
            // FrmConsultarReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(186)))), ((int)(((byte)(191)))));
            this.ClientSize = new System.Drawing.Size(1241, 420);
            this.Controls.Add(this.btnRel);
            this.Controls.Add(this.dtBuscarReserva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBuscarNome);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnPago);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.dtBuscarInicioReserva);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmConsultarReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Reservas";
            this.Load += new System.EventHandler(this.FrmConsultarReservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DateTimePicker dtBuscarInicioReserva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox txtBuscarNome;
        private System.Windows.Forms.DateTimePicker dtBuscarReserva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRel;
    }
}