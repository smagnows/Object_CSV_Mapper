// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Collections.Generic;
using System.IO;
class Programe{

	public static void Main(string[] args)
	{
		
		Console.WriteLine("\n\nTest2");
		Console.WriteLine("Hello, World!");
		Kontakt a = new Kontakt("ania","baran","655444555");
		Type naszTyp = a.GetType();
		Console.WriteLine(a.GetType());
		//Console.WriteLine(a.getProperty("imie"));
		Console.WriteLine(naszTyp.Name);
		Console.WriteLine(naszTyp.FullName);
		
		FieldInfo infoOPolu = naszTyp.GetField("imie");
		
		
            if (infoOPolu != null)
            {
                Console.WriteLine($"Public field name: {infoOPolu.Name}");
                // Pobranie wartości pola
                string fieldValue = (string)infoOPolu.GetValue(a);
                Console.WriteLine($"Public field value: {fieldValue}");

                // Ustawienie nowej wartości pola
                infoOPolu.SetValue(a, "imie3");
                Console.WriteLine
                ($"Public field value after change: {a.imie}");
                 // Sprawdzenie, czy się zmieniło
            }
            else
            {
                Console.WriteLine("Public field not found.");
            }
		
		
		Console.WriteLine("");
		//saveasCSV(infoOPolu);
		saveasCSV(a);
		Console.WriteLine("");
		Console.WriteLine("");
		Console.WriteLine("");
		Telefon t = new Telefon();
	}


	public class Kontakt {
		public string imie, nazwisko, nrTel;
		 
		public string getImie() {return imie;}
		public string getNazwisko() {return nazwisko;}
		public string getNrTel() {return nrTel;}
		
		public void setImie(string a) {imie=a;}
		public void setNazwisko(string a) {nazwisko=a;}
		public void setNrTel(string a) {nrTel=a;}
		
		public Kontakt()
		{
			
		}
		public Kontakt (string a, string b, string c)
		{
			setImie(a);
			setNazwisko(b);
			setNrTel(c);
		}
	};

	public class KsiazkaAdr {
		private List<Kontakt> kontakty;
		public KsiazkaAdr()
		{
			kontakty = new List<Kontakt>();
		}
		
		public void dodaj(Kontakt a)
		{
			kontakty.Add(a);
			Console.WriteLine("DodanieKontaktu");
		}
		
	};

	public class Telefon 
	{
		private KsiazkaAdr p = new KsiazkaAdr();
		
		public Telefon()
		{
			Kontakt t = new Kontakt("Seba","Nie seba","4343");
			p.dodaj(t);
		}
		
	};

	public static void saveasCSV<T>(T objekt)
	{
		Console.WriteLine("Zapis się wykonuje. Save As CSV");
		StreamWriter s = new StreamWriter("klasa.csv", false);
		
		Type objectType = objekt.GetType();
		s.WriteLine("0;"+objectType+objectType.Name);
		MemberInfo[] lista = objectType.GetMembers();
		foreach (MemberInfo i in lista)
		{
			
			if (i.MemberType==MemberTypes.Method)
            {
				s.WriteLine($"1;Metoda;{i.Name};{objectType.GetMethod(i.Name).ReturnType}");
				ParameterInfo[] lista2 = objectType.GetMethod(i.Name).GetParameters();
				foreach (ParameterInfo p in lista2)
				{
					s.WriteLine("2;"+"parametr;"+p.ParameterType+";"+p.Name);
				}
            } else {
				
				if (i.MemberType == MemberTypes.Field){
			s.WriteLine($"1;{i.MemberType};{i.Name};{(((FieldInfo)i).GetValue(objekt)==null?null:((FieldInfo)i).GetValue(objekt).ToString())}");
		}
		
		else if (i.MemberType == MemberTypes.Constructor)
		
		{
			
			s.WriteLine($"1;{i.MemberType};{i.Name}");
				
		}
		
		else 
		
		{
			s.WriteLine("Cos innego");
			}
		}
			
			//https://learn.microsoft.com/pl-pl/dotnet/api/system.reflection.memberinfo?view=net-9.0
		}
		s.Close();
		Console.WriteLine("Koniec Save as CSV\n");
	}
	
	
	public static void refleksjeTest<T>(T a)
	{
		
		
	} 
	
};
