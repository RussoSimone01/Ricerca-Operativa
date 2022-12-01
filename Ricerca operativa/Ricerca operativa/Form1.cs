using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ricerca_operativa
{
    public partial class Form1 : Form
    {
        private int P;  //numero produttori
        private int D;  //numero destinazioni
        private bool prodMaggiori;  //indica se il totale dei produttori supera quello dei consumatori
        private bool destMaggiori;  //inverso del precedente
        
        public Form1()
        {
            InitializeComponent();
        }

        //inizializza la tabella
        private void SetNum_Click(object sender, EventArgs e)
        {
            if (dati.RowCount != 0)
                if (MessageBox.Show("La matrice di valori verrà resettata. Continuare?", "Conferma", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            NomeRicerca.Visible = false;
            Dettaglio.Visible = false;
            dati.RowCount = 0;
            dati.ColumnCount = 0;
            P = (int)numProd.Value;
            D = (int)numDest.Value;
            
            //aggiunta colonne
            dati.Columns.Add("C","");
            dati.Columns["C"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dati.Columns["C"].ReadOnly = true;
            for (int i = 0; i < D; i++)
            {
                dati.Columns.Add("D" + (i+1), "D" + (i+1));
                dati.Columns["D" + (i + 1)].SortMode = DataGridViewColumnSortMode.NotSortable;
                dati.Columns["D" + (i + 1)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dati.Columns.Add("Prod", "Capacità");
            dati.Columns["Prod"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dati.Columns["Prod"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //aggiunta righe
            for (int i = 0; i < P; i++)
                dati.Rows.Add("P" + (i+1));
            dati.Rows.Add("Necessità");
            dati[dati.ColumnCount - 1, dati.RowCount - 1].ReadOnly = true;

            NordOvest.Visible = true;
            MinimiCosti.Visible = true;
            Vogel.Visible = true;
            Russell.Visible = true;
            labelNordOvest.Visible = true;
            labelMinimiCosti.Visible = true;
            labelVogel.Visible = true;
            labelRussell.Visible = true;
            calcolaNO.Visible = true;
            calcolaMC.Visible = true;
            calcolaVG.Visible = true;
            calcolaRS.Visible = true;
            dati.Visible = true;
            NordOvest.Text = "";
            MinimiCosti.Text = "";
            Vogel.Text = "";
            Russell.Text = "";
        }

        //inizializzazione matrice contenente i dati della tabella
        private int[][] SetUpGrid()
        {
            prodMaggiori = false;
            destMaggiori = false;
            int[][] grid;
            bool pieno = true;
            int D = this.D;
            int P = this.P;
            int totP = 0, totD = 0;

            try
            {
                //calcolo dei totali
                for (int i = 0; i < dati.RowCount - 1; i++)
                    if (dati.Rows[i].Cells[dati.ColumnCount - 1].Value != null)
                    {
                        if (int.Parse(dati.Rows[i].Cells[dati.ColumnCount - 1].Value.ToString()) > 0)
                            totP += int.Parse(dati.Rows[i].Cells[dati.ColumnCount - 1].Value.ToString());
                        else
                            throw new FormatException();
                    }

                for (int i = 1; i < dati.ColumnCount - 1; i++)
                    if (dati.Rows[dati.RowCount - 1].Cells[i].Value != null)
                    {
                        if (int.Parse(dati.Rows[dati.RowCount - 1].Cells[i].Value.ToString()) > 0)
                            totD += int.Parse(dati.Rows[dati.RowCount - 1].Cells[i].Value.ToString());
                        else
                            throw new FormatException();
                    }

                if (totP > totD)
                    D++;
                else if (totP < totD)
                    P++;
            }
            catch (FormatException)
            {
                pieno = false;
            }

            grid = new int[P + 1][];
            try
            { 
                //caricamento e controllo sulla mancanza e la correttezza di dati
                for (int i = 0; i < dati.RowCount; i++)
                {
                    grid[i] = new int[D + 1];
                    for (int j = 1; j < dati.ColumnCount; j++)
                    {
                        if (i != dati.RowCount - 1 || j != dati.ColumnCount - 1)
                        {
                            if (dati.Rows[i].Cells[j].Value == null || int.Parse(dati.Rows[i].Cells[j].Value.ToString()) <= 0)
                            {
                                pieno = false;
                                i = dati.RowCount;
                                j = dati.ColumnCount;
                            }
                            else
                                grid[i][j - 1] = int.Parse(dati.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }
            }
            catch(FormatException)
            {
                pieno = false;
            }

            //se la tabella è stata completamente riempita
            if (pieno)
            {
                //aggiunta di eventuali produttori/destinazioni fittizi
                if (totP > totD)
                {
                    for (int i = 0; i < P; i++)
                    {
                        grid[i][D] = grid[i][D - 1];
                        grid[i][D - 1] = 1000;
                    }
                    grid[P][D - 1] = totP - totD;
                    prodMaggiori = true;
                    dati[dati.ColumnCount - 1, dati.RowCount - 1].Value = "P: +" + (totP - totD);
                }
                else if (totP < totD)
                {
                    grid[P] = new int[D + 1];
                    grid[P - 1].CopyTo(grid[P], 0);
                    grid[P - 1] = new int[D + 1];
                    for (int i = 0; i < D; i++)
                        grid[P - 1][i] = 1000;
                    grid[P - 1][D] = totD - totP;
                    destMaggiori = true;
                    dati[dati.ColumnCount - 1, dati.RowCount - 1].Value = "D: +" + (totD - totP);
                }
                else
                    dati[dati.ColumnCount - 1, dati.RowCount - 1].Value = totD;
            }
            else
            {
                MessageBox.Show("Dati mancanti o invalidi");
                return null;
            }
            return grid;
        }

        //pulsante calcolo Nord Ovest
        private void CalcolaNO_Click(object sender, EventArgs e)
        {
            int[][] grid = SetUpGrid();
            if(grid != null)
            {
                Dettaglio.RowCount = 0;
                NordOvest.Text = MetodoNordOvest(grid).ToString();
                Dettaglio.Visible = true;
                NomeRicerca.Text = "Metodo Nord Ovest";
                NomeRicerca.Visible = true;
            }
        }

        private long MetodoNordOvest(int[][] grid)
        {
            long res = 0;
            int D = this.D;
            int P = this.P;
            //in caso di produttori/destinazioni fittizi
            if (destMaggiori)
                P++;
            if (prodMaggiori)
                D++;
            //usato per la memorizzazione dei nomi
            int[] nomiP = new int[P];
            int[] nomiD = new int[D];
            for (int i = 0; i < P; i++)
                nomiP[i] = i + 1;
            for (int i = 0; i < D; i++)
                nomiD[i] = i + 1;

            while (D > 0 && P > 0)
            {
                //confronto tra offerta del produttore e domanda della destinazione
                if (grid[P][0] > grid[0][D])
                {
                    Dettaglio.Rows.Add(grid[0][D].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[0] + " -> " + "D" + nomiD[0];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[0][D] * grid[0][0]).ToString();
                    for (int i = 0; i < P - 1; i++)
                        nomiP[i] = nomiP[i + 1];

                    res += grid[0][D] * grid[0][0]; //aggiornamento risultato
                    grid[P][0] -= grid[0][D];   //aggiornamento domanda offerta
                    for (int i = 0; i < P; i++) //shift righe
                        grid[i] = grid[i + 1];
                    grid[P] = null; //eliminazione riga
                    P--;
                }
                else if (grid[P][0] < grid[0][D])
                {
                    Dettaglio.Rows.Add(grid[P][0].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[0] + " -> " + "D" + nomiD[0];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[P][0] * grid[0][0]).ToString();
                    for (int i = 0; i < D - 1; i++)
                        nomiD[i] = nomiD[i + 1];

                    res += grid[P][0] * grid[0][0];
                    grid[0][D] -= grid[P][0];
                    for(int j = 0; j < P + 1; j++)
                        for (int i = 0; i < D; i++)
                            grid[j][i] = grid[j][i + 1];    //shift colonne
                    D--;
                }
                else if (grid[P][0] == grid[0][D])
                {
                    Dettaglio.Rows.Add(grid[0][D].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[0] + " -> " + "D" + nomiD[0];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[P][0] * grid[0][0]).ToString();
                    for (int i = 0; i < D - 1; i++)
                        nomiD[i] = nomiD[i + 1];
                    for (int i = 0; i < P - 1; i++)
                        nomiP[i] = nomiP[i + 1];

                    res += grid[P][0] * grid[0][0];
                    for (int j = 0; j < P + 1; j++)
                        for (int i = 0; i < D; i++)
                            grid[j][i] = grid[j][i + 1];
                    D--;
                    for (int i = 0; i < P; i++)
                        grid[i] = grid[i + 1];
                    grid[P] = null;
                    P--;
                }
            }
            Dettaglio.Rows.Add();
            Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = res;
            return res;
        }

        //pulsante calcolo minimi costi
        private void calcolaMC_Click(object sender, EventArgs e)
        {
            int[][] grid = SetUpGrid();
            if (grid != null)
            {
                Dettaglio.RowCount = 0;
                MinimiCosti.Text = MetodoMinimiCosti(grid).ToString();
                Dettaglio.Visible = true;
                NomeRicerca.Text = "Metodo Minimi Costi";
                NomeRicerca.Visible = true;
            }
        }

        private long MetodoMinimiCosti(int[][] grid)
        {
            long res = 0;
            int D = this.D;
            int P = this.P;
            //in caso di produttori/destinazioni fittizi
            if (destMaggiori)
                P++;
            if (prodMaggiori)
                D++;
            //usato per la memorizzazione dei nomi
            int[] nomiP = new int[P];
            int[] nomiD = new int[D];
            for (int i = 0; i < P; i++)
                nomiP[i] = i + 1;
            for (int i = 0; i < D; i++)
                nomiD[i] = i + 1;
            int riga;
            int colonna;

            while (D > 0 && P > 0)
            {
                riga = 0;
                colonna = 0;
                int aux = grid[0][0];
                //rilevazione costo minore
                for(int i = 0; i < P; i++)
                    for(int j = 0; j < D; j++)
                        if(grid[i][j] < aux)
                        {
                            riga = i;
                            colonna = j;
                            aux = grid[i][j];
                        }
                
                //confronto tra offerta del produttore e domanda della destinazione
                if (grid[P][colonna] > grid[riga][D])
                {
                    Dettaglio.Rows.Add(grid[riga][D].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[riga] + " -> " + "D" + nomiD[colonna];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[riga][D] * aux).ToString();
                    for (int i = riga; i < P - 1; i++)
                        nomiP[i] = nomiP[i + 1];

                    res += grid[riga][D] * aux;
                    grid[P][colonna] -= grid[riga][D];
                    for (int i = riga; i < P; i++)
                        grid[i] = grid[i + 1];
                    grid[P] = null;
                    P--;
                }
                else if (grid[P][colonna] < grid[riga][D])
                {
                    Dettaglio.Rows.Add(grid[P][colonna].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[riga] + " -> " + "D" + nomiD[colonna];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[P][colonna] * aux).ToString();
                    for (int i = colonna; i < D - 1; i++)
                        nomiD[i] = nomiD[i + 1];

                    res += grid[P][colonna] * aux;
                    grid[riga][D] -= grid[P][colonna];
                    for (int j = 0; j < P + 1; j++)
                        for (int i = colonna; i < D; i++)
                            grid[j][i] = grid[j][i + 1];
                    D--;
                }
                else if (grid[P][colonna] == grid[riga][D])
                {
                    Dettaglio.Rows.Add(grid[riga][D].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[riga] + " -> " + "D" + nomiD[colonna];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[riga][D] * aux).ToString();
                    for (int i = riga; i < P - 1; i++)
                        nomiP[i] = nomiP[i + 1];
                    for (int i = colonna; i < D - 1; i++)
                        nomiD[i] = nomiD[i + 1];

                    res += grid[P][colonna] * aux;
                    for (int j = 0; j < P + 1; j++)
                        for (int i = colonna; i < D; i++)
                            grid[j][i] = grid[j][i + 1];
                    D--;
                    for (int i = riga; i < P; i++)
                        grid[i] = grid[i + 1];
                    grid[P] = null;
                    P--;
                }
            }
            Dettaglio.Rows.Add();
            Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = res;
            return res;
        }

        //pulsante calcolo Vogel
        private void calcolaVG_Click(object sender, EventArgs e)
        {
            int[][] grid = SetUpGrid();
            if (grid != null)
            {
                Dettaglio.RowCount = 0;
                Vogel.Text = MetodoVogel(grid).ToString();
                NomeRicerca.Text = "Metodo Vogel";
                Dettaglio.Visible = true;
            }
        }

        private long MetodoVogel(int[][] grid)
        {
            long res = 0;
            int D = this.D;
            int P = this.P;
            //in caso di produttori/destinazioni fittizi
            if (destMaggiori)
                P++;
            if (prodMaggiori)
                D++;
            //usato per la memorizzazione dei nomi
            int[] nomiP = new int[P];
            int[] nomiD = new int[D];
            for (int i = 0; i < P; i++)
                nomiP[i] = i + 1;
            for (int i = 0; i < D; i++)
                nomiD[i] = i + 1;

            while (D > 0 && P > 0)
            {
                int[] best = new int[2];
                int rig = 0, rigind = 0, col = 0, colind = 0;

                //ciclo per le righe
                for (int i = 0; i < P; i++)
                {
                    int j = 0;
                    best[0] = grid[i][j++];
                    if (j < D)
                        best[1] = grid[i][j++];
                    else
                        best[1] = 0;

                    //rilevazione dei due costi minori per riga
                    while (j < D)
                    {
                        if (grid[i][j] < best[0])
                        {
                            if (best[0] < best[1])
                                best[1] = grid[i][j];
                            else
                                best[0] = grid[i][j];
                        }
                        else if(grid[i][j] < best[1])
                            best[1] = grid[i][j];
                        j++;
                    }
                    //confronto con il valore minore delle righe
                    if (rig < Math.Abs(best[0] - best[1]))
                    {
                        rig = Math.Abs(best[0] - best[1]);
                        rigind = i;
                    }
                }

                //ciclo per le colonne
                for (int i = 0; i < D; i++)
                {
                    int j = 0;
                    best[0] = grid[j++][i];
                    if (j < P)
                        best[1] = grid[j++][i];
                    else
                        best[1] = 0;

                    //rilevazione dei due costi minori per colonna
                    while (j < P)
                    {
                        if (grid[j][i] < best[0])
                        {
                            if(best[0] < best[1])
                                best[1] = grid[j][i];
                            else
                                best[0] = grid[j][i];
                        }
                        else if (grid[j][i] < best[1])
                            best[1] = grid[j][i];
                        j++;
                    }
                    //confronto con il valore minore delle colonne
                    if (col < Math.Abs(best[0] - best[1]))
                    {
                        col = Math.Abs(best[0] - best[1]);
                        colind = i;
                    }
                }

                int riga = 0, colonna = 0, aux = 0;
                //confronto tra il valore minore tra quello delle righe e delle colonne
                if (col >= rig)
                {
                    //ricerca del minimo nella colonna risultato
                    aux = grid[0][colind];
                    colonna = colind;
                    for (int i = 1; i < P; i++)
                        if (grid[i][colind] < aux)
                        {
                            riga = i;
                            aux = grid[i][colind];
                        }
                }
                else if (col < rig)
                {
                    //ricerca del minimo nella riga risultato
                    aux = grid[rigind][0];
                    riga = rigind;
                    for (int i = 1; i < D; i++)
                        if (grid[rigind][i] < aux)
                        {
                            colonna = i;
                            aux = grid[rigind][i];
                        }
                }

                //confronto tra offerta del produttore e domanda della destinazione
                if (grid[P][colonna] > grid[riga][D])
                {
                    Dettaglio.Rows.Add(grid[riga][D].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[riga] + " -> " + "D" + nomiD[colonna];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[riga][D] * aux).ToString();
                    for (int i = riga; i < P - 1; i++)
                        nomiP[i] = nomiP[i + 1];

                    res += grid[riga][D] * aux;
                    grid[P][colonna] -= grid[riga][D];
                    for (int i = riga; i < P; i++)
                        grid[i] = grid[i + 1];
                    grid[P] = null;
                    P--;
                }
                else if (grid[P][colonna] < grid[riga][D])
                {
                    Dettaglio.Rows.Add(grid[P][colonna].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[riga] + " -> " + "D" + nomiD[colonna];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[P][colonna] * aux).ToString();
                    for (int i = colonna; i < D - 1; i++)
                        nomiD[i] = nomiD[i + 1];

                    res += grid[P][colonna] * aux;
                    grid[riga][D] -= grid[P][colonna];
                    for (int j = 0; j < P + 1; j++)
                        for (int i = colonna; i < D; i++)
                            grid[j][i] = grid[j][i + 1];
                    D--;
                }
                else if (grid[P][colonna] == grid[riga][D])
                {
                    Dettaglio.Rows.Add(grid[P][colonna].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[riga] + " -> " + "D" + nomiD[colonna];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[P][colonna] * aux).ToString();
                    for (int i = riga; i < P - 1; i++)
                        nomiP[i] = nomiP[i + 1];
                    for (int i = colonna; i < D - 1; i++)
                        nomiD[i] = nomiD[i + 1];

                    res += grid[P][colonna] * aux;
                    for (int j = 0; j < P + 1; j++)
                        for (int i = colonna; i < D; i++)
                            grid[j][i] = grid[j][i + 1];
                    D--;
                    for (int i = riga; i < P; i++)
                        grid[i] = grid[i + 1];
                    grid[P] = null;
                    P--;
                }
            }
            Dettaglio.Rows.Add();
            Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = res;
            return res;
        }

        //pulsante calcolo Russell
        private void calcolaRS_Click(object sender, EventArgs e)
        {
            int[][] grid = SetUpGrid();
            if (grid != null)
            {
                Dettaglio.RowCount = 0;
                Russell.Text = MetodoRussell(grid).ToString();
                NomeRicerca.Text = "Metodo Russell";
                Dettaglio.Visible = true;
            }
        }

        private long MetodoRussell(int[][] grid)
        {
            long res = 0;
            int D = this.D;
            int P = this.P;
            //in caso di produttori/destinazioni fittizi
            if (destMaggiori)
                P++;
            if (prodMaggiori)
                D++;
            //usato per la memorizzazione dei nomi
            int[] nomiP = new int[P];
            int[] nomiD = new int[D];
            for (int i = 0; i < P; i++)
                nomiP[i] = i + 1;
            for (int i = 0; i < D; i++)
                nomiD[i] = i + 1;

            while (D > 0 && P > 0)
            {
                int[] righe = new int[P], colonne = new int[D];
                //ricerca del maggiore per ogni riga
                for (int i = 0; i < P; i++)
                {
                    righe[i] = grid[i][0];
                    for (int j = 1; j < D; j++)
                        if (grid[i][j] > righe[i])
                            righe[i] = grid[i][j];
                }
                //ricerca del maggiore per ogni colonna
                for (int i = 0; i < D; i++)
                {
                    colonne[i] = grid[0][i];
                    for (int j = 1; j < P; j++)
                        if (grid[j][i] > colonne[i])
                            colonne[i] = grid[j][i];
                }
                //ricerca del massimo nella tabella
                int max = 0, colonna = 0, riga = 0;
                for (int i = 0; i < P; i++)
                    for (int j = 0; j < D; j++)
                        if (max < Math.Abs(grid[i][j] - righe[i] - colonne[j]))
                        {
                            max = Math.Abs(grid[i][j] - righe[i] - colonne[j]);
                            riga = i;
                            colonna = j;
                        }

                //confronto tra offerta del produttore e domanda della destinazione
                if (grid[P][colonna] > grid[riga][D])
                {
                    Dettaglio.Rows.Add(grid[riga][D].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[riga] + " -> " + "D" + nomiD[colonna];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[riga][D] * grid[riga][colonna]).ToString();
                    for (int i = riga; i < P - 1; i++)
                        nomiP[i] = nomiP[i + 1];

                    res += grid[riga][D] * grid[riga][colonna];
                    grid[P][colonna] -= grid[riga][D];
                    for (int i = riga; i < P; i++)
                        grid[i] = grid[i + 1];
                    grid[P] = null;
                    P--;
                }
                else if (grid[P][colonna] < grid[riga][D])
                {
                    Dettaglio.Rows.Add(grid[P][colonna].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[riga] + " -> " + "D" + nomiD[colonna];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[P][colonna] * grid[riga][colonna]).ToString();
                    for (int i = colonna; i < D - 1; i++)
                        nomiD[i] = nomiD[i + 1];

                    res += grid[P][colonna] * grid[riga][colonna];
                    grid[riga][D] -= grid[P][colonna];
                    for (int j = 0; j < P + 1; j++)
                        for (int i = colonna; i < D; i++)
                            grid[j][i] = grid[j][i + 1];
                    D--;
                }
                else if (grid[P][colonna] == grid[riga][D])
                {
                    Dettaglio.Rows.Add(grid[P][colonna].ToString());
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[1].Value = "P" + nomiP[riga] + " -> " + "D" + nomiD[colonna];
                    Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = (grid[P][colonna] * grid[riga][colonna]).ToString();
                    for (int i = riga; i < P - 1; i++)
                        nomiP[i] = nomiP[i + 1];
                    for (int i = colonna; i < D - 1; i++)
                        nomiD[i] = nomiD[i + 1];

                    res += grid[P][colonna] * grid[riga][colonna];
                    for (int j = 0; j < P + 1; j++)
                        for (int i = colonna; i < D; i++)
                            grid[j][i] = grid[j][i + 1];
                    D--;
                    for (int i = riga; i < P; i++)
                        grid[i] = grid[i + 1];
                    grid[P] = null;
                    P--;
                }
            }
            Dettaglio.Rows.Add();
            Dettaglio.Rows[Dettaglio.RowCount - 1].Cells[2].Value = res;
            return res;
        }
    }
}
