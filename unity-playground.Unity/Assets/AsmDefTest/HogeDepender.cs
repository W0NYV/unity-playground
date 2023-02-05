namespace AsmDefTest
{
    public class HogeDepender
    {
        public string HogeHuga()
        {
            Hoge hoge = new Hoge();
            return hoge.HogeHuga();
        }
    }
}