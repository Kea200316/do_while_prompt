using System.Drawing;
using System.IO;
using System;
using Microsoft.SqlServer.Server;
using System.Drawing.Imaging;
using System.Media;

namespace do_while_prompt
{
    public class audio
    {
        public audio()
        {
            // Get full path
            string path_project = AppDomain.CurrentDomain.BaseDirectory;
            // Replace the bin//debug to get audio
            string updated_audio = path_project.Replace("bin\\Debug\\", "");
            // Combining the full project path and the audio wav with the format 
            string audio_message = Path.Combine(updated_audio, "voice_greeting.wav");
            welcome_audio(audio_message); 
        }
        //end of constructor
        //creating amethod for the welcome audio message
        private void welcome_audio(string audio_message)
        {
            //implenement try and catch 
            try
            {
                //play audio 
                using (SoundPlayer audio_play=new SoundPlayer(audio_message))
                {
                    audio_play.Play();
                }
            }catch (Exception error) {
                Console.WriteLine(error.Message);
        }

        }//end of constructor
    }//end of class
}//end of namespace
