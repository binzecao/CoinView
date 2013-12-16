using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinView.Model
{
    // {"ticker":{"buy":"162.5","high":"184.4","last":"162.5","low":"141.49","sell":"162.2","vol":"6200727.0620006"}}
    class Ticker
    {
        double buy { get; set; }
        double high{ get; set; }
        double last { get; set; }
        double low { get; set; }
        double sell { get; set; }
        double vol { get; set; }
    }
}
