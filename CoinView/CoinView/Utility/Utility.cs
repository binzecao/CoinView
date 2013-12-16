using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinView.Utility
{
    class Utility
    {
        public static string[] platforms = new string[] { "OKCoin", "Bter" };

        public static bool isFormMini = false;
        public static bool isTopMost = true;
        public static int currentLanguage = 1;

        public static void passFormState(Form hideForm, Form showForm,int currLanguage,bool isFormMini)
        {
            //默认的属性值为Manual，窗体的初始位置由Location属性确定；
            showForm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            showForm.Location = hideForm.Location;
            currentLanguage = currLanguage;
            Utility.isFormMini = isFormMini;
        }

         
    }
}
