using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int item;
        int qnt;
        double unitario;
        double preco_total;
        double alterar; 
        private void calcular()
        {
            preco_total = 0;
            foreach (DataGridViewRow linha in dgvItem.Rows)
            {
                qnt = int.Parse(linha.Cells["Quant"].Value.ToString());
                unitario = double.Parse(linha.Cells[2].Value.ToString());

                preco_total += qnt * unitario;
            }
            lblTotal.Text = preco_total.ToString();
            
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

            dgvItem.Rows.Add(txtDesc.Text, txtQuant.Text, txtValorUni.Text);

            qnt = int.Parse(txtQuant.Text);

            unitario = double.Parse(txtValorUni.Text);

            preco_total = (qnt * unitario);

            lblTotal.Text = preco_total.ToString("C");

            MessageBox.Show("Item inserido com sucesso!", ": D", 
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dgvItem.RowCount > 0)
            {
                dgvItem.Rows.RemoveAt(dgvItem.CurrentRow.Index);

                MessageBox.Show("Item removido da compra", "Remoção",
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblTotal.Text = dgvItem.RowCount.ToString();
                calcular();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNovaVenda_Click(object sender, EventArgs e)
        {
            dgvItem.RowCount = 0;
            int Nvenda = int.Parse(txtVenda.Text);

            Nvenda++;

            txtVenda.Text = Convert.ToString(Nvenda);

            lblTotal.Text = "R$ 0,00";

            MessageBox.Show("Venda concluída", "Nova Venda",
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvItem.RowCount > 0)
            {
                txtAlteracao.Text = dgvItem.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtAlteracao.Text != " ")
            {
                dgvItem.CurrentRow.Cells["Quant"].Value = txtAlteracao.Text;

                calcular();
                txtAlteracao.Clear();

                MessageBox.Show("Quantidade foi alterada com sucesso");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvItem.RowCount = 0;

            lblTotal.Text = "R$ 0,00";
        }

    }
}
