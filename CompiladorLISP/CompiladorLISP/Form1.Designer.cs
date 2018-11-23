namespace CompiladorLISP
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.lblCS = new System.Windows.Forms.Label();
            this.lblLISP = new System.Windows.Forms.Label();
            this.btnConvertir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.rtxtLISP = new System.Windows.Forms.RichTextBox();
            this.rtxtCS = new System.Windows.Forms.RichTextBox();
            this.btnToCBLISP = new System.Windows.Forms.Button();
            this.btnToCBCS = new System.Windows.Forms.Button();
            this.btnGuardarCS = new System.Windows.Forms.Button();
            this.btnGuardarTodo = new System.Windows.Forms.Button();
            this.btnGuardarLISP = new System.Windows.Forms.Button();
            this.lblAsistente = new System.Windows.Forms.Label();
            this.btnLeer = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnEscribir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCS
            // 
            this.lblCS.AutoSize = true;
            this.lblCS.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCS.Location = new System.Drawing.Point(421, 9);
            this.lblCS.Name = "lblCS";
            this.lblCS.Size = new System.Drawing.Size(24, 13);
            this.lblCS.TabIndex = 0;
            this.lblCS.Text = "C#:";
            // 
            // lblLISP
            // 
            this.lblLISP.AutoSize = true;
            this.lblLISP.Location = new System.Drawing.Point(90, 9);
            this.lblLISP.Name = "lblLISP";
            this.lblLISP.Size = new System.Drawing.Size(33, 13);
            this.lblLISP.TabIndex = 1;
            this.lblLISP.Text = "LISP:";
            // 
            // btnConvertir
            // 
            this.btnConvertir.Image = ((System.Drawing.Image)(resources.GetObject("btnConvertir.Image")));
            this.btnConvertir.Location = new System.Drawing.Point(343, 35);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(75, 68);
            this.btnConvertir.TabIndex = 4;
            this.btnConvertir.Text = "Convertir";
            this.btnConvertir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConvertir.UseVisualStyleBackColor = true;
            this.btnConvertir.Click += new System.EventHandler(this.btnConvertir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(343, 212);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 68);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(343, 297);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 67);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // rtxtLISP
            // 
            this.rtxtLISP.Location = new System.Drawing.Point(93, 35);
            this.rtxtLISP.Name = "rtxtLISP";
            this.rtxtLISP.Size = new System.Drawing.Size(244, 329);
            this.rtxtLISP.TabIndex = 9;
            this.rtxtLISP.Text = "";
            this.rtxtLISP.TextChanged += new System.EventHandler(this.rtxtLISP_TextChanged);
            this.rtxtLISP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtLISP_KeyPress);
            // 
            // rtxtCS
            // 
            this.rtxtCS.Location = new System.Drawing.Point(424, 35);
            this.rtxtCS.Name = "rtxtCS";
            this.rtxtCS.ReadOnly = true;
            this.rtxtCS.Size = new System.Drawing.Size(243, 329);
            this.rtxtCS.TabIndex = 10;
            this.rtxtCS.Text = "";
            // 
            // btnToCBLISP
            // 
            this.btnToCBLISP.Image = ((System.Drawing.Image)(resources.GetObject("btnToCBLISP.Image")));
            this.btnToCBLISP.Location = new System.Drawing.Point(259, 370);
            this.btnToCBLISP.Name = "btnToCBLISP";
            this.btnToCBLISP.Size = new System.Drawing.Size(78, 68);
            this.btnToCBLISP.TabIndex = 11;
            this.btnToCBLISP.Text = "Copiar LISP";
            this.btnToCBLISP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnToCBLISP.UseVisualStyleBackColor = true;
            this.btnToCBLISP.Click += new System.EventHandler(this.btnToCBLISP_Click);
            // 
            // btnToCBCS
            // 
            this.btnToCBCS.Image = ((System.Drawing.Image)(resources.GetObject("btnToCBCS.Image")));
            this.btnToCBCS.Location = new System.Drawing.Point(589, 369);
            this.btnToCBCS.Name = "btnToCBCS";
            this.btnToCBCS.Size = new System.Drawing.Size(78, 68);
            this.btnToCBCS.TabIndex = 12;
            this.btnToCBCS.Text = "Copiar C#";
            this.btnToCBCS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnToCBCS.UseVisualStyleBackColor = true;
            this.btnToCBCS.Click += new System.EventHandler(this.btnToCBCS_Click);
            // 
            // btnGuardarCS
            // 
            this.btnGuardarCS.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarCS.Image")));
            this.btnGuardarCS.Location = new System.Drawing.Point(424, 371);
            this.btnGuardarCS.Name = "btnGuardarCS";
            this.btnGuardarCS.Size = new System.Drawing.Size(75, 67);
            this.btnGuardarCS.TabIndex = 13;
            this.btnGuardarCS.Text = "Guardar C#";
            this.btnGuardarCS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarCS.UseVisualStyleBackColor = true;
            this.btnGuardarCS.Click += new System.EventHandler(this.btnGuardarCS_Click);
            // 
            // btnGuardarTodo
            // 
            this.btnGuardarTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarTodo.Image")));
            this.btnGuardarTodo.Location = new System.Drawing.Point(343, 122);
            this.btnGuardarTodo.Name = "btnGuardarTodo";
            this.btnGuardarTodo.Size = new System.Drawing.Size(75, 68);
            this.btnGuardarTodo.TabIndex = 14;
            this.btnGuardarTodo.Text = "Guardar Todo";
            this.btnGuardarTodo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarTodo.UseVisualStyleBackColor = true;
            this.btnGuardarTodo.Click += new System.EventHandler(this.btnGuardarTodo_Click);
            // 
            // btnGuardarLISP
            // 
            this.btnGuardarLISP.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarLISP.Image")));
            this.btnGuardarLISP.Location = new System.Drawing.Point(93, 369);
            this.btnGuardarLISP.Name = "btnGuardarLISP";
            this.btnGuardarLISP.Size = new System.Drawing.Size(75, 67);
            this.btnGuardarLISP.TabIndex = 15;
            this.btnGuardarLISP.Text = "Guardar LISP";
            this.btnGuardarLISP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarLISP.UseVisualStyleBackColor = true;
            this.btnGuardarLISP.Click += new System.EventHandler(this.btnGuardarLISP_Click);
            // 
            // lblAsistente
            // 
            this.lblAsistente.AutoSize = true;
            this.lblAsistente.Location = new System.Drawing.Point(13, 35);
            this.lblAsistente.Name = "lblAsistente";
            this.lblAsistente.Size = new System.Drawing.Size(53, 13);
            this.lblAsistente.TabIndex = 16;
            this.lblAsistente.Text = "Asistente:";
            // 
            // btnLeer
            // 
            this.btnLeer.Image = ((System.Drawing.Image)(resources.GetObject("btnLeer.Image")));
            this.btnLeer.Location = new System.Drawing.Point(12, 51);
            this.btnLeer.Name = "btnLeer";
            this.btnLeer.Size = new System.Drawing.Size(75, 52);
            this.btnLeer.TabIndex = 17;
            this.btnLeer.Text = "Leer";
            this.btnLeer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLeer.UseVisualStyleBackColor = true;
            this.btnLeer.Click += new System.EventHandler(this.btnLeer_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Image = ((System.Drawing.Image)(resources.GetObject("btnAsignar.Image")));
            this.btnAsignar.Location = new System.Drawing.Point(12, 122);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(75, 50);
            this.btnAsignar.TabIndex = 18;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnEscribir
            // 
            this.btnEscribir.Image = ((System.Drawing.Image)(resources.GetObject("btnEscribir.Image")));
            this.btnEscribir.Location = new System.Drawing.Point(12, 196);
            this.btnEscribir.Name = "btnEscribir";
            this.btnEscribir.Size = new System.Drawing.Size(75, 53);
            this.btnEscribir.TabIndex = 19;
            this.btnEscribir.Text = "Escribir";
            this.btnEscribir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEscribir.UseVisualStyleBackColor = true;
            this.btnEscribir.Click += new System.EventHandler(this.btnEscribir_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(690, 443);
            this.Controls.Add(this.btnEscribir);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnLeer);
            this.Controls.Add(this.lblAsistente);
            this.Controls.Add(this.btnGuardarLISP);
            this.Controls.Add(this.btnGuardarTodo);
            this.Controls.Add(this.btnGuardarCS);
            this.Controls.Add(this.btnToCBCS);
            this.Controls.Add(this.btnToCBLISP);
            this.Controls.Add(this.rtxtCS);
            this.Controls.Add(this.rtxtLISP);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnConvertir);
            this.Controls.Add(this.lblLISP);
            this.Controls.Add(this.lblCS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Text = "Compilador de pseudo LISP a C#";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCS;
        private System.Windows.Forms.Label lblLISP;
        private System.Windows.Forms.Button btnConvertir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.RichTextBox rtxtLISP;
        private System.Windows.Forms.RichTextBox rtxtCS;
        private System.Windows.Forms.Button btnToCBLISP;
        private System.Windows.Forms.Button btnToCBCS;
        private System.Windows.Forms.Button btnGuardarCS;
        private System.Windows.Forms.Button btnGuardarTodo;
        private System.Windows.Forms.Button btnGuardarLISP;
        private System.Windows.Forms.Label lblAsistente;
        private System.Windows.Forms.Button btnLeer;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnEscribir;
    }
}

