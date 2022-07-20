using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCKimlikNoUretmeVeDogrulama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //11 haneli olcak
            //ilk hane 0 olamaz
            //her hane rakamsal değer içerir
            //1.,3.,5.,7.,9. hanelerin toplamının 7 katından 2.,4.,6.,8. hanelerin toplamını çıkarttığınızda elde edilen sonucun 10a bölümünden kalan 10. haneyi verir.
            //1,2,3,4,5,6,7,8,9,10. henelerin toplamının mod 10'u 11. haneyi verir.

            //TcKimlikKontrol method yazınız. Kendi tc'niz ile kontrol ediniz.
            Console.WriteLine("TC Kimlik numaranızı giriniz...");
            string girilenTC = Console.ReadLine();
            bool TCMi=TCKNODogrula(girilenTC);
            Console.WriteLine(TCMi);

            string tc = TCKNOUret();
            Console.WriteLine("Üretilen TC:"+tc);
            Console.WriteLine(TCKNODogrula(tc));

            


            Console.ReadKey();
        }
        static bool TCKNODogrula(string tc)
        {
            if (tc.Length != 11 || tc[0]=='0')
            {
                return false;
            }
            try
            {
                long rakamlar = Convert.ToInt64(tc);
            }
            catch(Exception)
            {
                return false;
            }
            int tekToplam = 0;
            int ciftToplam=0;
            for (int i = 0; i < 10; i+=2)
            {
                tekToplam += Convert.ToInt32(tc[i].ToString());
            }
            for (int i = 1; i < 9; i+=2)
            {
                ciftToplam+= Convert.ToInt32(tc[i].ToString());
            }
            if ((tekToplam * 7 - ciftToplam) % 10 != Convert.ToInt32(tc[9].ToString()))
            {
                return false;
            }
            int onHane = tekToplam+ciftToplam+ Convert.ToInt32(tc[9].ToString());
            if (onHane%10!= Convert.ToInt32(tc[10].ToString()))
            {
                return true;
            }

            return true;
        }
        static string TCKNOUret()
        {
            string tc = "";
            Random rnd = new Random();
            tc += rnd.Next(1, 10);
            for (int i = 0; i < 8; i++)
            {
                tc += rnd.Next(10);
            }
            int tekToplam = Convert.ToInt32(tc[0].ToString())+ Convert.ToInt32(tc[2].ToString()) + Convert.ToInt32(tc[4].ToString()) + Convert.ToInt32(tc[6].ToString()) + Convert.ToInt32(tc[8].ToString());
            int ciftToplam = Convert.ToInt32(tc[1].ToString())+ Convert.ToInt32(tc[3].ToString()) + Convert.ToInt32(tc[5].ToString()) + Convert.ToInt32(tc[7].ToString());

            int haneOn = ((tekToplam * 7) - ciftToplam) % 10;
            int onHaneToplam = tekToplam + ciftToplam + haneOn;
            int haneOnBir = onHaneToplam % 10;

            tc += haneOn.ToString();
            tc += haneOnBir.ToString();

            return tc;

        }
    }
}
