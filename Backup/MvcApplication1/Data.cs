using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1
{
    public class Data
    {
        //Бар
        public int Bkv1G;
        public int Bkv2G;
        public int Bkv3G;
        public int Bkv4G;

        public int Bkv1L;
        public int Bkv2L;
        public int Bkv3L;
        public int Bkv4L;

        public int Bkv1S;
        public int Bkv2S;
        public int Bkv3S;
        public int Bkv4S;

        public int Bkv1E;
        public int Bkv2E;
        public int Bkv3E;
        public int Bkv4E;

        //Пляж
        public int Pkv1G;
        public int Pkv2G;
        public int Pkv3G;
        public int Pkv4G;

        public int Pkv1L;
        public int Pkv2L;
        public int Pkv3L;
        public int Pkv4L;

        public int Pkv1S;
        public int Pkv2S;
        public int Pkv3S;
        public int Pkv4S;

        public int Pkv1E;
        public int Pkv2E;
        public int Pkv3E;
        public int Pkv4E;

        //Салон красоты
        public int Skv1G;
        public int Skv2G;
        public int Skv3G;
        public int Skv4G;

        public int Skv1L;
        public int Skv2L;
        public int Skv3L;
        public int Skv4L;

        public int Skv1S;
        public int Skv2S;
        public int Skv3S;
        public int Skv4S;

        public int Skv1E;
        public int Skv2E;
        public int Skv3E;
        public int Skv4E;

        //Дискотеки
        public int Dkv1G;
        public int Dkv2G;
        public int Dkv3G;
        public int Dkv4G;

        public int Dkv1L;
        public int Dkv2L;
        public int Dkv3L;
        public int Dkv4L;

        public int Dkv1S;
        public int Dkv2S;
        public int Dkv3S;
        public int Dkv4S;

        public int Dkv1E;
        public int Dkv2E;
        public int Dkv3E;
        public int Dkv4E;

        public Data(

            int Bkv1G,
            int Bkv2G,
            int Bkv3G,
            int Bkv4G,

            int Bkv1L,
            int Bkv2L,
            int Bkv3L,
            int Bkv4L,

            int Bkv1S,
            int Bkv2S,
            int Bkv3S,
            int Bkv4S,

            int Bkv1E,
            int Bkv2E,
            int Bkv3E,
            int Bkv4E,

            //Пляж
            int Pkv1G,
            int Pkv2G,
            int Pkv3G,
            int Pkv4G,

            int Pkv1L,
            int Pkv2L,
            int Pkv3L,
            int Pkv4L,

            int Pkv1S,
            int Pkv2S,
            int Pkv3S,
            int Pv4S,

            int Pkv1E,
            int Pkv2E,
            int Pkv3E,
            int Pkv4E,

            //Салон красоты
            int Skv1G,
            int Skv2G,
            int Skv3G,
            int Skv4G,

            int Skv1L,
            int Skv2L,
            int Skv3L,
            int Skv4L,

            int Skv1S,
            int Skv2S,
            int Skv3S,
            int Skv4S,

            int Skv1E,
            int Skv2E,
            int Skv3E,
            int Skv4E,

            //Дискотеки
            int Dkv1G,
            int Dkv2G,
            int Dkv3G,
            int Dkv4G,

            int Dkv1L,
            int Dkv2L,
            int Dkv3L,
            int Dkv4L,

            int Dkv1S,
            int Dkv2S,
            int Dkv3S,
            int Dkv4S,

            int Dkv1E,
            int Dkv2E,
            int Dkv3E,
            int Dkv4E

            )
        {
            this.Bkv1G = Bkv1G;
            this.Bkv2G = Bkv2G;
            this.Bkv3G = Bkv3G;
            this.Bkv4G = Bkv4G;

            this.Bkv1L = Bkv1L;
            this.Bkv2L = Bkv2L;
            this.Bkv3L = Bkv3L;
            this.Bkv4L = Bkv4L;

            this.Bkv1S = Bkv1S;
            this.Bkv2S = Bkv2S;
            this.Bkv3S = Bkv3S;
            this.Bkv4S = Bkv4S;

            this.Bkv1E = Bkv1E;
            this.Bkv2E = Bkv2E;
            this.Bkv3E = Bkv3E;
            this.Bkv4E = Bkv4E;

            //Пляж
            this.Pkv1G = Pkv1G;
            this.Pkv2G = Pkv2G;
            this.Pkv3G = Pkv3G;
            this.Pkv4G = Pkv4G;

            this.Pkv1L = Pkv1L;
            this.Pkv2L = Pkv2L;
            this.Pkv3L = Pkv3L;
            this.Pkv4L = Pkv4L;

            this.Pkv1S = Pkv1S;
            this.Pkv2S = Pkv2S;
            this.Pkv3S = Pkv3S;
            this.Pkv4S = Pkv4S;

            this.Pkv1E = Pkv1E;
            this.Pkv2E = Pkv2E;
            this.Pkv3E = Pkv3E;
            this.Pkv4E = Pkv4E;

            //Салон красоты
            this.Skv1G = Skv1G;
            this.Skv2G = Skv2G;
            this.Skv3G = Skv3G;
            this.Skv4G = Skv4G;

            this.Skv1L = Skv1L;
            this.Skv2L = Skv2L;
            this.Skv3L = Skv3L;
            this.Skv4L = Skv4L;

            this.Skv1S = Skv1S;
            this.Skv2S = Skv2S;
            this.Skv3S = Skv3S;
            this.Skv4S = Skv4S;

            this.Skv1E = Skv1E;
            this.Skv2E = Skv2E;
            this.Skv3E = Skv3E;
            this.Skv4E = Skv4E;

            //Дискотеки
            this.Dkv1G = Dkv1G;
            this.Dkv2G = Dkv2G;
            this.Dkv3G = Dkv3G;
            this.Dkv4G = Dkv4G;

            this.Dkv1L = Dkv1L;
            this.Dkv2L = Dkv2L;
            this.Dkv3L = Dkv3L;
            this.Dkv4L = Dkv4L;

            this.Dkv1S = Dkv1S;
            this.Dkv2S = Dkv2S;
            this.Dkv3S = Dkv3S;
            this.Dkv4S = Dkv4S;

            this.Dkv1E = Dkv1E;
            this.Dkv2E = Dkv2E;
            this.Dkv3E = Dkv3E;
            this.Dkv4E = Dkv4E;
        }
    }
}