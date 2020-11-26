using System;
namespace lr12
{

    public class hourly : company
    {
        public hourly(string _fullname, string _gender, int _salary, int _incsalary, int _norm)
        {
            fullName = _fullname;
            gender = _gender;
            salary = _salary;
            incSalary = _incsalary;
            norm = _norm;
        }

        private int hour = 0;
        private int incSalary = 0, norm = 0;

        public override void Work(int hours)
        {
            hour += hours;
        }
        public string GetWork()
        //Функция возврата количества часов
        {
            return "почасовой";
        }

       
        public void setSalary(int ssalary)
        {
            salary = ssalary; //ставка за час
        }

        public void setIncSalary(int iincSalary)
        {
            incSalary = iincSalary; //повышенная ставка за час
        }

        public void setNorm(int nnorm)
        {
            norm = nnorm;
        }

        public override void CalculateSalary()
        {
            wage += (hour <= norm ? hour * GetSalary() : norm * GetSalary() + (hour - norm) * incSalary);
            hour = 0;
        }
    }
}
