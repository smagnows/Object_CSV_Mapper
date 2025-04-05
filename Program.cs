// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Collections.Generic;
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
                infoOPolu.SetValue(a, "imionko");
                Console.WriteLine
                ($"Public field value after change: {a.imie}");
                 // Sprawdzenie, czy się zmieniło
            }
            else
            {
                Console.WriteLine("Public field not found.");
            }
		
		
		Console.WriteLine("");
		saveasCSV(infoOPolu);
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
		Type objectType = objekt.GetType();
		Console.WriteLine(objectType);
		Console.WriteLine(objectType.Name);
		Console.WriteLine(objectType.FullName);
		MemberInfo[] lista = objectType.GetMembers();
		//Console.WriteLine(lista);
		foreach (MemberInfo i in lista)
		{
			//Console.WriteLine
			Console.WriteLine($"Nazwa\t{i.Name}");
			Console.WriteLine($"Typ\t{i.MemberType}");
			
			if (i.MemberType==MemberTypes.Method)
                    {
                        foreach ( ParameterInfo pi in ((MethodInfo) i).GetParameters() )
                        {
                           Console.WriteLine($"Parameter: Type={pi.ParameterType}, Name={pi.Name}");
                        }
                    }
			//https://learn.microsoft.com/pl-pl/dotnet/api/system.reflection.memberinfo?view=net-9.0
		}
		
		Console.WriteLine("Koniec Save as CSV\n");
	}
	
};
