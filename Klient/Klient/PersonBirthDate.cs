using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klient
{
    class PersonBirthDate
    {
        private int day;
        private int year;
        private int month;

        public PersonBirthDate (int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int Day
        {
            get { return day; }
            set
            {
                day = value;
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
            }
        }
        public int Month
        {
            get { return month; }
            set
            {
                month = value;
            }
        }
    }
}
