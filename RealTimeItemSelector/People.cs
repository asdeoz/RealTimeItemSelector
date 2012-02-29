using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealTimeItemSelector
{
    public class People
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Fullname
        {
            get { return (Name + " " + Lastname); }
        }

        public People()
        {
        }

        public People(int id, string name, string lastname)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
        }

        public override string ToString()
        {
            return this.Fullname;
        }

    }

    public static class PeopleHelper
    {
        public static List<People> CreatePeople()
        {
            List<People> list = new List<People>();

            list.Add(new People(1, "Michael", "Jordan"));
            list.Add(new People(2, "Steven", "Spielberg"));
            list.Add(new People(3, "Michael", "Jackson"));
            list.Add(new People(4, "Janet", "Jackson"));
            list.Add(new People(5, "Stephen", "Hawking"));
            list.Add(new People(6, "Steve", "Jobs"));
            list.Add(new People(7, "Stephenie", "Meyer"));
            list.Add(new People(8, "Emma", "Stone"));
            list.Add(new People(9, "Daniel", "Radcliffe"));
            list.Add(new People(10, "Emma", "Watson"));

            return list;
        }
    }

}
