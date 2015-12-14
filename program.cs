/*
 * Created by SharpDevelop.
 * User: Elias Muñoz
 * Date: 13/12/2015
 * Time: 06:26 p.m.
 */
 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EM
{
	class funciones {
		
		public funciones(){
		
		}
		
		public int ntl(int n){
			int temp=n;
			if(n>=10){
	         temp=n%10;
	         Console.Write("Decimo - ");
    		}
			switch(temp){
					case 1: Console.Write("Primer");break;
					case 2: Console.Write("Segundo");break;
					case 3: Console.Write("Tercero");break;
					case 4: Console.Write("Cuarto");break;
					case 5: Console.Write("Quinto");break;
					case 6: Console.Write("Sexto");break;
					case 7: Console.Write("Septimo");break;
					case 8: Console.Write("Octavo");break;
					case 9: Console.Write("Noveno");break;
					case 0: Console.Write(" ");break;
			}
			return 0;
		}
		
		public void welcome(){
			
		}
	}
	
	class semestre{
		
		private string[] mat_name;
		private int[][] mat_notas;
		private int[][] mat_notas_por;
		private funciones fun = new funciones();
		
		
		public semestre(int n){
			System.Console.Clear();
			fun.ntl(n);
			Console.Write(" Semestre \n\n Ingrese el numero de materias: ");
			string numero=Console.ReadLine();
			int n1=int.Parse(numero);
			//dimensionando tanto en el vector como en la matriz, cada posicion del vector corresponde una fila de la matriz  
			mat_name = new string[n1];
			mat_notas = new int[n1][];
			mat_notas_por = new int[n1][];
			notas(n1);
		}
		
		private int notas(int n){
			string linea;
			int n1;
			int k=0;
			for (int i=0; i<n; i++){
				k=i+1;
				Console.Write("ingreso de notas:\nMateria #"+k+"\nNombre: ");
				linea=Console.ReadLine();
				mat_name[i]=linea; 
				Console.Write("Numero de notas: ");linea=Console.ReadLine();
				n1=int.Parse(linea);
				mat_notas[i] = new int[n1+1];
				mat_notas_por[i] = new int[n1+1];
				
				int sum=0;
				for (int j=0;j<n1;j++){
					sum=0;
					 k=j+1;
					Console.Write("Nota #{0}: ",k);linea=Console.ReadLine();
					mat_notas[i][j]=int.Parse(linea);
					sum=sum+mat_notas[i][j];
					Console.Write("Porcentaje para la Nota #{0}: ",k);linea=Console.ReadLine();
					mat_notas_por[i][j]=int.Parse(linea);
					
				}
				mat_notas[i][n1]=sum/n1;
				
				Console.Write("\nNumero de creditos de la materia: ");linea=Console.ReadLine();
				mat_notas_por[i][n1]=int.Parse(linea);
				
				Console.Write("\n\n");
			}
			return 0;
		}
		
		public void materias(){
		
		}
	}
	
	class Program {
		private funciones fun = new funciones();
		
		static void Main(){
			
			fun.welcome();
			
			int nsem = 13;
			
			while (nsem >12){
				Console.Write("Ingrese el semestre: ");
				string linea=Console.ReadLine();
				nsem=int.Parse(linea);
				
				if (nsem >12){
					Console.Write ("\n\nSolo se permite un maximo 12 semestres\n\n");
				}
			}
			
			if (nsem >=1){
				semestre sem1 = new semestre(1);
				if (nsem >=2){
					semestre sem2 = new semestre(2);
					if (nsem >=3){
						semestre sem3 = new semestre(3);
						if (nsem >=4){
							semestre sem4 = new semestre(4);
							if (nsem >=5){
								semestre sem5 = new semestre(5);
								if (nsem >=6){
									semestre sem6 = new semestre(6);
									if (nsem >=7){
										semestre sem7 = new semestre(7);
										if (nsem >=8){
											semestre sem8 = new semestre(8);
											if (nsem >=9){
												semestre sem9 = new semestre(9);
												if (nsem>=10){
													semestre sem10 = new semestre(10);
													if(nsem>=11){
														semestre sem11 = new semestre(11);
														if (nsem==12){
															semestre sem12 = new semestre(12);
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			
			
		}
	}
}
