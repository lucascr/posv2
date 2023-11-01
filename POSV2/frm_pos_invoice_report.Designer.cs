namespace POSV2
{
    partial class frm_pos_invoice_report
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
            this.invoice_pos__r_dt1 = new System.Windows.Forms.DateTimePicker();
            this.invoice_pos__r_dt2 = new System.Windows.Forms.DateTimePicker();
            this.btn_invoice_ventas_general = new System.Windows.Forms.Button();
            this.invoice_wb1 = new System.Windows.Forms.WebBrowser();
            this.btn_print = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.invoice_pos__r_gastosycompras = new System.Windows.Forms.CheckBox();
            this.invoice_pos__r_moneda = new System.Windows.Forms.CheckBox();
            this.invoice_pos__r_td_nc = new System.Windows.Forms.CheckBox();
            this.invoice_pos__r_td_te = new System.Windows.Forms.CheckBox();
            this.btn_excel = new System.Windows.Forms.Button();
            this.invoice_pos__r_td_fe = new System.Windows.Forms.CheckBox();
            this.invoice_pos__r_medio_pago = new System.Windows.Forms.CheckBox();
            this.invoice_pos__r_condicion_venta = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_invoice_ventas_diario = new System.Windows.Forms.Button();
            this.btn_invoice_gastos_diario = new System.Windows.Forms.Button();
            this.btn_invoice_gastos_general = new System.Windows.Forms.Button();
            this.btn_invoice_ventas_clientes = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_invoice_gastos_proveedor = new System.Windows.Forms.Button();
            this.btn_invoice_gastos_x_impuesto = new System.Windows.Forms.Button();
            this.btn_invoice_gastos_proveedor_detalle = new System.Windows.Forms.Button();
            this.btn_invoice_ventas_clientes_detallado = new System.Windows.Forms.Button();
            this.chkAgrupado = new System.Windows.Forms.CheckBox();
            this.btn_reporte_inventario = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // invoice_pos__r_dt1
            // 
            this.invoice_pos__r_dt1.Location = new System.Drawing.Point(73, 32);
            this.invoice_pos__r_dt1.Name = "invoice_pos__r_dt1";
            this.invoice_pos__r_dt1.Size = new System.Drawing.Size(200, 20);
            this.invoice_pos__r_dt1.TabIndex = 0;
            // 
            // invoice_pos__r_dt2
            // 
            this.invoice_pos__r_dt2.Location = new System.Drawing.Point(339, 32);
            this.invoice_pos__r_dt2.Name = "invoice_pos__r_dt2";
            this.invoice_pos__r_dt2.Size = new System.Drawing.Size(200, 20);
            this.invoice_pos__r_dt2.TabIndex = 1;
            // 
            // btn_invoice_ventas_general
            // 
            this.btn_invoice_ventas_general.Location = new System.Drawing.Point(584, 18);
            this.btn_invoice_ventas_general.Name = "btn_invoice_ventas_general";
            this.btn_invoice_ventas_general.Size = new System.Drawing.Size(163, 21);
            this.btn_invoice_ventas_general.TabIndex = 70;
            this.btn_invoice_ventas_general.Text = "Reporte de Ventas General";
            this.btn_invoice_ventas_general.UseVisualStyleBackColor = true;
            this.btn_invoice_ventas_general.Click += new System.EventHandler(this.btn_invoice_ventas_Click);
            // 
            // invoice_wb1
            // 
            this.invoice_wb1.Location = new System.Drawing.Point(12, 185);
            this.invoice_wb1.MinimumSize = new System.Drawing.Size(20, 20);
            this.invoice_wb1.Name = "invoice_wb1";
            this.invoice_wb1.Size = new System.Drawing.Size(904, 386);
            this.invoice_wb1.TabIndex = 71;
            // 
            // btn_print
            // 
            this.btn_print.Enabled = false;
            this.btn_print.Location = new System.Drawing.Point(483, 109);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(77, 21);
            this.btn_print.TabIndex = 72;
            this.btn_print.Text = "Imprimir";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.invoice_pos__r_gastosycompras);
            this.groupBox1.Controls.Add(this.invoice_pos__r_moneda);
            this.groupBox1.Controls.Add(this.invoice_pos__r_td_nc);
            this.groupBox1.Controls.Add(this.invoice_pos__r_td_te);
            this.groupBox1.Controls.Add(this.btn_excel);
            this.groupBox1.Controls.Add(this.invoice_pos__r_td_fe);
            this.groupBox1.Controls.Add(this.invoice_pos__r_medio_pago);
            this.groupBox1.Controls.Add(this.invoice_pos__r_condicion_venta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.invoice_pos__r_dt1);
            this.groupBox1.Controls.Add(this.btn_print);
            this.groupBox1.Controls.Add(this.invoice_pos__r_dt2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 145);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // invoice_pos__r_gastosycompras
            // 
            this.invoice_pos__r_gastosycompras.AutoSize = true;
            this.invoice_pos__r_gastosycompras.Checked = true;
            this.invoice_pos__r_gastosycompras.CheckState = System.Windows.Forms.CheckState.Checked;
            this.invoice_pos__r_gastosycompras.Location = new System.Drawing.Point(301, 109);
            this.invoice_pos__r_gastosycompras.Name = "invoice_pos__r_gastosycompras";
            this.invoice_pos__r_gastosycompras.Size = new System.Drawing.Size(111, 17);
            this.invoice_pos__r_gastosycompras.TabIndex = 78;
            this.invoice_pos__r_gastosycompras.Text = "Gastos y Compras";
            this.invoice_pos__r_gastosycompras.UseVisualStyleBackColor = true;
            // 
            // invoice_pos__r_moneda
            // 
            this.invoice_pos__r_moneda.AutoSize = true;
            this.invoice_pos__r_moneda.Checked = true;
            this.invoice_pos__r_moneda.CheckState = System.Windows.Forms.CheckState.Checked;
            this.invoice_pos__r_moneda.Location = new System.Drawing.Point(30, 109);
            this.invoice_pos__r_moneda.Name = "invoice_pos__r_moneda";
            this.invoice_pos__r_moneda.Size = new System.Drawing.Size(65, 17);
            this.invoice_pos__r_moneda.TabIndex = 77;
            this.invoice_pos__r_moneda.Text = "Moneda";
            this.invoice_pos__r_moneda.UseVisualStyleBackColor = true;
            // 
            // invoice_pos__r_td_nc
            // 
            this.invoice_pos__r_td_nc.AutoSize = true;
            this.invoice_pos__r_td_nc.Checked = true;
            this.invoice_pos__r_td_nc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.invoice_pos__r_td_nc.Location = new System.Drawing.Point(301, 63);
            this.invoice_pos__r_td_nc.Name = "invoice_pos__r_td_nc";
            this.invoice_pos__r_td_nc.Size = new System.Drawing.Size(105, 17);
            this.invoice_pos__r_td_nc.TabIndex = 76;
            this.invoice_pos__r_td_nc.Text = "Notas de Crédito";
            this.invoice_pos__r_td_nc.UseVisualStyleBackColor = true;
            // 
            // invoice_pos__r_td_te
            // 
            this.invoice_pos__r_td_te.AutoSize = true;
            this.invoice_pos__r_td_te.Checked = true;
            this.invoice_pos__r_td_te.CheckState = System.Windows.Forms.CheckState.Checked;
            this.invoice_pos__r_td_te.Location = new System.Drawing.Point(167, 63);
            this.invoice_pos__r_td_te.Name = "invoice_pos__r_td_te";
            this.invoice_pos__r_td_te.Size = new System.Drawing.Size(118, 17);
            this.invoice_pos__r_td_te.TabIndex = 75;
            this.invoice_pos__r_td_te.Text = "Tiquete Electrónico";
            this.invoice_pos__r_td_te.UseVisualStyleBackColor = true;
            // 
            // btn_excel
            // 
            this.btn_excel.Enabled = false;
            this.btn_excel.Location = new System.Drawing.Point(483, 82);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(77, 21);
            this.btn_excel.TabIndex = 78;
            this.btn_excel.Text = "Excel";
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // invoice_pos__r_td_fe
            // 
            this.invoice_pos__r_td_fe.AutoSize = true;
            this.invoice_pos__r_td_fe.Checked = true;
            this.invoice_pos__r_td_fe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.invoice_pos__r_td_fe.Location = new System.Drawing.Point(167, 86);
            this.invoice_pos__r_td_fe.Name = "invoice_pos__r_td_fe";
            this.invoice_pos__r_td_fe.Size = new System.Drawing.Size(118, 17);
            this.invoice_pos__r_td_fe.TabIndex = 75;
            this.invoice_pos__r_td_fe.Text = "Factura Electrónica";
            this.invoice_pos__r_td_fe.UseVisualStyleBackColor = true;
            // 
            // invoice_pos__r_medio_pago
            // 
            this.invoice_pos__r_medio_pago.AutoSize = true;
            this.invoice_pos__r_medio_pago.Location = new System.Drawing.Point(30, 63);
            this.invoice_pos__r_medio_pago.Name = "invoice_pos__r_medio_pago";
            this.invoice_pos__r_medio_pago.Size = new System.Drawing.Size(98, 17);
            this.invoice_pos__r_medio_pago.TabIndex = 74;
            this.invoice_pos__r_medio_pago.Text = "Medio de Pago";
            this.invoice_pos__r_medio_pago.UseVisualStyleBackColor = true;
            // 
            // invoice_pos__r_condicion_venta
            // 
            this.invoice_pos__r_condicion_venta.AutoSize = true;
            this.invoice_pos__r_condicion_venta.Location = new System.Drawing.Point(30, 86);
            this.invoice_pos__r_condicion_venta.Name = "invoice_pos__r_condicion_venta";
            this.invoice_pos__r_condicion_venta.Size = new System.Drawing.Size(119, 17);
            this.invoice_pos__r_condicion_venta.TabIndex = 73;
            this.invoice_pos__r_condicion_venta.Text = "Condicion de Venta";
            this.invoice_pos__r_condicion_venta.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Desde";
            // 
            // btn_invoice_ventas_diario
            // 
            this.btn_invoice_ventas_diario.Location = new System.Drawing.Point(584, 47);
            this.btn_invoice_ventas_diario.Name = "btn_invoice_ventas_diario";
            this.btn_invoice_ventas_diario.Size = new System.Drawing.Size(163, 21);
            this.btn_invoice_ventas_diario.TabIndex = 74;
            this.btn_invoice_ventas_diario.Text = "Reporte de Ventas Diarios";
            this.btn_invoice_ventas_diario.UseVisualStyleBackColor = true;
            this.btn_invoice_ventas_diario.Click += new System.EventHandler(this.btn_invoice_ventas_diario_Click);
            // 
            // btn_invoice_gastos_diario
            // 
            this.btn_invoice_gastos_diario.Location = new System.Drawing.Point(753, 46);
            this.btn_invoice_gastos_diario.Name = "btn_invoice_gastos_diario";
            this.btn_invoice_gastos_diario.Size = new System.Drawing.Size(163, 21);
            this.btn_invoice_gastos_diario.TabIndex = 76;
            this.btn_invoice_gastos_diario.Text = "Proveedores Diarios";
            this.btn_invoice_gastos_diario.UseVisualStyleBackColor = true;
            this.btn_invoice_gastos_diario.Click += new System.EventHandler(this.btn_invoice_gastos_diario_Click);
            // 
            // btn_invoice_gastos_general
            // 
            this.btn_invoice_gastos_general.Location = new System.Drawing.Point(753, 18);
            this.btn_invoice_gastos_general.Name = "btn_invoice_gastos_general";
            this.btn_invoice_gastos_general.Size = new System.Drawing.Size(163, 21);
            this.btn_invoice_gastos_general.TabIndex = 75;
            this.btn_invoice_gastos_general.Text = "Proveedores General";
            this.btn_invoice_gastos_general.UseVisualStyleBackColor = true;
            this.btn_invoice_gastos_general.Click += new System.EventHandler(this.btn_invoice_gastos_general_Click);
            // 
            // btn_invoice_ventas_clientes
            // 
            this.btn_invoice_ventas_clientes.Location = new System.Drawing.Point(584, 76);
            this.btn_invoice_ventas_clientes.Name = "btn_invoice_ventas_clientes";
            this.btn_invoice_ventas_clientes.Size = new System.Drawing.Size(163, 21);
            this.btn_invoice_ventas_clientes.TabIndex = 77;
            this.btn_invoice_ventas_clientes.Text = "Reporte de Ventas por Cliente";
            this.btn_invoice_ventas_clientes.UseVisualStyleBackColor = true;
            this.btn_invoice_ventas_clientes.Click += new System.EventHandler(this.btn_invoice_ventas_clientes_Click);
            // 
            // btn_invoice_gastos_proveedor
            // 
            this.btn_invoice_gastos_proveedor.Location = new System.Drawing.Point(753, 74);
            this.btn_invoice_gastos_proveedor.Name = "btn_invoice_gastos_proveedor";
            this.btn_invoice_gastos_proveedor.Size = new System.Drawing.Size(163, 21);
            this.btn_invoice_gastos_proveedor.TabIndex = 79;
            this.btn_invoice_gastos_proveedor.Text = "Compras por Provedoor";
            this.btn_invoice_gastos_proveedor.UseVisualStyleBackColor = true;
            this.btn_invoice_gastos_proveedor.Click += new System.EventHandler(this.btn_invoice_gastos_proveedor_Click);
            // 
            // btn_invoice_gastos_x_impuesto
            // 
            this.btn_invoice_gastos_x_impuesto.Location = new System.Drawing.Point(754, 130);
            this.btn_invoice_gastos_x_impuesto.Name = "btn_invoice_gastos_x_impuesto";
            this.btn_invoice_gastos_x_impuesto.Size = new System.Drawing.Size(163, 21);
            this.btn_invoice_gastos_x_impuesto.TabIndex = 80;
            this.btn_invoice_gastos_x_impuesto.Text = "Por Tipo de Impuestos";
            this.btn_invoice_gastos_x_impuesto.UseVisualStyleBackColor = true;
            this.btn_invoice_gastos_x_impuesto.Click += new System.EventHandler(this.btn_invoice_gastos_x_impuesto_Click);
            // 
            // btn_invoice_gastos_proveedor_detalle
            // 
            this.btn_invoice_gastos_proveedor_detalle.Location = new System.Drawing.Point(754, 102);
            this.btn_invoice_gastos_proveedor_detalle.Name = "btn_invoice_gastos_proveedor_detalle";
            this.btn_invoice_gastos_proveedor_detalle.Size = new System.Drawing.Size(163, 21);
            this.btn_invoice_gastos_proveedor_detalle.TabIndex = 81;
            this.btn_invoice_gastos_proveedor_detalle.Text = "Detallado por Provedoor";
            this.btn_invoice_gastos_proveedor_detalle.UseVisualStyleBackColor = true;
            this.btn_invoice_gastos_proveedor_detalle.Click += new System.EventHandler(this.btn_invoice_gastos_proveedor_detalle_Click);
            // 
            // btn_invoice_ventas_clientes_detallado
            // 
            this.btn_invoice_ventas_clientes_detallado.Location = new System.Drawing.Point(584, 130);
            this.btn_invoice_ventas_clientes_detallado.Name = "btn_invoice_ventas_clientes_detallado";
            this.btn_invoice_ventas_clientes_detallado.Size = new System.Drawing.Size(163, 21);
            this.btn_invoice_ventas_clientes_detallado.TabIndex = 82;
            this.btn_invoice_ventas_clientes_detallado.Text = "Por Tipo de Impuestos";
            this.btn_invoice_ventas_clientes_detallado.UseVisualStyleBackColor = true;
            this.btn_invoice_ventas_clientes_detallado.Click += new System.EventHandler(this.btn_invoice_ventas_clientes_detallado_Click);
            // 
            // chkAgrupado
            // 
            this.chkAgrupado.AutoSize = true;
            this.chkAgrupado.Checked = true;
            this.chkAgrupado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAgrupado.Location = new System.Drawing.Point(584, 107);
            this.chkAgrupado.Name = "chkAgrupado";
            this.chkAgrupado.Size = new System.Drawing.Size(72, 17);
            this.chkAgrupado.TabIndex = 79;
            this.chkAgrupado.Text = "Agrupado";
            this.chkAgrupado.UseVisualStyleBackColor = true;
            // 
            // btn_reporte_inventario
            // 
            this.btn_reporte_inventario.Location = new System.Drawing.Point(584, 158);
            this.btn_reporte_inventario.Name = "btn_reporte_inventario";
            this.btn_reporte_inventario.Size = new System.Drawing.Size(163, 21);
            this.btn_reporte_inventario.TabIndex = 83;
            this.btn_reporte_inventario.Text = "Reporte de Inventario";
            this.btn_reporte_inventario.UseVisualStyleBackColor = true;
            this.btn_reporte_inventario.Click += new System.EventHandler(this.btn_reporte_inventario_Click);
            // 
            // frm_pos_invoice_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 578);
            this.Controls.Add(this.btn_reporte_inventario);
            this.Controls.Add(this.chkAgrupado);
            this.Controls.Add(this.btn_invoice_ventas_clientes_detallado);
            this.Controls.Add(this.btn_invoice_gastos_proveedor_detalle);
            this.Controls.Add(this.btn_invoice_gastos_x_impuesto);
            this.Controls.Add(this.btn_invoice_gastos_proveedor);
            this.Controls.Add(this.btn_invoice_ventas_clientes);
            this.Controls.Add(this.btn_invoice_gastos_diario);
            this.Controls.Add(this.btn_invoice_gastos_general);
            this.Controls.Add(this.btn_invoice_ventas_diario);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.invoice_wb1);
            this.Controls.Add(this.btn_invoice_ventas_general);
            this.Name = "frm_pos_invoice_report";
            this.Text = "Invoice Maintenance";
            this.Load += new System.EventHandler(this.frm_pos_invoice_report_Load);
            this.Resize += new System.EventHandler(this.frm_pos_invoice_report_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker invoice_pos__r_dt1;
        private System.Windows.Forms.DateTimePicker invoice_pos__r_dt2;
        private System.Windows.Forms.Button btn_invoice_ventas_general;
        private System.Windows.Forms.WebBrowser invoice_wb1;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox invoice_pos__r_condicion_venta;
        private System.Windows.Forms.CheckBox invoice_pos__r_medio_pago;
        private System.Windows.Forms.Button btn_invoice_ventas_diario;
        private System.Windows.Forms.CheckBox invoice_pos__r_td_te;
        private System.Windows.Forms.CheckBox invoice_pos__r_td_fe;
        private System.Windows.Forms.Button btn_invoice_gastos_diario;
        private System.Windows.Forms.Button btn_invoice_gastos_general;
        private System.Windows.Forms.Button btn_invoice_ventas_clientes;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox invoice_pos__r_td_nc;
        private System.Windows.Forms.Button btn_invoice_gastos_proveedor;
        private System.Windows.Forms.CheckBox invoice_pos__r_moneda;
        private System.Windows.Forms.Button btn_invoice_gastos_x_impuesto;
        private System.Windows.Forms.CheckBox invoice_pos__r_gastosycompras;
        private System.Windows.Forms.Button btn_invoice_gastos_proveedor_detalle;
        private System.Windows.Forms.Button btn_invoice_ventas_clientes_detallado;
        private System.Windows.Forms.CheckBox chkAgrupado;
        private System.Windows.Forms.Button btn_reporte_inventario;
    }
}