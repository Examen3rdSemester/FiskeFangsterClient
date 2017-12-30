using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiskeFangsterClient.Model
{
    class ChangeClassName
    {
        private int id;
        private string changeString;
        private string changeString1;
        private double changeDouble;
        private int changeInteger;

        public string ChangeString { get => changeString; set => changeString = value; }
        public string ChangeString1 { get => changeString1; set => changeString1 = value; }
        public double ChangeDouble { get => changeDouble; set => changeDouble = value; }
        public int ChangeInteger { get => changeInteger; set => changeInteger = value; }
        public int Id { get => id; set => id = value; }

        public ChangeClassName()
        {

        }

        public ChangeClassName(int id, string changeString, string changeString1, double changeDouble, int changeInteger)
        {
            this.id = id;
            this.changeString = changeString;
            this.changeString1 = changeString1;
            this.changeDouble = changeDouble;
            this.changeInteger = changeInteger;

        }

        public override string ToString()
        {
            return $"ID: {Id}, løn: {changeDouble} Arbejdsdage, {changeInteger}";
        }
    }
}
