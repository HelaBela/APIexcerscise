using System;

namespace APIwithoutMVC
{
    public class Person
    {
        private string Name { get; set; }
        public DateTime Today { get; set; }

        public Person GetPersonDetails()
        {
            var me = new Person() {Name = "Helena", Today = DateTime.Now};

            return me;
        }

        public String ConvertToString()
        {
            return $"Name: {Name}, Time: {Today.ToString()}";
        }
    }
}