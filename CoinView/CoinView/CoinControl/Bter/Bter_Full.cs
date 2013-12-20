using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinView.CoinControl.Bter
{
    public partial class Bter_Full : UserControl, ICoinControl
    {
        public Bter_Full()
        {
            InitializeComponent();
            Utility.Utility.setDragMoveForm(this, typeof(Label), typeof(GroupBox));
            this.MinimumSize = this.bter_Ticker.MinimumSize;
            this.MaximumSize = this.Size;
        }

        public void asyncThreadStart()
        {
            bter_Depth.asyncThreadStart();
            bter_Ticker.asyncThreadStart();
            bter_Trades.asyncThreadStart();
        }

        public void abortAutoLoadDataThread()
        {
            bter_Depth.abortAutoLoadDataThread();
            bter_Ticker.abortAutoLoadDataThread();
            bter_Trades.abortAutoLoadDataThread();
        }

        public Bter_Ticker getTicker()
        {
            return bter_Ticker;
        }

        public Bter_Depth getDepth()
        {
            return bter_Depth;
        }

        public Bter_Trades getTrades()
        {
            return bter_Trades;
        }

        public void setLanguage(int languageIndex)
        {
            bter_Ticker.setLanguage(languageIndex);
        }

        public void setCurrentCoin(int coinIndex)
        {
            bter_Depth.setCurrentCoin(coinIndex);
            bter_Ticker.setCurrentCoin(coinIndex);
            bter_Trades.setCurrentCoin(coinIndex);
        }
    }
}
