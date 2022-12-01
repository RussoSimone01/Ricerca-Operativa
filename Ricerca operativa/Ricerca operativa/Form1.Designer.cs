namespace Ricerca_operativa
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelNumProd = new System.Windows.Forms.Label();
            this.numProd = new System.Windows.Forms.NumericUpDown();
            this.numDest = new System.Windows.Forms.NumericUpDown();
            this.labelNumDest = new System.Windows.Forms.Label();
            this.setNum = new System.Windows.Forms.Button();
            this.dati = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcolaNO = new System.Windows.Forms.Button();
            this.labelNordOvest = new System.Windows.Forms.Label();
            this.NordOvest = new System.Windows.Forms.TextBox();
            this.MinimiCosti = new System.Windows.Forms.TextBox();
            this.labelMinimiCosti = new System.Windows.Forms.Label();
            this.Vogel = new System.Windows.Forms.TextBox();
            this.labelVogel = new System.Windows.Forms.Label();
            this.calcolaMC = new System.Windows.Forms.Button();
            this.calcolaVG = new System.Windows.Forms.Button();
            this.calcolaRS = new System.Windows.Forms.Button();
            this.Russell = new System.Windows.Forms.TextBox();
            this.labelRussell = new System.Windows.Forms.Label();
            this.Dettaglio = new System.Windows.Forms.DataGridView();
            this.Quanti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeRicerca = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dettaglio)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumProd
            // 
            this.labelNumProd.AutoSize = true;
            this.labelNumProd.Location = new System.Drawing.Point(12, 18);
            this.labelNumProd.Name = "labelNumProd";
            this.labelNumProd.Size = new System.Drawing.Size(102, 13);
            this.labelNumProd.TabIndex = 0;
            this.labelNumProd.Text = "Numero di produttori";
            // 
            // numProd
            // 
            this.numProd.Location = new System.Drawing.Point(120, 16);
            this.numProd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numProd.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numProd.Name = "numProd";
            this.numProd.Size = new System.Drawing.Size(62, 20);
            this.numProd.TabIndex = 1;
            this.numProd.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numDest
            // 
            this.numDest.Location = new System.Drawing.Point(321, 16);
            this.numDest.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDest.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numDest.Name = "numDest";
            this.numDest.Size = new System.Drawing.Size(62, 20);
            this.numDest.TabIndex = 3;
            this.numDest.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // labelNumDest
            // 
            this.labelNumDest.AutoSize = true;
            this.labelNumDest.Location = new System.Drawing.Point(202, 18);
            this.labelNumDest.Name = "labelNumDest";
            this.labelNumDest.Size = new System.Drawing.Size(113, 13);
            this.labelNumDest.TabIndex = 2;
            this.labelNumDest.Text = "Numero di destinazioni";
            // 
            // setNum
            // 
            this.setNum.Location = new System.Drawing.Point(401, 13);
            this.setNum.Name = "setNum";
            this.setNum.Size = new System.Drawing.Size(75, 23);
            this.setNum.TabIndex = 4;
            this.setNum.Text = "Applica";
            this.setNum.UseVisualStyleBackColor = true;
            this.setNum.Click += new System.EventHandler(this.SetNum_Click);
            // 
            // dati
            // 
            this.dati.AllowUserToAddRows = false;
            this.dati.AllowUserToDeleteRows = false;
            this.dati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dati.Location = new System.Drawing.Point(15, 42);
            this.dati.Name = "dati";
            this.dati.Size = new System.Drawing.Size(461, 314);
            this.dati.TabIndex = 5;
            this.dati.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 5;
            // 
            // calcolaNO
            // 
            this.calcolaNO.Location = new System.Drawing.Point(24, 412);
            this.calcolaNO.Name = "calcolaNO";
            this.calcolaNO.Size = new System.Drawing.Size(75, 23);
            this.calcolaNO.TabIndex = 6;
            this.calcolaNO.Text = "Calcola";
            this.calcolaNO.UseVisualStyleBackColor = true;
            this.calcolaNO.Visible = false;
            this.calcolaNO.Click += new System.EventHandler(this.CalcolaNO_Click);
            // 
            // labelNordOvest
            // 
            this.labelNordOvest.AutoSize = true;
            this.labelNordOvest.Location = new System.Drawing.Point(38, 370);
            this.labelNordOvest.Name = "labelNordOvest";
            this.labelNordOvest.Size = new System.Drawing.Size(61, 13);
            this.labelNordOvest.TabIndex = 7;
            this.labelNordOvest.Text = "Nord-Ovest";
            this.labelNordOvest.Visible = false;
            // 
            // NordOvest
            // 
            this.NordOvest.Enabled = false;
            this.NordOvest.Location = new System.Drawing.Point(15, 386);
            this.NordOvest.Name = "NordOvest";
            this.NordOvest.ReadOnly = true;
            this.NordOvest.Size = new System.Drawing.Size(100, 20);
            this.NordOvest.TabIndex = 8;
            this.NordOvest.Visible = false;
            // 
            // MinimiCosti
            // 
            this.MinimiCosti.Enabled = false;
            this.MinimiCosti.Location = new System.Drawing.Point(131, 386);
            this.MinimiCosti.Name = "MinimiCosti";
            this.MinimiCosti.ReadOnly = true;
            this.MinimiCosti.Size = new System.Drawing.Size(100, 20);
            this.MinimiCosti.TabIndex = 10;
            this.MinimiCosti.Visible = false;
            // 
            // labelMinimiCosti
            // 
            this.labelMinimiCosti.AutoSize = true;
            this.labelMinimiCosti.Location = new System.Drawing.Point(152, 370);
            this.labelMinimiCosti.Name = "labelMinimiCosti";
            this.labelMinimiCosti.Size = new System.Drawing.Size(61, 13);
            this.labelMinimiCosti.TabIndex = 9;
            this.labelMinimiCosti.Text = "Minimi costi";
            this.labelMinimiCosti.Visible = false;
            // 
            // Vogel
            // 
            this.Vogel.Enabled = false;
            this.Vogel.Location = new System.Drawing.Point(247, 386);
            this.Vogel.Name = "Vogel";
            this.Vogel.ReadOnly = true;
            this.Vogel.Size = new System.Drawing.Size(100, 20);
            this.Vogel.TabIndex = 12;
            this.Vogel.Visible = false;
            // 
            // labelVogel
            // 
            this.labelVogel.AutoSize = true;
            this.labelVogel.Location = new System.Drawing.Point(282, 370);
            this.labelVogel.Name = "labelVogel";
            this.labelVogel.Size = new System.Drawing.Size(34, 13);
            this.labelVogel.TabIndex = 11;
            this.labelVogel.Text = "Vogel";
            this.labelVogel.Visible = false;
            // 
            // calcolaMC
            // 
            this.calcolaMC.Location = new System.Drawing.Point(138, 412);
            this.calcolaMC.Name = "calcolaMC";
            this.calcolaMC.Size = new System.Drawing.Size(75, 23);
            this.calcolaMC.TabIndex = 13;
            this.calcolaMC.Text = "Calcola";
            this.calcolaMC.UseVisualStyleBackColor = true;
            this.calcolaMC.Visible = false;
            this.calcolaMC.Click += new System.EventHandler(this.calcolaMC_Click);
            // 
            // calcolaVG
            // 
            this.calcolaVG.Location = new System.Drawing.Point(264, 412);
            this.calcolaVG.Name = "calcolaVG";
            this.calcolaVG.Size = new System.Drawing.Size(75, 23);
            this.calcolaVG.TabIndex = 14;
            this.calcolaVG.Text = "Calcola";
            this.calcolaVG.UseVisualStyleBackColor = true;
            this.calcolaVG.Visible = false;
            this.calcolaVG.Click += new System.EventHandler(this.calcolaVG_Click);
            // 
            // calcolaRS
            // 
            this.calcolaRS.Location = new System.Drawing.Point(380, 412);
            this.calcolaRS.Name = "calcolaRS";
            this.calcolaRS.Size = new System.Drawing.Size(75, 23);
            this.calcolaRS.TabIndex = 17;
            this.calcolaRS.Text = "Calcola";
            this.calcolaRS.UseVisualStyleBackColor = true;
            this.calcolaRS.Visible = false;
            this.calcolaRS.Click += new System.EventHandler(this.calcolaRS_Click);
            // 
            // Russell
            // 
            this.Russell.Enabled = false;
            this.Russell.Location = new System.Drawing.Point(363, 386);
            this.Russell.Name = "Russell";
            this.Russell.ReadOnly = true;
            this.Russell.Size = new System.Drawing.Size(100, 20);
            this.Russell.TabIndex = 16;
            this.Russell.Visible = false;
            // 
            // labelRussell
            // 
            this.labelRussell.AutoSize = true;
            this.labelRussell.Location = new System.Drawing.Point(398, 370);
            this.labelRussell.Name = "labelRussell";
            this.labelRussell.Size = new System.Drawing.Size(41, 13);
            this.labelRussell.TabIndex = 15;
            this.labelRussell.Text = "Russell";
            this.labelRussell.Visible = false;
            // 
            // Dettaglio
            // 
            this.Dettaglio.AllowUserToAddRows = false;
            this.Dettaglio.AllowUserToDeleteRows = false;
            this.Dettaglio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dettaglio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Quanti,
            this.Movimento,
            this.Costo});
            this.Dettaglio.Location = new System.Drawing.Point(482, 42);
            this.Dettaglio.Name = "Dettaglio";
            this.Dettaglio.ReadOnly = true;
            this.Dettaglio.Size = new System.Drawing.Size(306, 314);
            this.Dettaglio.TabIndex = 18;
            this.Dettaglio.Visible = false;
            // 
            // Quanti
            // 
            this.Quanti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Quanti.HeaderText = "Quantità";
            this.Quanti.Name = "Quanti";
            this.Quanti.ReadOnly = true;
            this.Quanti.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Movimento
            // 
            this.Movimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Movimento.HeaderText = "Movimento";
            this.Movimento.Name = "Movimento";
            this.Movimento.ReadOnly = true;
            this.Movimento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Costo
            // 
            this.Costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            this.Costo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NomeRicerca
            // 
            this.NomeRicerca.AutoSize = true;
            this.NomeRicerca.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.NomeRicerca.Location = new System.Drawing.Point(543, 11);
            this.NomeRicerca.Name = "NomeRicerca";
            this.NomeRicerca.Size = new System.Drawing.Size(64, 25);
            this.NomeRicerca.TabIndex = 19;
            this.NomeRicerca.Text = "label1";
            this.NomeRicerca.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NomeRicerca);
            this.Controls.Add(this.Dettaglio);
            this.Controls.Add(this.calcolaRS);
            this.Controls.Add(this.Russell);
            this.Controls.Add(this.labelRussell);
            this.Controls.Add(this.calcolaVG);
            this.Controls.Add(this.calcolaMC);
            this.Controls.Add(this.Vogel);
            this.Controls.Add(this.labelVogel);
            this.Controls.Add(this.MinimiCosti);
            this.Controls.Add(this.labelMinimiCosti);
            this.Controls.Add(this.NordOvest);
            this.Controls.Add(this.labelNordOvest);
            this.Controls.Add(this.calcolaNO);
            this.Controls.Add(this.dati);
            this.Controls.Add(this.setNum);
            this.Controls.Add(this.numDest);
            this.Controls.Add(this.labelNumDest);
            this.Controls.Add(this.numProd);
            this.Controls.Add(this.labelNumProd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Ricerca operativa";
            ((System.ComponentModel.ISupportInitialize)(this.numProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dettaglio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumProd;
        private System.Windows.Forms.NumericUpDown numProd;
        private System.Windows.Forms.NumericUpDown numDest;
        private System.Windows.Forms.Label labelNumDest;
        private System.Windows.Forms.Button setNum;
        private System.Windows.Forms.DataGridView dati;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button calcolaNO;
        private System.Windows.Forms.Label labelNordOvest;
        private System.Windows.Forms.TextBox NordOvest;
        private System.Windows.Forms.TextBox MinimiCosti;
        private System.Windows.Forms.Label labelMinimiCosti;
        private System.Windows.Forms.TextBox Vogel;
        private System.Windows.Forms.Label labelVogel;
        private System.Windows.Forms.Button calcolaMC;
        private System.Windows.Forms.Button calcolaVG;
        private System.Windows.Forms.Button calcolaRS;
        private System.Windows.Forms.TextBox Russell;
        private System.Windows.Forms.Label labelRussell;
        private System.Windows.Forms.DataGridView Dettaglio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quanti;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.Label NomeRicerca;
    }
}

