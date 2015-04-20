using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBImg;

namespace test
{
    public partial class Form1 : Form
    {
        public byte[] myImageData = null;
        public Form1()
        {
            InitializeComponent();
            tbFile.Text = @"C:\Users\v-qixue\Pictures";
        }

        private void tbnSave_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            string filePath = tbFile.Text.Trim();
            if (File.Exists(filePath))
            {
                ImageFile imgFile = new ImageFile();
                myImageData = imgFile.GetPictureData(filePath);
                label1.Text = "Picture Saved!";
            }
            else
            {
                MessageBox.Show("Not valid file!");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            //if (null != myImageData)
            //{
            //    ImageFile imgFile = new ImageFile();
            //    Image img = imgFile.ReturnPhoto(myImageData);
            //    pictureBox1.Image = img;
            //    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                
            //}

            ImageFile imgFile = new ImageFile();
            bool saved = imgFile.SavePhoto(myImageData,@"d:\test.jpg");
            MessageBox.Show(saved.ToString());
        }
    }
}
