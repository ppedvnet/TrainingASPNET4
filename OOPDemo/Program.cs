using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayern
{
    internal abstract class Staat
    {
        public abstract void SteuernZahlen();
    }
}

namespace OOPDemo
{

    class EULand : Bayern.Staat
    {
        public override void SteuernZahlen()
        {
            Console.WriteLine("1Eur");
        }
    }

    interface IBundesland
    {
        void FaschingFeiern();
    }

    class Deutschland : EULand, IBundesland
    {
        public string TestPublic = "16 Bundesländer";
        protected string TestProtected = "Bier";
        private string TestPrivate = "Nürnberger";

        public void FaschingFeiern()
        {
            throw new NotImplementedException();
        }
    }

    class Bundesland : Deutschland
    {
        public void GetTestProtected() {
            Console.WriteLine(TestProtected);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var d = new Deutschland();
            var b = new Bundesland();
            
        }
    }
}
