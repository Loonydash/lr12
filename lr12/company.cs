using System;
using lr12;
using System.Numerics;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Runtime.Serialization.Formatters.Binary;

namespace lr12
{
	[Serializable]
	public class company
	{
		public  string fullName = "", gender="";
		public  int salary=0;
		public  int wage = 0;
		public virtual void CalculateSalary() { } //Виртуальная функция расчета полной зарплаты
		public virtual void Work(int work) { }//Виртуальная функция добавления работ
											  //public virtual string GetWork() {return } //Виртуальная функция получения количества выполненной работ
		public company()
		{
			fullName = ""; gender = ""; salary = 0;
		}




		public string GetName() //Функция возврата ФИО
		{
			return fullName;
		}

		public string GetGender() //Функция возврата пола
		{
			return gender;
		}

		public int GetSalary() //Функция возврата зарплаты
		{
			return salary;
		}

		public int GetWage() //Функция возврата общей зарплаты
		{
			return wage;
		}

		public void setName(string Nname)
		{
			fullName = Nname;
		}

		public void setGender(string ggender)
		{
			gender = ggender;
		}

		
	}
}
