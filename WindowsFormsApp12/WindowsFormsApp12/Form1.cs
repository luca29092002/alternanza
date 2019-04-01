using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.IO;
using System.Speech.Synthesis;
using System.Threading;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine sentitizzatore = new SpeechRecognitionEngine();
        SpeechSynthesizer jarvis = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
            sentitizzatore.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Sentitizzatore_SpeechRecognized);
            LoadGrammar();
            sentitizzatore.SetInputToDefaultAudioDevice();
            sentitizzatore.RecognizeAsync(RecognizeMode.Multiple);
        }
        public void LoadGrammar()
        {

            Choices testo = new Choices();
            string[] linea = File.ReadAllLines(Environment.CurrentDirectory + "//comandi.txt");
            testo.Add(linea);
            Grammar newlista = new Grammar(new GrammarBuilder(testo));
            sentitizzatore.LoadGrammar(newlista);

        }
        public void Sentitizzatore_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox1.Text = e.Result.Text;
            string parola = e.Result.Text;
            if (parola == "ciao")
            {
                jarvis.Speak("ciao come va");
            }
            if (parola == "e tu")
            {
                jarvis.Speak("bene grazie");
            }
            if (parola == "ciao")
            {
                jarvis.Speak("ciao, coma va");
            }
            if (parola == "apri google")
            {
                jarvis.Speak("losto aprendo");
                System.Diagnostics.Process.Start("http://www.google.com");
            }
        }
    }
}
