using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiarioDeClasse
{
    public partial class selecMes : UserControl
    {
        public selecMes()
        {
            InitializeComponent();
            Vars.atualizarData();
            var ccolor = Color.Red;

            if (Vars.mes == "01") { btnJaneiro.IdleForecolor = ccolor; btnJaneiro.Focus(); }
            if (Vars.mes == "02") { btnFevereiro.IdleForecolor = ccolor; btnFevereiro.Focus(); }
            if (Vars.mes == "03") { btnMarco.IdleForecolor = ccolor; btnMarco.Focus(); }
            if (Vars.mes == "04") { btnAbril.IdleForecolor = ccolor; btnAbril.Focus(); }
            if (Vars.mes == "05") { btnMaio.IdleForecolor = ccolor; btnMaio.Focus(); }
            if (Vars.mes == "06") { btnJunho.IdleForecolor = ccolor; btnJunho.Focus(); }
            if (Vars.mes == "07") { btnJulho.IdleForecolor = ccolor; btnJulho.Focus(); }
            if (Vars.mes == "08") { btnAgosto.IdleForecolor = ccolor; btnAgosto.Focus(); }
            if (Vars.mes == "09") { btnSetembro.IdleForecolor = ccolor; btnSetembro.Focus(); }
            if (Vars.mes == "10") { btnOutubro.IdleForecolor = ccolor; btnOutubro.Focus(); }
            if (Vars.mes == "11") { btnNovembro.IdleForecolor = ccolor; btnNovembro.Focus(); }
            if (Vars.mes == "12") { btnDezembro.IdleForecolor = ccolor; btnDezembro.Focus(); }

            foreach (Control aa in tableLayoutPanel1.Controls)
            {
                aa.Tag = aa.Height / aa.Font.Size;
            }
        }



        private void mes_Click(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuThinButton2 clickedButton = sender as Bunifu.Framework.UI.BunifuThinButton2;
            string fon = Vars.mesSelec2;
            if (clickedButton.ButtonText == "Janeiro")
            {
                Vars.mesSelec = "1";
                Vars.mesSelec2 = "Janeiro";
                Vars.mesSelecArray = new string[] {"01", "02", "03", "04", "05", "06", "07",
                                      "08", "09", "10", "11", "12", "13", "14",
                                      "15", "16", "17", "18", "19", "20", "21",
                                      "22", "23", "24", "25", "26", "27", "28",
                                      "29", "30", "31", "", "", "", ""};
            }
            if (clickedButton.ButtonText == "Fevereiro")
            {
                Vars.mesSelec = "2";
                Vars.mesSelec2 = "Fevereiro";
                Vars.mesSelecArray = new string[] {"", "", "", "01", "02", "03", "04",
                                      "05", "06", "07", "08", "09", "10", "11",
                                      "12", "13", "14", "15", "16", "17", "18",
                                      "19", "20", "21", "22", "23", "24", "25",
                                      "26", "27", "28", "", "", "", ""};
            }
            if (clickedButton.ButtonText == "Março")
            {
                Vars.mesSelec = "3";
                Vars.mesSelec2 = "Março";
                Vars.mesSelecArray = new string[] {"", "", "", "01", "02", "03", "04",
                                      "05", "06", "07", "08", "09", "10", "11",
                                      "12", "13", "14", "15", "16", "17", "18",
                                      "19", "20", "21", "22", "23", "24", "25",
                                      "26", "27", "28", "29", "30", "31", ""};
            }
            if (clickedButton.ButtonText == "Abril")
            {
                Vars.mesSelec = "4";
                Vars.mesSelec2 = "Abril";
                Vars.mesSelecArray = new string[] {"30", "", "", "", "", "", "01",
                                      "02", "03", "04", "05", "06", "07", "08",
                                      "09", "10", "11", "12", "13", "14", "15",
                                      "16", "17", "18", "19", "20", "21", "22",
                                      "23", "24", "25", "26", "27", "28", "29",};
            }

            if (clickedButton.ButtonText == "Maio")
            {
                Vars.mesSelec = "5";
                Vars.mesSelec2 = "Maio";
                Vars.mesSelecArray = new string[] {"", "01", "02", "03", "04", "05", "06",
                                      "07", "08", "09", "10", "11", "12", "13",
                                      "14", "15", "16", "17", "18", "19", "20",
                                      "21", "22", "23", "24", "25", "26", "27",
                                      "28", "29", "30", "31", "", "", ""};
            }
            if (clickedButton.ButtonText == "Junho")
            {
                Vars.mesSelec = "6";
                Vars.mesSelec2 = "Junho";
                Vars.mesSelecArray = new string[] {"", "", "", "", "01", "02", "03",
                                      "04", "05", "06", "07", "08", "09", "10",
                                      "11", "12", "13", "14", "15", "16", "17",
                                      "18", "19", "20", "21", "22", "23", "24",
                                      "25", "26", "27", "28", "29", "30", ""};
            }
            if (clickedButton.ButtonText == "Julho")
            {
                Vars.mesSelec = "7";
                Vars.mesSelec2 = "Julho";
                Vars.mesSelecArray = new string[] {"30", "31", "", "", "", "", "01",
                                      "02", "03", "04", "05", "06", "07", "08",
                                      "09", "10", "11", "12", "13", "14", "15",
                                      "16", "17", "18", "19", "20", "21", "22",
                                      "23", "24", "25", "26", "27", "28", "29",};
            }
            if (clickedButton.ButtonText == "Agosto")
            {
                Vars.mesSelec = "8";
                Vars.mesSelec2 = "Agosto";
                Vars.mesSelecArray = new string[] {"", "", "01", "02", "03", "04", "05",
                                      "06", "07", "08", "09", "10", "11", "12",
                                      "13", "14", "15", "16", "17", "18", "19",
                                      "20", "21", "22", "23", "24", "25", "26",
                                      "27", "28", "29", "30", "31", "", ""};
            }

            if (clickedButton.ButtonText == "Setembro")
            {
                Vars.mesSelec = "9";
                Vars.mesSelec2 = "Setembro";
                Vars.mesSelecArray = new string[] {"", "", "", "", "", "01", "02",
                                      "03", "04", "05", "06", "07", "08", "09",
                                      "10", "11", "12", "13", "14", "15", "16",
                                      "17", "18", "19", "20", "21", "22", "23",
                                      "24", "25", "26", "27", "28", "29", "30"};
            }

            if (clickedButton.ButtonText == "Outubro")
            {
                Vars.mesSelec = "10";
                Vars.mesSelec2 = "Outubro";
                Vars.mesSelecArray = new string[] {"01", "02", "03", "04", "05", "06", "07",
                                      "08", "09", "10", "11", "12", "13", "14",
                                      "15", "16", "17", "18", "19", "20", "21",
                                      "22", "23", "24", "25", "26", "27", "28",
                                      "29", "30", "31", "", "", "", ""};
            }

            if (clickedButton.ButtonText == "Novembro")
            {
                Vars.mesSelec = "11";
                Vars.mesSelec2 = "Novembro";
                Vars.mesSelecArray = new string[] {"", "", "", "01", "02", "03", "04",
                                      "05", "06", "07", "08", "09", "10", "11",
                                      "12", "13", "14", "15", "16", "17", "18",
                                      "19", "20", "21", "22", "23", "24", "25",
                                      "26", "27", "28", "29", "30", "", ""};
            }
            if (clickedButton.ButtonText == "Dezembro")
            {
                Vars.mesSelec = "12";
                Vars.mesSelec2 = "Dezembro";
                Vars.mesSelecArray = new string[35] {"31", "", "", "", "", "01", "02",
                                      "03", "04", "05", "06", "07", "08", "09",
                                      "10", "11", "12", "13", "14", "15", "16",
                                      "17", "18", "19", "20", "21", "22", "23",
                                      "24", "25", "26", "27", "28", "29", "30",};
                
            }
            Vars.teste.Controls.Clear();
            if (Vars.af.calendario == null || fon != Vars.mesSelec2)
                Vars.af.calendario = new Calendario(Vars.mesSelec2) { Dock = DockStyle.Fill };
            Vars.teste.Controls.Add(Vars.af.calendario);
        }

        private void selecMes_VisibleChanged(object sender, EventArgs e)
        {
            foreach (Control aa in tableLayoutPanel1.Controls)
            {
                if (aa is Bunifu.Framework.UI.BunifuThinButton2)
                {
                    var aaa = (Bunifu.Framework.UI.BunifuThinButton2)aa;
                    if (aaa.ButtonText == "" || aaa.ButtonText == "ThinButton")
                        aaa.Visible = false;
                    else
                        aaa.Show();
                    aaa.Refresh();
                }
            }
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control aa in tableLayoutPanel1.Controls)
            {
                Vars.resize(aa);
            }
        }
    }
}
