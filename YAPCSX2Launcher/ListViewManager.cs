using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace YAPCSX2Launcher.Utilities.MainManager
{
    class ListViewManager
    {
        public Dictionary<int,Image> getImageList()
        {
            Dictionary<int, Image> imageList = new Dictionary<int, Image>();
            imageList.Add(0, this.getStarImage(0));
            imageList.Add(1, this.getStarImage(1));
            imageList.Add(2, this.getStarImage(2));
            imageList.Add(3, this.getStarImage(3));
            imageList.Add(4, this.getStarImage(4));
            imageList.Add(5, this.getStarImage(5));

            return imageList;
        }

        private Image getStarImage(int index)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("YAPCSX2Launcher.Resources." + index + "s.png");
            Image image = System.Drawing.Image.FromStream(stream);
            //Bitmap fImage = new Bitmap(image, new Size(w,h));
            return image;
        }
    }
}