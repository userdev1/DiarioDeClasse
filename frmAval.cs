using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiarioDeClasse
{
    public partial class frmAval : Form
    {
        public frmAval()
        {
            InitializeComponent();
        }

        private void frmAval_Load(object sender, EventArgs e)
        {
            btn1.Hide();
            btn1.Show();
            btn2.Hide();
            btn2.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://user404.000webhostapp.com/UserDev/paginas/feedback.php");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
            MySqlCommand enviarAval = new MySqlCommand("UPDATE login SET aval_login = @Aval WHERE nome_login = @Nome AND usuario_login = @User", CONEXAO);
            enviarAval.Parameters.AddWithValue("@Aval", bunifuRating1.Value);
            enviarAval.Parameters.AddWithValue("@Nome", Properties.Settings.Default.nome);
            enviarAval.Parameters.AddWithValue("@User", Properties.Settings.Default.usuario);
            try
            {
                CONEXAO.Open();
                enviarAval.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
            }
            finally
            {
                CONEXAO.Close();
                this.Close();
            }

        }
    }
}
