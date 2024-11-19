using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    internal class Person
    {
        private String firstName;
        private String lastName;
        private DateTime birthday;

        public DateTime Birthday
        {
            get => birthday;
            set
            {
                if (DateTime.Today >= value)
                    birthday = value;
                else
                    throw new ArgumentException("День рождения не может быть больше сегодняшнего дня");
            }
        }
        public String FirstName
        {
            get => firstName;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Значение имеет null или пустая строка");

                firstName = value;
            }
        }
        public String LastName
        {
            get => lastName;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Значение имеет null или пустая строка");

                lastName = value;
            }
        }

        public int Years
        {
            get => birthday.Year;
            set
            {
                if (value > DateTime.Now.Year)
                    throw new ArgumentException("Передаваемый год больше года в данный момент");

                int differenceYers = DateTime.Now.Year - value;

                birthday = birthday.AddYears(-differenceYers);
            }
        }

        public Person()
        {
            this.firstName = "имя";
            this.lastName = "фамилия";
            this.birthday = DateTime.Today;
        }

        public Person(String firstName, String lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public override string ToString() => $"Имя: {firstName}; Фамилия: {LastName}; дата рождения: {birthday.ToShortDateString()}";

        public virtual string ToShortString() => $"Имя: {firstName}; Фамилия: {LastName}";
    }
}
