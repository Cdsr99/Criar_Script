using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Criar_Script
{
    public partial class pagina : Form
    {
        string users = System.Environment.GetEnvironmentVariable("USERNAME");

        public pagina()
        {
            InitializeComponent();
            atributos();
            //conta_linha();
            //caça_palavra();
            radioButton1.Checked = true;



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void script()
        {
            String cmd = richTextBox1.Text;
            String name = textBox2.Text;
            String caminho = comboBox1.Text + "\\" + name + ".bat";
            //MessageBox.Show(caminho);

            try
            {
                StreamWriter conteudo = new StreamWriter(caminho);

                conteudo.WriteLine(richTextBox1.Text);
                richTextBox1.AppendText("\n");


                conteudo.Close();
                MessageBox.Show("Seu Script " + name + " foi criado com sucesso");
            }
            catch (Exception)
            {
                MessageBox.Show("Favor informe um caminho válido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
            

           
        }
        public void atributos()
        {

            comboBox1.Items.Add("C:\\");
            comboBox1.Items.Add("C:\\Users\\" + users + "\\Desktop");
            comboBox1.Items.Add("C:\\Users\\" + users + "\\Documentos");
            comboBox1.Items.Add("C:\\Users\\" + users + "\\Pictures");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            condições();

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            try
            {
                ofd.FileName = "";
                ofd.Title = "Selecione o arquivo .bat";
                ofd.Filter = "bat |*.bat";
                ofd.InitialDirectory = "";
                ofd.ShowDialog();
                // richTextBox1.Text = ofd.FileName;

                String content;
                int contline = 0;
                //int texto = Convert.ToInt16( textBox1.Text);
                StreamReader ler = new StreamReader(ofd.FileName);
                while ((content = ler.ReadLine()) != null)
                {
                    contline++;
                }

                label4.Text = Convert.ToString(contline);
                //richTextBox1.Text = ofd.FileName;
            }
            catch (Exception)
            {


            }
            try
            {
                ler();
            }
            catch (Exception)
            {


            }




        }
        public void ler()
        {
            String caminho = ofd.FileName;
            String content;
            String line;
            // String content2;

            int contline = 0;
            try
            {
                StreamReader arq = new StreamReader(caminho);
                //line = content;

                while ((content = arq.ReadLine()) != null)
                {
                    richTextBox1.AppendText(content);
                    richTextBox1.AppendText("\n");
                    contline++;
                    label4.Text = Convert.ToString(contline);

                }


                arq.Close();

            }
            catch (Exception ex)
            {

                // MessageBox.Show("Erro " + ex.ToString()); 
            }


        }
        public void test()
        {
            String cmd = richTextBox1.Text;
            String name = textBox2.Text;

            Process chamar = new Process();
            chamar.StartInfo.FileName = comboBox1.Text + "\\" + name + ".bat";
            chamar.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != null && textBox2.Text != null)
            {
                if (File.Exists(comboBox1.Text + "\\" + textBox2.Text + ".bat"))
                {
                    test();
                }
                else
                {
                    MessageBox.Show("Esse caminho ou arquivo não existe", "Caminho inexistente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Digite o caminho e o nome do arquivo .bat","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            label4.Text = "....";
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void condições()
        {

            if (comboBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Por favor insira o caminho e o nome do arquivo");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Por favor insira o caminho do arquivo");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Por favor insira o nome do arquivo");
            }
            else
            {
                script();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cor();
            }
            else
            {
                normal();
            }


        }
        public void linhas()
        {

            try
            {
                string content;
                int contline = 0;
                //string texto = richTextBox1;
                StreamReader ler = new StreamReader(richTextBox1.Text);
                while ((content = ler.ReadLine()) != null)
                {
                    contline++;
                    label4.Text = Convert.ToString(contline);
                    ler.Close();
                }



            }
            catch (Exception rx)
            {
                MessageBox.Show(rx.ToString());

            }
        }
        public void caça_palavra()
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }


        public void cor()
        {
            String texto = richTextBox1.Text;
            String start = "start";
            String cd = "cd";
            String taskkill = "taskkill";
            String c = "c:\\";
            String d = "d:\\";
            String D = "D:\\";

            if (radioButton1.Checked)
            {

                    if (richTextBox1.Text.Contains(start))
                    {
                        richTextBox1.SelectionColor = Color.Red;
                    }
                     if (richTextBox1.Text.Contains(cd))
                    {
                        richTextBox1.SelectionColor = Color.DarkBlue;
                        //MessageBox.Show("Achei cd");
                    }
                     if (richTextBox1.Text.Contains(c))
                    {
                        richTextBox1.SelectionColor = Color.DarkOrange;
                    }
                     if (richTextBox1.Text.Contains("Cdsr99"))
                    {
                        //MessageBox.Show("Cdsr99 admin", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        pagina.ActiveForm.Text = "Cdsr99 Admin";
                        richTextBox1.ForeColor = Color.LawnGreen;
                        richTextBox1.BackColor = Color.Black;
                    }
                    if (richTextBox1.Text.Contains(taskkill))
                    {
                        richTextBox1.SelectionColor = Color.SeaShell;
                    }
                     if (richTextBox1.Text.Contains(d))
                    {
                        richTextBox1.SelectionColor = Color.Silver;
                    }
                     if (richTextBox1.Text.Contains(D))
                    {
                        richTextBox1.SelectionColor = Color.SkyBlue;
                    }
                
            }
            else
            {
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.BackColor = Color.White;
            }
        }
            
        
        public void normal()
        {
            richTextBox1.Select();
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.BackColor = Color.White;

        }

        private void modoProgramadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                MessageBox.Show("Por favor selecione a opção cor", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                richTextBox1.Select();
                richTextBox1.ForeColor = Color.White;
                richTextBox1.BackColor = Color.Black;
            }
       }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
        }
        public void Addcomandos()
        {



            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("===========================**COMANDOS**=============================");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("Para obter mais informações sobre um comando específico,\n");
            richTextBox1.AppendText("digite HELP nome_do_comando\n");
            richTextBox1.AppendText("ASSOC          Exibe ou modifica associações de extensões de arquivo.\n");
            richTextBox1.AppendText("ATTRIB         Exibe ou altera atributos de arquivos.\n");
            richTextBox1.AppendText("BREAK          Define ou limpa a verificação estendida CTRL+C.\n");
            richTextBox1.AppendText("BCDEDIT        Define propriedades no banco de dados de inicialização para\n");
            richTextBox1.AppendText("               controlar o carregamento da inicialização.\n");
            richTextBox1.AppendText("CACLS          Exibe ou modifica listas de controle de acesso de arquivos.\n");
            richTextBox1.AppendText("CALL           Chama um programa em lotes por meio de outro.\n");
            richTextBox1.AppendText("CD             Exibe o nome do diretório atual ou faz alterações nele.\n");
            richTextBox1.AppendText("CHDIR          Exibe o nome do diretório atual ou faz alterações nele.\n");
            richTextBox1.AppendText("CHKDSK         Verifica um disco e exibe um relatório de status.\n");
            richTextBox1.AppendText("CHKNTFS        Exibe ou modifica a verificação do disco na inicialização.\n");
            richTextBox1.AppendText("CLS            Limpa a tela.\n");
            richTextBox1.AppendText("CMD            Inicia uma nova instância do interpretador de comandos do\n");
            richTextBox1.AppendText("               Windows.\n");
            richTextBox1.AppendText("COLOR          Define as cores padrão do primeiro plano e do plano de fundo\n");
            richTextBox1.AppendText("               do console.\n");
            richTextBox1.AppendText("COMP           Compara o conteúdo de dois arquivos ou grupos de arquivos.\n");
            richTextBox1.AppendText("COMPACT        Exibe ou altera a compactação de arquivos em partições NTFS.\n");
            richTextBox1.AppendText("CONVERT        Converte volumes FAT em NTFS. Não é possível converter a\n");
            /*richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");
            richTextBox1.AppendText("");*/

        }
        public void comandos()
        {
            
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Addcomandos();
        }
    }
}
