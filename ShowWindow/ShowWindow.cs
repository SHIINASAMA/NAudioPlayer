using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowWindow
{
    public partial class ShowWindow : Form
    {
        NAudioPlayer.NAudioPlayer player;

        public ShowWindow()
        {
            InitializeComponent();

            player = new NAudioPlayer.NAudioPlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            player.Init("アイ.mp3");
            player.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Init("雪が弾けたその場所で.MP3");
            player.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (player.IsPlaying)
                player.Pause();
            else
                player.Play();
        }
    }
}
