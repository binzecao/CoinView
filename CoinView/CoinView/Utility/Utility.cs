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

        public static void passFormState(Form hideForm, Form showForm, int currLanguage, bool isFormMini)
        {
            //默认的属性值为Manual，窗体的初始位置由Location属性确定；
            showForm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            showForm.Location = hideForm.Location;
            currentLanguage = currLanguage;
            Utility.isFormMini = isFormMini;
        }

        public static void MouseDown(object sender, MouseEventArgs e)
        {
            User32.ReleaseCapture();
            User32.SendMessage(((Control)sender).FindForm().Handle, User32.WM_SYSCOMMAND, User32.SC_MOVE + User32.HTCAPTION, 0);
        }

        public static void setDragMoveForm(Control sender)
        {
            sender.MouseDown += MouseDown;
            foreach (Control ctrl in sender.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    ctrl.MouseDown += MouseDown;
                }
            }
        }

        public static void setDragMoveForm(Control sender,params Type[] types)
        {
            sender.MouseDown += MouseDown;
            foreach (Control ctrl in sender.Controls)
            {
                if (types.Contains(ctrl.GetType()))
                {
                    ctrl.MouseDown += MouseDown;
                }
            }
        }
    }
}
