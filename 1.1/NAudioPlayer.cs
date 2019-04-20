using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio;
using NAudio.Wave;

namespace NAudioPlayer
{
    public class NAudioPlayer
    {
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;

        private bool isPlaying = false;
        /// <summary>
        /// 当前的播放状态
        /// </summary>
        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }
        }

        private string songName = "";
        /// <summary>
        /// 播放文件路径及名称
        /// </summary>
        public string SongName
        {
            get
            {
                return songName;
            }
        }

        private float volume = 0.5f;
        /// <summary>
        /// 播放器声音大小，默认为50%
        /// </summary>
        public float Volume
        {
            get { return volume; }
            set
            {
                if (value >= 0 && value <= 1f)
                {
                    volume = value;
                    if (audioFileReader != null)
                    {
                        audioFileReader.Volume = value;
                    }
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public NAudioPlayer()
        {

        }

        /// <summary>
        /// 初始化播放器,初始化参数为播放文件路径
        /// </summary>
        public void Init(string SongName)
        {
            if (string.IsNullOrEmpty(SongName))
                return;

            if(wavePlayer != null)
            {
                wavePlayer.Dispose();
            }

            wavePlayer = new WaveOut();
            audioFileReader = new AudioFileReader(SongName);
            audioFileReader.Volume = Volume;
            wavePlayer.Init(audioFileReader);
            wavePlayer.PlaybackStopped += WavePlayer_PlaybackStopped;
            wavePlayer.Stop();
        }

        private void WavePlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }

            isPlaying = false;
        }

        /// <summary>
        /// 获取当前播放位置
        /// </summary>
        public TimeSpan CurrentTime
        {
            get
            {
                if (audioFileReader == null)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return audioFileReader.CurrentTime;
                }

            }
            set
            {
                if(TotalTime > value)
                {
                    CurrentTime = value;
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 获取总长度
        /// </summary>
        public TimeSpan TotalTime
        {
            get
            {
                if (audioFileReader == null)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return audioFileReader.TotalTime;
                }
            }
        }

        /// <summary>
        /// 开始播放或者继续播放
        /// </summary>
        public void Play()
        {
            if (isPlaying)
            {
                return;
            }

            if (wavePlayer == null)
            {
                return;
            }

            wavePlayer.Play();
            isPlaying = true;
        }

        //暂停
        public void Pause()
        {
            if (wavePlayer != null)
            {
                wavePlayer.Pause();
                isPlaying = false;
            }
        }
    }
}
