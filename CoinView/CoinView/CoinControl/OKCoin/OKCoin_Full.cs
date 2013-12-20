using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinView.CoinControl.OKCoin
{
    public partial class OKCoin_Full : UserControl, ICoinControl
    {
        public OKCoin_Full()
        {
            InitializeComponent();
            Utility.Utility.setDragMoveForm(this, typeof(Label), typeof(GroupBox));
            this.MinimumSize = this.okCoin_Ticker.MinimumSize;
            this.MaximumSize = this.Size;
        }

        public void asyncThreadStart()
        {
            okCoin_Depth.asyncThreadStart();
            okCoin_Ticker.asyncThreadStart();
            okCoin_Trades.asyncThreadStart();
        }

        public void abortAutoLoadDataThread()
        {
            okCoin_Depth.abortAutoLoadDataThread();
            okCoin_Ticker.abortAutoLoadDataThread();
            okCoin_Trades.abortAutoLoadDataThread();
        }

        public OKCoin_Ticker getTicker()
        {
            return okCoin_Ticker;
        }

        public OKCoin_Depth getDepth()
        {
            return okCoin_Depth;
        }

        public OKCoin_Trades getTrades()
        {
            return okCoin_Trades;
        }

        public void setLanguage(int languageIndex)
        {
            okCoin_Ticker.setLanguage(languageIndex);
        }

        public void setCurrentCoin(int coinIndex)
        {
            okCoin_Depth.setCurrentCoin(coinIndex);
            okCoin_Ticker.setCurrentCoin(coinIndex);
            okCoin_Trades.setCurrentCoin(coinIndex);
        }

    }
}
