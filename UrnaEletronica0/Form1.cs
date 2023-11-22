using System.Diagnostics.Eventing.Reader;
using System.Media;

namespace UrnaEletronica0
{
    public partial class frmUrna : Form
    {
        private Dictionary<string, Candidato> _dicCandidato;

        public frmUrna()
        {
            //Candidato a Presidente
            InitializeComponent();
            _dicCandidato = new Dictionary<string, Candidato>();
            _dicCandidato.Add("51", new Candidato() { Id = 51, Nome = "Felipe Xavier", Partido = "FX", Foto = Properties.Resources.candidatoFelipeX });
            _dicCandidato.Add("41", new Candidato() { Id = 41, Nome = "Douglas Gama", Partido = "DG", Foto = Properties.Resources.candidatoDouglas });
            _dicCandidato.Add("16", new Candidato() { Id = 16, Nome = "Matheus Campos", Partido = "MC", Foto = Properties.Resources.candidatoMatheus });
            _dicCandidato.Add("25", new Candidato() { Id = 25, Nome = "Francine Aparecida", Partido = "FA", Foto = Properties.Resources.candidataFrancine });
            _dicCandidato.Add("55", new Candidato() { Id = 55, Nome = "Tamer Conovas", Partido = "TC", Foto = Properties.Resources.candidatoTamer });
            _dicCandidato.Add("10", new Candidato() { Id = 10, Nome = "Felipe Santos", Partido = "FS", Foto = Properties.Resources.candidatoFelipeS });
            _dicCandidato.Add("30", new Candidato() { Id = 30, Nome = "João Sant'Ana", Partido = "JS", Foto = Properties.Resources.candidatoJoao });
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            RegistrarDigito("1");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            RegistrarDigito("2");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            RegistrarDigito("3");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            RegistrarDigito("4");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            RegistrarDigito("5");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            RegistrarDigito("6");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            RegistrarDigito("7");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            RegistrarDigito("8");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            RegistrarDigito("9");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            RegistrarDigito("0");

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btnBranco_Click(object sender, EventArgs e)
        {
            pnFim.Visible = true;
            Limpar();
            SoundPlayer s = new SoundPlayer(Properties.Resources.click_confirmar);
            s.Play();

            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 3000;
            relogio.Enabled = true;
            relogio.Start();

        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            Limpar();
            relogio.Stop();
            relogio.Enabled = false;

            SoundPlayer s = new SoundPlayer(Properties.Resources.click);
            s.Play();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPresidente1.Text))
            {
                MessageBox.Show("Favor informar o candidato.");
                return;
            }

            pnFim.Visible = true;
            Limpar();
            SoundPlayer s = new SoundPlayer(Properties.Resources.click_confirmar);
            s.Play();

            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 3000;
            relogio.Enabled = true;
            relogio.Start();
        }

        private void AcaoFinal(Object myObject, EventArgs myEventArgs)
        {
            relogio.Stop();
            relogio.Enabled = false;
            pnFim.Visible = false;
        }

        private void RegistrarDigito(string digito)
        {
            if (String.IsNullOrEmpty(txtPresidente1.Text))
                txtPresidente1.Text = digito;
            else
            {
                txtPresidente2.Text = digito;
                PreencherCandidato(txtPresidente1.Text, txtPresidente2.Text);
            }

        }

        private void PreencherCandidato(string d1, string d2)
        {
            if (_dicCandidato.ContainsKey(d1 + d2))
            {
                lblNome.Text = _dicCandidato[d1 + d2].Nome;
                lblPartido.Text = _dicCandidato[d1 + d2].Partido;
                picFoto.Image = _dicCandidato[d1 + d2].Foto;
            }
            else
            {
                MessageBox.Show("Candidato não encontrado!");
            }
        }

        private void Limpar()
        {
            txtPresidente1.Text = "";
            txtPresidente2.Text = "";
            lblNome.Text = String.Empty;
            lblPartido.Text = String.Empty;
            picFoto.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Candidatos form2 = new Candidatos();
            form2.Show();

        }
    }

    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Partido { get; set; }
        public Image Foto { get; set; }
    }
}