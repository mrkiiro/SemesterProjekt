using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace App8.Model
{
    class ButtonExtension : Button
    {
        public bool istaken;
        public ButtonExtension()
        {
            istaken = false;
        }
    }
}
