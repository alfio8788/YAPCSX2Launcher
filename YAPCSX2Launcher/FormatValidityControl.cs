using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAPCSX2Launcher.Utilities.Formats
{
    class FormatValidityControl
    {
        public bool isValidImage(string file)
        {
            try
            {
                using (Image newImage = Image.FromFile(file))
                { }
            }
            //catch (OutOfMemoryException Ex)
            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);
                return false;
            }
            return true;
        }

        public bool isValidDiskImage(string file)
        {
            //TODO: Implement
            return false;
        }
    }
}
