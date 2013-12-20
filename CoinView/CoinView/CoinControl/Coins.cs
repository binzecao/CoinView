using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinView.CoinControl
{
    public static class Coins
    {
        private static IDictionary<string, string[]> coins;

        static Coins()
        {
            coins = new Dictionary<string, string[]>();
            coins.Add(Platform.OKCoin.ToString(), new string[] { "btc_cny", "ltc_cny" });
            coins.Add(Platform.Bter.ToString(), new string[] { "btc_cny", "ltc_cny", "ftc_cny", "frc_cny", "ppc_cny", "trc_cny", "wdc_cny", "yac_cny", "cnc_cny", "bqc_cny", "ifc_cny", "zcc_cny", "cmc_cny", "jry_cny", "xpm_cny", "ppc_cny", "pts_cny", "tag_cny", "tix_cny", "src_cny", "mec_cny", "nmc_cny", "qrk_cny", "btb_cny", "exc_cny", "dtc_cny", "cent_cny", "red_cny", "zet_cny", "ftc_ltc", "frc_ltc", "ppc_ltc", "trc_ltc", "nmc_ltc", "wdc_ltc", "yac_ltc", "cnc_ltc", "bqc_ltc", "ifc_ltc", "red_ltc", "tix_ltc", "cent_ltc", "ltc_btc", "nmc_btc", "ppc_btc", "trc_btc", "frc_btc", "ftc_btc", "bqc_btc", "cnc_btc", "btb_btc", "yac_btc", "wdc_btc", "zcc_btc", "xpm_btc", "zet_btc", "src_btc", "sav_btc", "cdc_btc", "cmc_btc", "jry_btc", "tag_btc", "pts_btc", "dtc_btc", "exc_btc", "nec_btc", "mec_btc", "qrk_btc", "anc_btc", "nvc_btc", "buk_btc", "myminer_btc" });
        }

        public static string[] getCoins(Platform platform)
        {
            return coins[platform.ToString()];
        }

        public static string[] getCoins(string platformName)
        {
            return coins[platformName];
        }

        public static string getCoin(Platform platform, int CoinIndex)
        {
            //try
            //{
            //    return getCoins(platform)[CoinIndex];
            //}
            //catch
            //{
            //    return "";
            //}
            return getCoins(platform)[CoinIndex];
        }

        public static int getCoinIndex(Platform platform, string coinName)
        {
            int index = 0;
            foreach (string name in getCoins(platform))
            {
                if (name.ToLower() == coinName.ToLower()) return index;
                index++;
            }
            return -1;
        }


        public enum Platform
        {
            OKCoin, Bter
        }

        public static string[] getPlatforms()
        {
            return Enum.GetNames(typeof(Platform));
        }

        public static string getPlatform(int platformIndex)
        {
            return getPlatforms()[platformIndex];
        }

        public static int getPlatformIndex(string platformName)
        {
            int index = 0;
            foreach (string name in getPlatforms())
            {
                if (name.ToLower() == platformName.ToLower()) return index;
                index++;
            }
            return -1;
        }

    }
}
