using System.Drawing;
using System.IO;
using System;

namespace do_while_prompt
{
    public class logo
    {
        public logo()
        {
        
            // Get full path
            string path_project = AppDomain.CurrentDomain.BaseDirectory;
            // Replace the bin//debug
            string new_path_project = path_project.Replace("bin\\Debug\\", "");
            // Combining the full project path and the image with the format 
            string full_path = Path.Combine(new_path_project, "logolll.jpeg");
            // Working on the logo using ASCII
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(100, 40));

            // Nested loop 
            for (int height = 0; height < image.Height; height++)
            {
                // Working on width 
                for (int width = 0; width < image.Width; width++)
                {
                    // Working on ASCII design 
                    Color pixelColor = image.GetPixel(width, height);
                    int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    // Using Char
                    char ascii_design = color > 200 ? '#' : color > 150 ? '+' : color > 100 ? '.' : color > 50 ? '-' : ':';
                    Console.Write(ascii_design);
                } // End of inner loop 
                Console.WriteLine();
            } // End of outer loop

        }//end of constructor
    }//end of class
}//end of namespace