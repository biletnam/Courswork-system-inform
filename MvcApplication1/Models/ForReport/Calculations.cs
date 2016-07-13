using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models.ForReport
{
    public class Calculations
    {
        string[] SeasonEng = new string[]
        {
            "spring",
            "summe", 
            "autumn",
            "winter"
        };

        string[] SeasonRus = new string[]
        {
            "весна",
            "лето", 
            "осень",
            "зима"
        };

        string[] ServiecEng = new string[]
        {
            "spring",
            "summe", 
            "autumn",
            "winter"
        };

        string[] ServiecRus = new string[]
        {
            "Бар",
            "Пляж", 
            "Салон красоты",
            "Дискотеки"
        };


        //Количество
        //Бар
        public int itogiBarCount { get; set; }
        public int LuxBarCount { get; set; }
        public int StandartBarCount { get; set; }
        public int EconomBarCount { get; set; }

        //Пляж
        public int itogiBeachCount { get; set; }
        public int LuxBeachCount { get; set; }
        public int StandartBeachCount { get; set; }
        public int EconomBeachCount { get; set; }

        //Салон красоты
        public int itogiBeautyCount { get; set; }
        public int LuxBeautyCount { get; set; }
        public int StandartBeautyCount { get; set; }
        public int EconomBeautyCount { get; set; }

        //Дискотека
        public int itogiDiscoCount { get; set; }
        public int LuxDiscoCount { get; set; }
        public int StandartDiscoCount { get; set; }
        public int EconomDiscoCount { get; set; }

        //Сумма
        //Бар
        public int itogiBarSum { get; set; }
        public int LuxBarSum { get; set; }
        public int StandartBarSum { get; set; }
        public int EconomBarSum { get; set; }

        //Пляж
        public int itogiBeachSum { get; set; }
        public int LuxBeachSum { get; set; }
        public int StandartBeachSum { get; set; }
        public int EconomBeachSum { get; set; }

        //Салон красоты
        public int itogiBeautySum { get; set; }
        public int LuxBeautySum { get; set; }
        public int StandartBeautySum { get; set; }
        public int EconomBeautySum { get; set; }

        //Дискотека
        public int itogiDiscoSum { get; set; }
        public int LuxDiscoSum { get; set; }
        public int StandartDiscoSum { get; set; }
        public int EconomDiscoSum { get; set; }


        //Итоги по номерам
        public int itogiEconomCount { get; set; }
        public int itogiEconomSum { get; set; }
        public int itogiStandartCount { get; set; }
        public int itogiStandartSum { get; set; }
        public int itogiLuxCount { get; set; }
        public int itogiLuxSum { get; set; }




        //Итоги по услугам
        //Бар
        public int itogiBarLuxCount { get; set; }
        public int itogiBarLuxSum { get; set; }
        public int itogiBarStandartCount { get; set; }
        public int itogiBarStandartSum { get; set; }
        public int itogiBarEconomCount { get; set; }
        public int itogiBarEconomSum { get; set; }

        //Дискотека
        public int itogiDiscoLuxCount { get; set; }
        public int itogiDiscoLuxSum { get; set; }
        public int itogiDiscoStandartCount { get; set; }
        public int itogiDiscoStandartSum { get; set; }
        public int itogiDiscoEconomCount { get; set; }
        public int itogiDiscoEconomSum { get; set; }

        //Салон красоты
        public int itogiBeautyLuxCount { get; set; }
        public int itogiBeautyLuxSum { get; set; }
        public int itogiBeautyStandartCount { get; set; }
        public int itogiBeautyStandartSum { get; set; }
        public int itogiBeautyEconomCount { get; set; }
        public int itogiBeautyEconomSum { get; set; }

        //Пляж
        public int itogiBeachLuxCount { get; set; }
        public int itogiBeachLuxSum { get; set; }
        public int itogiBeachStandartCount { get; set; }
        public int itogiBeachStandartSum { get; set; }
        public int itogiBeachEconomCount { get; set; }
        public int itogiBeachEconomSum { get; set; }
    }
}