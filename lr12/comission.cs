using System;
namespace lr12
{
	[Serializable]
	public class comission : company
	{
		public comission(string _fullname, string _gender, int _salary, int _percent)
		{
			fullName = _fullname;
			gender = _gender;
			salary = _salary;
			percent = _percent;
		}

		private int work = 0;
		private int percent = 0;
		public override void Work(int sales)
		//Функция добавления продаж
		{
			work += sales;
		}

		public override void CalculateSalary()
		//Функция расчёта зарплаты и обнуления выполненной работы
		{
			wage += GetSalary() + GetSalary() * work * percent / 100;
			work = 0;
		}

		public string GetWork()
		//Функция вовзрата количества продаж
		{
			return "комиссионный, продажи: " + work;
		}
		public void setPercent(int ppercent)
		{
			percent = ppercent;
		}

	}
}

