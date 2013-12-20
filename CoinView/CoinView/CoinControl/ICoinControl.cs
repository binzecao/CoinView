using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinView.CoinControl
{
    public interface ICoinControl
    {
        void setLanguage(int languageIndex);

        void setCurrentCoin(int coinIndex);

        void asyncThreadStart();

        void abortAutoLoadDataThread();
    }
}
