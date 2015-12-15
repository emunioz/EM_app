/*
 * Created by SharpDevelop.
 * User: Elias Muñoz
 * Date: 14/12/2015
 * Time: 07:59 p.m.
 * Version: 0.0.061
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EM
{

	class funciones
	{
		public int n;
		
		public funciones(){
			n=0;
		}
		
		public string ntl(int n1, bool esc){
			n=n+1;
			string NTL=" ";
			if(n1>=10){
				NTL="Decimo ";
			}
			n1 = n1%10;
			
			switch (n1) {
					case 1: NTL=NTL+"Primer";break;
					case 2: NTL=NTL+"Segundo";break;
					case 3: NTL=NTL+"Tercero";break;
					case 4: NTL=NTL+"Cuarto";break;
					case 5: NTL=NTL+"Quinto";break;
					case 6: NTL=NTL+"Sexto";break;
					case 7: NTL=NTL+"Septimo";break;
					case 8: NTL=NTL+"Octavo";break;
					case 9: NTL=NTL+"Noveno";break;
					case 0: break;
			}
			if (esc==true){
				Console.Write(NTL);
			}
			return NTL;
		}
		
		
	}
	
	class Persona
	{
		
		public string nombre;
		public string apellido;
		public string carrera;
		public int semestres;
		public int Contraseña;
		
		private funciones fun = new funciones();
		
		public Persona(bool exis){
			if(exis==true){
				Cont();
			}else{
				NueCon();
			}
		}
		
		private int NueCon(){
			FileStream arc = new FileStream("DATA",FileMode.Create);
			BinaryWriter escarc = new BinaryWriter(arc,Encoding.UTF8);
			
			Console.Write("Con nuestra app prodras establecer tu promedio de tu vida universitaria.\nDispondras con muchas funciones que seran de gran ayuda para ti.\n");
			
			Console.ReadKey();
			Console.Write("\nIngrese su informacion basica\nNombre: ");
			string linea = Console.ReadLine();
			escarc.Write(linea);
			
			Console.Write("Apellido: ");
			linea = Console.ReadLine();
			escarc.Write(linea);
			
			Console.Write("Carrera: ");
			linea =Console.ReadLine();
			escarc.Write(linea);
			
			Console.Write("Semestres cursados: ");
			linea =Console.ReadLine();
			int Contra = int.Parse(linea);
			escarc.Write(Contra);
			
			Console.Write("\n\nPor seguridad debe establecer una Contraseña\n");
			bool apta=false;
			Contra=0;
			Console.Write("*****ADVERTENCIA*****\nPara la contraseña debe ser un pin de cuatro digitos sin reperticion\n ");
			while (apta==false){
				Console.Write("\nContraseña: ");
				linea = Console.ReadLine();
				Contra = int.Parse(linea);
				int temp=Contra,n=0;
				int[] Contr = new int[4];
				
				while (temp!=0){
					n=n+1;
					Contr[4-n]=temp%10;
					temp=temp/10;
					
				}
				
				if(n==4){
					apta=true;
					for (int i=0; i<4;i++){
						for(int j=0;j<4;j++){
							if(Contr[i]==Contr[j] & i!=j){
								apta=false;
								break;
							}
						}
					}
				}
				else{
					apta=false;
				}
				
				if(apta==false){
					Console.Write("\n\a*****ERROR*****\nLa contraseña no cumple las condiciones");
				}
			}
			
			escarc.Write(Contra);
			escarc.Close();
			return 0;
		}
		
		private int Cont(){
			FileStream arc = new FileStream("DATA",FileMode.Open);
			BinaryReader escarc = new BinaryReader(arc);
			
			nombre = Convert.ToString (escarc.ReadString());
			apellido = Convert.ToString(escarc.ReadString());
			carrera = Convert.ToString(escarc.ReadString());
			semestres = Convert.ToInt32(escarc.ReadInt32());
			Contraseña = Convert.ToInt32(escarc.ReadUInt32());
			escarc.Close();
			return 0;
		}
		
	}
	
	class Semestre 
	{
		public uint Nsem;
		public string[][] Materias;
		public float[][] notas;
		
		public Semestre(bool exis){
			if(exis ==true){
				
			}else{
			
			}
		}
		
	}
	
	class Program
	{
		private static Persona cliente;
		private static funciones fun =new funciones();
		
		private static int welcome(){
			Console.Write("*******************************************************************************\n");
			Console.Write("*******************************************************************************\n");
			Console.Write("*\t*\t*\t*\t*\t*\t*\t*\t*\t*\n\n");
			Console.Write("\t\t\t\t Bienvenido \t\t\t\t\n\n");
			Console.Write("*\t*\t*\t*\t*\t*\t*\t*\t*\t*\n\n");
			Console.Write("*******************************************************************************\n");
			Console.Write("*******************************************************************************\n\n");
			Console.ReadKey();
			
			return 0;
		}
		
		private static void Programa(bool exis){
			
		}
		
		public static void Main()
		{
			bool exis = File.Exists("DATA");
			if (exis==true){
				cliente = new Persona(exis);
				Programa(exis);
			}else{
				welcome();
				cliente = new Persona(exis);
				Programa(exis);
			}
			Console.ReadKey();
		}
	}
}
