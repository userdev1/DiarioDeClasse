using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiarioDeClasse
{
    class Vars
    {
        public static bool logado = false;

        public static string Cfg = "";

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public static string ip;

        public static List<FontFamily> ff = new List<FontFamily>();

        public static void FontFamily(string aaa, object gr)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();

            Stream fontStream = gr.GetType().Assembly.GetManifestResourceStream(aaa);
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            Byte[] fontData = new Byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            Marshal.Copy(fontData, 0, data, (int)fontStream.Length);
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);
            pfc.AddMemoryFont(data, (int)fontStream.Length);
            fontStream.Close();
            Marshal.FreeCoTaskMem(data);
            FontFamily grr = new FontFamily(pfc.Families.First().Name, pfc);
            ff.Add(grr);
        }


        public static Panel teste;
        public static Form1 af;

        public static void resize(Control grr)
        {
            if (FormWindowState.Minimized != af.WindowState)
            {
                //MessageBox.Show(grr.Name);
                FontStyle estilo = FontStyle.Regular;
                    if (grr.Font.Bold)
                        estilo = FontStyle.Bold;
                    //MessageBox.Show((grr.Height / Convert.ToDouble(grr.Tag)).ToString());
                if (!grr.GetType().ToString().Contains("BunifuFlatButton"))
                    grr.Font = new System.Drawing.Font(grr.Font.FontFamily, Convert.ToInt32(grr.Height / Convert.ToDouble(grr.Tag)), estilo);
                else
                    ((Bunifu.Framework.UI.BunifuFlatButton)grr).TextFont = new System.Drawing.Font(grr.Font.FontFamily, Convert.ToInt32(grr.Height / Convert.ToDouble(grr.Tag)), estilo);
                af.sideBar.Show();
                
            }
        }

        


        public static bool trabRep = false;
        public static bool trabAviso = false;
        public static bool trabLicao = false;

        //Variáveis globais
        public static string ver = "BETA Fechado 0.9";

        public static string perm;
        public static int addSalaSelec(object sender)
        {
            Bunifu.Framework.UI.BunifuDropdown fon = sender as Bunifu.Framework.UI.BunifuDropdown;
            int aaaa = 0;
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                MySqlCommand checardia = new MySqlCommand("SELECT * FROM info_salas WHERE nome_sala = @Sala", CONEXAO);
                try
                {
                    CONEXAO.Open();
                    checardia.Parameters.AddWithValue("@Sala", fon.selectedValue);

                    MySqlDataReader lerDias = checardia.ExecuteReader();
                    while (lerDias.Read())
                    {
                        aaaa = Convert.ToInt32(lerDias["cod_sala"]);
                    }
                    lerDias.Close();
                }
                catch (Exception erro)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
                }
                finally
                {
                    CONEXAO.Close();
                }
            }
            else
            {
                WebClient kj = new WebClient();
                kj.Encoding = System.Text.Encoding.UTF8;
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/add/checarCodTurma.php?sala=" + fon.selectedValue).Trim();
                aaaa = Convert.ToInt32(resultado);
            }
            return aaaa;
        }
        public static string discSelec;


        public static string hora;
        public static string minuto;
        public static string segundo;

        public static string dia;
        public static string mes;
        public static string ano;

        public static string diaSelec;
        public static string diaNome;
        public static string diaNome2;
        public static string mesSelec;
        public static string[] mesSelecArray = new string[35];
        public static string mesSelec2;
        public static string cfgPhp;

        public static string resumo;
        public static string diaRetorno;


        public static Color corFundo = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(174)))), ((int)(((byte)(206)))));
        public static Color corFundoSide = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
        public static Color corFundoHeader = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(202)))), ((int)(((byte)(255)))));
        public static Color corTit = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(103)))), ((int)(((byte)(130)))));
        public static Color corBtn = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
        public static Color corTxt = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
        public static Color corfunbtn = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
        public static Color corfundotxt = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        public static Color corfontetxt = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        public static Color corfontebtn = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
        public static Color corLinha = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(80)))));

        
        public static void checarPermissao()
        {
            if (Properties.Settings.Default.permInt == 0)
                perm = "Aluno";
            if (Properties.Settings.Default.permInt == 1) 
                perm = "Representante";
            if (Properties.Settings.Default.permInt == 2)
                perm = "Professor";
            if (Properties.Settings.Default.permInt == 3)
                perm = "Participante do projeto"; 
        }

        public static void atualizarData()
        {
            hora = DateTime.Now.Hour.ToString("00");
            minuto = DateTime.Now.Minute.ToString("00");
            segundo = DateTime.Now.Second.ToString("00");
            dia = DateTime.Now.Day.ToString("00");
            mes = DateTime.Now.Month.ToString("00");
            ano = DateTime.Now.Year.ToString("0000");
        }


        private static void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (HitTest((PictureBox)sender, e.X, e.Y))
                ((PictureBox)sender).Cursor = Cursors.Hand;
            else
                ((PictureBox)sender).Cursor = Cursors.Default;
        }

        public static bool HitTest(PictureBox control, int x, int y)
        {
            var result = false;
            if (control.Image == null)
                return result;
            var method = typeof(PictureBox).GetMethod("ImageRectangleFromSizeMode",
              System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var r = (Rectangle)method.Invoke(control, new object[] { control.SizeMode });
            using (var bm = new Bitmap(r.Width, r.Height))
            {
                using (var g = Graphics.FromImage(bm))
                    g.DrawImage(control.Image, 0, 0, r.Width, r.Height);
                if (r.Contains(x, y) && bm.GetPixel(x - r.X, y - r.Y).A != 0)
                    result = true;
            }
            return result;
        }

        public static void transpPB(PictureBox controle)
        {
            controle.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
        }




        



        
        

        




    }
}
