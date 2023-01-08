using System;

namespace TextEditor;

class Program
{
	static void Main(string[] args)
	{
		Menu();
	}
	
	static void Menu()
	{
		Console.Clear();
		Console.WriteLine("What do you want to do?");
		Console.WriteLine("1 - Open a file.");
		Console.WriteLine("2 - Create a new file.");
		Console.WriteLine("0 - Close program.");
		short option = short.Parse(Console.ReadLine()??"0");
		
		switch(option)
		{
			case 0: Environment.Exit(0); break;
			case 1: Open(); break;
			case 2: Edit(); break;
		}
		
	}
	static void Open()
	{
		Console.Clear();
		Console.WriteLine("What is the path of the file?");
		string path = Console.ReadLine()??"";
		
		if((path != null) && (path != ""))
		{
			try
			{
				using(var file = new StreamReader(path))
				{
					string text = file.ReadToEnd();
					Console.WriteLine(text);
				}	
				Console.WriteLine("");
				Console.ReadLine();
				Menu();				
			}
			catch
			{
				Console.WriteLine("The is not a valid path, please, write a valid path");
				Thread.Sleep(2500);
				Open();
			}
			
		}else
		{
			Console.WriteLine("The is not a valid path, please, write a valid path");
			Thread.Sleep(2500);
			Open();
		}
	}
	
	static void Edit()
	{
		Console.Clear();
		Console.WriteLine("Type your text.");
		Console.WriteLine("Use ESC to exit.");
		Console.WriteLine("[-------------]");
		
		string text = "";
		bool wantTpyig = true;
		do
		{
			text += Console.ReadLine();
			text += Environment.NewLine;
			
			wantTpyig = (Console.ReadKey().Key != ConsoleKey.Escape);
		}while(wantTpyig);
		
		Console.WriteLine("------------");
		Console.WriteLine(text);
		Salvar(text);
	}
	
	static void Salvar(string text)
	{
		Console.Clear();
		Console.WriteLine("What is the path to save the file");
		Console.WriteLine("");
		
		var path = Console.ReadLine();
		
		if((path != null) && (path != ""))
		{
			try
			{
				using(var file = new StreamWriter(path))
				{
					file.Write(text);
				}

				Console.WriteLine("File save sucessfull!");
				Console.ReadLine();
				Menu();	
			}catch
			{
				Console.WriteLine("The is not a valid path, please, write a valid path");
				Thread.Sleep(2500);
				Salvar(text);
			}
		}else
		{
			Console.WriteLine("The is not a valid path, please, write a valid path");
			Thread.Sleep(2500);
			Open();
		}
	}
}