namespace AsmDefTest
{
    
    public class Hoge
    {
        public string HogeHoge()
        {
            return "HogeHoge";
        }

        public string HogeHuga()
        {
            Huga huga = new Huga();
            return "HogeHoge" + huga.HugaHuga();
        }
    }

}