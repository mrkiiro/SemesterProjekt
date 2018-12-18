using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

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
