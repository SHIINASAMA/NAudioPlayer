#NAudioPlayer
##1.About this class.
First，You will need NAudio lib.  
<b><a href = "https://github.com/naudio/NAudio">Naudio in the github</a></b>  
And import <kbd>NAudio.dll</kbd>.

##2.Play a attention to this!
The namespace is not <kbd>NAduio</kbd> !!!  
Is <kbd>NAudioPlayer</kbd>!!!  
The class name is <kbd>NAudioPlayer</kbd> ,too!

##3.A simple example！
				public void Func(string path){
					NAudioPlayer.NAudioPlayer player = new NAudioPlayer.NAudioPlayer();
					player.Init(path);
					
					//NAudioPlayer will play.
					player.Play();
					
					//NAudioPlayer will pause.
					player.Pause();

					//NAudioPlayer will Resume play.
					player.Play();
				}

##4.You can refer to here.
>NAudioPlayer  
>>bool IsPlaying;  
>>string SongName;  
>>System.Timespan TotalTime;  
>>System.Timespan CurrentTime;  
>>float Volume;  
>>  
>>NAudioPlayer();  
>>Init(string);  
>>Play();  
>>Pause();  

##5.Last
#Thank you for your reading!
#I know my En is so poor!