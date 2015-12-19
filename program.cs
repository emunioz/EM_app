/*
 * Created by SharpDevelop.
 * User: Elias Muñoz
 * Date: 14/12/2015
 * Time: 07:59 p.m.
 * Version: 0.0.700
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
		public DateTime dre = DateTime.Now;
		private static FileStream reg = new FileStream("REG.txt",FileMode.Append);
		public StreamWriter ere = new StreamWriter(reg);
		
		
		public funciones(){
			ere.Write(dre + ": Inicio Funciones \n ");
		}
		
		public string ntl(int n1, bool esc){
			
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
			ere.Write(dre + ": se ejecuto ntl \n");
			return NTL;
		}
		
		public int Contras(){
			int Contra=0;
		bool apta=false;
		string linea;
		Console.Write("\v*****ADVERTENCIA*****\nPara la contraseña debe ser un pin de cuatro digitos sin reperticion\n ");
		while (apta==false){
				Console.Write("\vContraseña: ");
				linea = Console.ReadLine();
				Contra = int.Parse(linea);
				int temp=Contra,n1=0;
				int[] Contr = new int[4];
				Console.Write("\nVerificar Contraseña: ");
				linea = Console.ReadLine();
				int Vcon= int.Parse(linea);
				
				while (temp!=0){
					n1=n1+1;
					Contr[4-n1]=temp%10;
					temp=temp/10;
					
				}
				
				if(n1==4){
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
				
				if(Vcon!=Contra){
					apta=false;
				}
				if(apta==false){
					Console.Write("\n\a*****ERROR*****\nLa contraseña no cumple las condiciones");
				}
			}
		ere.Write(dre + ": se ejecuto Contras \n");
		return Contra;
		}
		
		public bool VerCon(int n1, string nombre, string apellido){
			
			bool bien =false;
			int n3=0;
			while(bien==false & n3<4){
				Console.Write("Ingrese Contraseña: ");
				string linea = Console.ReadLine();
				int n2=int.Parse(linea);
				if(n2==n1){
					bien=true;
					n3=4;
				}
				else{
					n3=n3+1;
					Console.Write("Contraseña errada (intento {0}\n\n)",n3);
				}
			}
			
			if(bien==false){
				Console.Write("Escriba el Nombre para restaurar la contraseña\nNombre: ");
				string linea= Console.ReadLine();
				if (linea==nombre){
					Console.Write("Apellido: ");
					linea=Console.ReadLine();
					if (linea == apellido){
						CamCon();
					}
				}
			}
			ere.Write(dre + ": se ejecuto VerCon \n");
			return bien;
		}
		
		public void CamCon(){
			FileStream arc = new FileStream("DATA",FileMode.Open);
			BinaryReader erc = new BinaryReader(arc);
			
			string name = erc.ReadString();
			string last = erc.ReadString();
			string care = erc.ReadString();
			int seme = erc.ReadInt32();
			int cont = erc.ReadInt32();
			erc.Close();
			arc.Close();
				Console.Write("Cambio de Contraseña\n\n");
				cont =Contras();
				File.Delete("DATA");
				FileStream  file =new FileStream("DATA",FileMode.Create);
				BinaryWriter wri = new BinaryWriter(file);
				wri.Write(name);
				wri.Write(last);
				wri.Write(care);
				wri.Write(seme);
				wri.Write(cont);
				wri.Close();
				file.Close();
				ere.Write(dre + ": se ejecuto CamCon \n");
		}
		
		public void Borrar(){
			
			ere.Write(dre + ": se ejecuto Borrar \n");
		}
		
		public void Cerrar(){
			ere.Write(dre + ": se ejecuto Cerrar \n\n");
			ere.Close();
			reg.Close();
		}
	}
	
	class Persona
	{
		
		public string nombre;
		public string apellido;
		public string carrera;
		public int semestres;
		public int Contraseña;
		public double promedio=0;
		
		private funciones fun = new funciones();
		
		public Persona(bool exis){
			if(exis==true){
				Cont();
			}else{
				NueCon();
			}
		}
		
		public int NueCon(){
			fun.ere.Write(fun.dre + ": Creando Nueva Persona\n");
			FileStream arc = new FileStream("DATA",FileMode.Create);
			BinaryWriter escarc = new BinaryWriter(arc,Encoding.UTF8);
			
			Console.Write("Con nuestra app prodras establecer tu promedio de tu vida universitaria.\nDispondras con muchas funciones que seran de gran ayuda para ti.\n");
			
			Console.ReadKey();
			Console.Write("\nIngrese su informacion basica\nNombre: ");
			string linea = Console.ReadLine();
			escarc.Write(linea);
			nombre=linea;
			
			Console.Write("Apellido: ");
			linea = Console.ReadLine();
			escarc.Write(linea);
			apellido=linea;
			
			Console.Write("Carrera: ");
			linea =Console.ReadLine();
			escarc.Write(linea);
			carrera=linea;
			
			Console.Write("Semestres cursados: ");
			linea =Console.ReadLine();
			int Contra = int.Parse(linea);
			semestres = Contra;
			escarc.Write(Contra);			
			semestres=Contra;
			
			Console.Write("\n\nPor seguridad debe establecer una Contraseña\n");
			Contra=fun.Contras();
			Contraseña = Contra;
			
			escarc.Write(Contra);
			escarc.Write(promedio);
			escarc.Close();
			return 0;
		}
		
		public int Cont(){
			fun.ere.Write(fun.dre + ": Ingresando Informacion de Persona\n");
			FileStream arc = new FileStream("DATA",FileMode.Open);
			BinaryReader escarc = new BinaryReader(arc);
			
			nombre = Convert.ToString (escarc.ReadString());
			fun.ere.Write(fun.dre + ": Persona.nombre:"+nombre+" \n");
			apellido = Convert.ToString(escarc.ReadString());
			carrera = Convert.ToString(escarc.ReadString());
			semestres = Convert.ToInt32(escarc.ReadInt32());
			Contraseña = Convert.ToInt32(escarc.ReadUInt32());
			promedio = Convert.ToDouble(escarc.ReadDouble());
			escarc.Close();
			return 0;
		}
		
	}
	
	class Semestre 
	{
		public int Nsem;
		public string[,] Materias;
		public double[][] Notas;
		public double Promedio=0;
		private int n1;
		private int[] n2;
		
		private funciones fun =  new funciones();
		
		public Semestre(int n){
			Nsem=n;
			fun.ere.Write(fun.dre + ": Creando Semestre "+Nsem+" \n");
			string file ="SEM"+Nsem;
			if(File.Exists(file) == false){
				NueSem();
			}else{
				Sem();
			}
		}
		
		private int NueSem(){
			Console.Clear();
			fun.ere.Write(fun.dre + ": Creando Informacion de Semestre "+Nsem+" \n");
			string filename = "SEM" + Nsem;
			string linea=null;
			int numero=0;
			
			FileStream arc = new FileStream(filename,FileMode.Create);
			BinaryWriter escarc = new BinaryWriter(arc,Encoding.UTF8);
			
			fun.ntl(Nsem,true);
			Console.Write(" Semestre\n\n");
			escarc.Write(Nsem);//ESCRIBE ARCHIVO.........
			
			Console.Write("Numero de Materias vista: ");linea=Console.ReadLine();
				numero=int.Parse(linea);
			escarc.Write(numero);//ESCRIBE ARCHIVO.........
				n1=numero;
				
				Materias = new string[numero,2];
				Notas = new double[numero][];
				n2 = new int[numero];
				
				int temp=numero,z=0;
			
				for(int i=0;i<temp;i++){
					int j=i+1;
					Console.Write("\v");fun.ntl(j,true);Console.Write(" Materia\n\n");
					
					Console.Write("Nombre de la materia: ");linea=Console.ReadLine();
						Materias[i,0]=linea;
						escarc.Write(linea);//ESCRIBE ARCHIVO.........
						
					Console.Write("Creditos de la materia: ");linea=Console.ReadLine();
						Materias[i,1]=linea;
						escarc.Write(linea);//ESCRIBE ARCHIVO.........
						int a = int.Parse(linea);
						z = z +a;
						
					Console.Write("Numero de notas: ");linea=Console.ReadLine();
						numero=int.Parse(linea);
						escarc.Write(numero);//ESCRIBE ARCHIVO.........
						int k= numero*2+1;
						n2[i]=k;
						Notas[i] = new double[k];
						k=k-1;
						Notas[i][k]=0;
						int temp2=1;
						for(int l=0;l<k;l++){
							Console.Write("\nIngrese nota {0}: ",temp2);linea=Console.ReadLine();
								double numero2 = Convert.ToDouble(linea);
								Notas[i][l]= numero2;
								escarc.Write(numero2);//ESCRIBE ARCHIVO.........
								double temp3= Notas[i][l];
							l=l+1;
								
							Console.Write("Ingrese Porcentaje de la nota {0}: ",temp2);linea=Console.ReadLine();
								numero2 =Convert.ToDouble(linea);
								Notas[i][l]= numero2;
								escarc.Write(numero2);//ESCRIBE ARCHIVO.........
								temp3 = temp3 *Notas[i][l]/100;
								Notas[i][k]= Notas[i][k]+temp3;
								
							temp2=temp2+1;
						}
						Promedio = Promedio + (Notas[i][k]*a);
				}
				Promedio = Promedio/z;
			escarc.Close();
			arc.Close();
			return 0;
		}
		
		private int Sem(){
			fun.ere.Write(fun.dre + ": Ingresando Informacion de Semestre "+Nsem+" \n");
			string filename = "SEM" + Nsem;
			int numero=0;
			FileStream arc = new FileStream(filename, FileMode.Open);
			BinaryReader escarc = new BinaryReader(arc, Encoding.UTF8);
			
			Nsem=escarc.ReadInt32();
			int a = escarc.ReadInt32();
			n1=a;
				Materias = new string[a,2];
				Notas = new double[a][];
				n2 = new int[a];
				int z=0;
				for(int i=0;i<a;i++){
					int j=i+1;
					
					string linea = escarc.ReadString();
						Materias[i,0]=linea;
						
					linea=escarc.ReadString();
						Materias[i,1]=linea;
						int b = int.Parse(linea);
						z = z + b;
					numero=escarc.ReadInt32();
						int k= numero*2+1;
						n2[i]=k;
						Notas[i] = new double[k];
						k=k-1;
						
						Notas[i][k]=0;
						
						for(int l=0;l<k;l++){
							Notas[i][l]=escarc.ReadDouble();
							double temp= Notas[i][l];
							l=l+1;
							Notas[i][l]=escarc.ReadDouble();
							temp= temp*Notas[i][l]/100;
							
							Notas[i][k] = Notas[i][k] + temp;
						}
						Promedio = Promedio + (Notas[i][k]*b) ;
				}
				
			Promedio = Promedio / z;
			escarc.Close();
			arc.Close();
			return 0;
		}
		
		public void ImprimirSemestre(){
			fun.ere.Write(fun.dre + ": se ejecuto ImprimirSemestre\n");
			Console.Write("Semestre {0}\n",Nsem);
			for (int i=0;i<n1;i++){
				Console.Write("*******************************************************************************\n");
				Console.Write("Materia: {0} - Creditos: {1}\n\n",Materias[i,0],Materias[i,1]);
				int temp=n2[i]-1,temp1=1;
				
				for(int j=0;j<temp;j++){
					Console.Write("Nota {0}: {1} - ",temp1,Notas[i][j]);
					j=j+1;
					Console.Write("Porcentaje: {0} %\n",Notas[i][j]);
				}
				Console.Write("\nDefinitiva: {0}\n",Notas[i][temp]);
			}
			Console.Write("*******************************************************************************\v");
		}
		
		public void ImprimirDef(){
			fun.ere.Write(fun.dre + ": se ejecuto ImprimirDef\n");
			Console.Write("*******************************************************************************\n");
			Console.Write("Semestre {0}\n" +
			              "\tPromedio: {1}\n",Nsem,Promedio);
			
			for (int i=0;i<n1;i++){
				int temp=n2[i]-1;
				Console.Write("Materia: {0} - Creditos: {1} - Definitiva: {2}\n\n",Materias[i,0],Materias[i,1],Notas[i][temp]);
			}
			Console.Write("*******************************************************************************\v");
		}
	}
	
	class Program
	{
		class Nodo
		{
			private funciones fun =new funciones();
			public int n;
			public Semestre sem;
			public Nodo sig;
			
			public Nodo (){
				fun.ere.Write(fun.dre + ": Creando Nodo\n");
			}
		}
		
		private static Nodo raiz = null;
		
		public Program(){
			raiz=null;
		}
		
		private static void Insertar(int n1){
			fun.ere.Write(fun.dre + ": se ejecuto insertar\n");
			Nodo nuevo = new Nodo();
			nuevo.n=n1;
			nuevo.sem = new Semestre (n1);
			cliente.promedio = cliente.promedio + nuevo.sem.Promedio;
			if (raiz == null){
				raiz = nuevo;
			}
			else {
				if(n1<raiz.n){
					nuevo.sig = raiz;
					raiz = nuevo;
				}
				else {
					Nodo reco = raiz;
                    Nodo atras = raiz;
                    while (n1 >= reco.n && reco.sig != null)
                    {
                        atras = reco;
                        reco = reco.sig;
                    }
                    if (n1 >= reco.n)
                    {
                        reco.sig = nuevo;
                    }
                    else
                    {
                        nuevo.sig = reco;
                        atras.sig = nuevo;
                    }
				}
			}
		}
		
		private static void ImprimirSemestre(bool e){
			fun.ere.Write(fun.dre + ": se ejecuto ImprimirSemestre \n");
			Nodo reco = raiz;
			while(reco!=null){
				if(e==true)	reco.sem.ImprimirSemestre(); else reco.sem.ImprimirDef();
				
				reco = reco.sig;
			}
			
		}
		
		
		private static Persona cliente;
		private static  funciones fun =new funciones();
		
		private static int welcome(){
			
			fun.ere.Write(fun.dre + ": se ejecuto welcome\n");
			
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
		
		private static void menu(int x){
			fun.ere.Write(fun.dre + ": se ejecuto menu\n");
			string linea=null;
			int n1=0;
			Console.Clear();
			switch (x) {
				case 1: 
					Console.Write("Informacion Personal - {0}\n\n",cliente.nombre);
					Console.Write("Nombre: {0}\n" +
					              "Apellido: {1}\n" +
					              "Carrera: {2}\n" +
					              "Semestre: {3}\n"
					             ,cliente.nombre,cliente.apellido,cliente.carrera,cliente.semestres);
					Console.Write("Promedio: {0}",cliente.promedio);
					Console.ReadKey();
					break;
					
				case 2:
					Console.Write("Informacion Academica - {0} - Estudiante ",cliente.nombre);
					if(cliente.promedio>4){Console.Write("Distinguido\n\n");}
					else{Console.Write("Normal\n\n");}
					Console.Write("1- Relacion de las Notas Parciales por asiganturas\n" +
					              "2- Relacion de las Notas Definitivas\n" +
					              "3- Regresar\n");
					Console.Write("Elije opcion: ");
					linea =Console.ReadLine();
					n1 = int.Parse(linea);
					if (n1!=3){
						Console.Clear();
						switch (n1) {
							case 1: 
								ImprimirSemestre(true);
								break;
							case 2: 
								ImprimirSemestre(false);
								break;
						}
						Console.ReadKey();
						menu(2);
					}
					break;
					
				case 3:
					fun.VerCon(cliente.Contraseña,cliente.nombre,cliente.apellido);
					Console.Clear();
					Console.Write("Solicitud Academica - {0}\n\n",cliente.nombre);
					Console.Write("1- Actualizar Informacion Personal\n" +
					              "2- Ingresar Notas\n" +
					              "3- Cambiar Contraseña\n" +
					              "4- Crear Copia de seguridad\n" +
					              "0- Regresar\n");
					Console.Write("Elije opcion: ");
					linea =Console.ReadLine();
					n1 = int.Parse(linea);
					if (n1!=0){
						Console.Clear();
						switch (n1) {
							case 1: 
								fun.ere.Write(fun.dre + ": se actualizo el archivo DATA\n");
								File.Copy("DATA","tempDATA");
								File.Delete("DATA");
								cliente.NueCon();
								break;
							case 2: 
								int temp = cliente.semestres +1;
								Insertar(temp);
								break;
							case 3:
								fun.CamCon();
								cliente.Cont();
								break;
							case 4:
								break;
						}
						Console.Clear();
						menu(3);
					}
					break;
					
			}
		}
		
		private static void Programa(bool exis){
			fun.ere.Write(fun.dre + ": se ejecuto Programa \n");
			int n1= cliente.semestres;
			if (exis==true){
				Console.Clear();
				Console.Write("Cargando..");
			}
			
			for (int i=1;i<=n1;i++){
					Insertar(i);
				if (exis==true){Console.Write(".");}
			}
			cliente.promedio = cliente.promedio / n1 ;
			
			n1=0;
			
			while (n1!=4){
				Console.Clear();
				string linea=null;
				Console.Write("Bienvenido {0}\n\n",cliente.nombre);
				Console.Write("1- Informacion Personal\n" +
			              		"2- Informacion Academica\n" +
			              		"3- Solicitud Academica\n" +
			              		"4- Salir\n");
				
					Console.Write("Elije opcion: ");
					linea =Console.ReadLine();
					n1 = int.Parse(linea);
					Console.Clear();
					if (n1!=4){menu(n1);}
			}
			
		}
		
		public static void Main()
		{
			fun.ere.Write(fun.dre + ": Inicio de Main\n");
			bool exis = File.Exists("DATA");
			if (exis==true){
				cliente = new Persona(exis);
				exis = fun.VerCon(cliente.Contraseña,cliente.nombre,cliente.apellido);
				if(exis==true){
					Programa(exis);
				}
			}
			else{
				if(File.Exists("tempDATA")==true){
					File.Copy("tempDATA","DATA");
					File.Delete("tempDATA");
					Main();
				}
				else{
					welcome();
					cliente = new Persona(exis);
					Programa(exis);
				}
			}
			fun.ere.Write(fun.dre + ": Fin de Main\n");
			fun.Cerrar();
		}
		
	}
	
}
