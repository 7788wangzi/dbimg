using System;
using System.IO;
using System.Drawing;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace DBImg
{
    public class ImageFile
    {
        public byte[] GetPictureData(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            byte[] byteData = null;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                byteData = new byte[fs.Length];
                fs.Read(byteData, 0, byteData.Length);
                fs.Close();
            }
            return byteData;
        }

        private Image ReturnPhoto(byte[] streamByte)
        {
            MemoryStream ms = new MemoryStream(streamByte);
            Image img = Image.FromStream(ms);
            
            return img;
        }

        public bool SavePhoto(byte[] streamByte, string outputFile)
        {
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            bool saveCmplete = false;
            using (FileStream fs = new FileStream(outputFile, FileMode.CreateNew))
            {
                fs.Write(streamByte, 0, streamByte.Length);
                fs.Close();
                saveCmplete = true;
            }

            return saveCmplete;
        }
    }
}
