using System;
using System.Threading;

namespace EtecCalc
{
    class Program
    {
        static void Main(string[] args)
        {        
           int subtraçao, soma, multiplicaçao, divisao, seno, coseno, potencia, ajuda,radi, info, link, cento,PC;
           string operaçao="", cn , TT,x="";   
           logoInicio();           
           do
             {
               operaçao="";x="";PC=34;
               Double resultado, v1, v2, np=1 ; 
ConsoleKeyInfo cki;
               Console.Clear();              
// *************montar um displey da calculadora *********************
               for (int i = 0; i < 18; i++)
                  {
                  print("                                        ",8,8,0,i);
                  }
                print("+----------+",14,8,15,0);  
                print("|          |",14,8,15,1);
                print("+----------+",14,8,15,2);
                print("*",0,8,16,1);print("ETEC    *",4,8,17,1);print("CALC",0,8,21,1);
                 teclado();
                print("   (A)juda   (i)nfo   (L)ink  (F)im",0,8,1,5);
                print("                              ",0,0,5,3);// visor
                print("                              ",0,0,5,4);// visor
                              
                do // entrada de caracter para formar a variavel operaçao
                 {
                 Console.SetCursorPosition(PC, 4);// PROMPT ENTRADA
                 cki = Console.ReadKey(true);                
                 x = cki.KeyChar.ToString().ToUpper();                 
                 if (x=="F") {Console.Clear();Environment.Exit(0);}
                 if (x==" ") {x="=";}   // barra de espaço tbm pode ser o sinal de igual

                 acender_tecla(x);      // vermelho para mostrar a tecla apertada no teclado        
                
                            
                 // trabalhar com os sinais ++ -- +- -+ e guardar em OP (replace)
                 if (operaçao.IndexOf("++")>=0 ) {PC++;}
                 if (operaçao.IndexOf("--")>=0 ) {PC++;}
                 if (operaçao.IndexOf("+-")>=0 ) {PC++;}
                 if (operaçao.IndexOf("-+")>=0 ) {PC++;}
                 operaçao = operaçao.Replace("++","+"); // preciso realmente ?
                 operaçao = operaçao.Replace("--","+"); // * ''
                 operaçao = operaçao.Replace("+-","-"); // * ''
                 operaçao = operaçao.Replace("-+","-"); // preciso? ou é erro?
                 operaçao = operaçao.Replace("E","^"); 
                 operaçao = String.Concat(operaçao, x);
                 print(operaçao,15,0,PC,4);
                  PC--;
                 } while (x != "=" );
                

                 if (operaçao =="F") {Console.Clear();Environment.Exit(0);}         
           
                try
                 {
// **************  PREPARAR STRING OPERAÇAO  para que exista apenas um simbolo *********************************
                 operaçao = operaçao.Replace("=","");// retirar o sinal de = da problema de erro
                 cn = operaçao.Substring(0,1);                                 // sinal do primeiro valor
                 if (cn=="-") {np= -1 ;  operaçao = operaçao.Remove(0,1);}     // *
                   else np=1;                                                  // *                 
            
//**************  verificar qual operador esta na string e setar as variaveis de controle 
                 subtraçao      =    operaçao.IndexOf('-');
                 soma           =    operaçao.IndexOf('+');
                 divisao        =    operaçao.IndexOf('/');
                 multiplicaçao  =    operaçao.IndexOf('*');
                 potencia       =    operaçao.IndexOf('^');
                 seno           =    operaçao.IndexOf('S');
                 coseno         =    operaçao.IndexOf('C');
                 ajuda          =    operaçao.IndexOf('A');
                 radi           =    operaçao.IndexOf('R');
                 info           =    operaçao.IndexOf('I');
                 link           =    operaçao.IndexOf('L');
                 cento          =    operaçao.IndexOf('%'); 

           //     identificar operaçao matematica

// ********************* Subtração ***********
                 if ( subtraçao  >=1 && multiplicaçao <0 && divisao <0 && potencia <0&& cento <0 && coseno<0 && seno<0) 
                 {
                  string[] valor = operaçao.Split('-');
                  v1=(Convert.ToDouble(valor[0])*np);
                  v2=Convert.ToDouble(valor[1]);
                  resultado = v1-v2;
                  mostrar(resultado,operaçao,PC,np.ToString());                

                 }              

//*********************** Adiçao **************
                 if ( soma >=0 && multiplicaçao <0 && divisao <0 && potencia <0 && cento <0 && coseno<0 && seno<0) 
                 {
                  string[] valor = operaçao.Split('+');
                  v1=(Convert.ToDouble(valor[0])*np);
                  v2=Convert.ToDouble(valor[1]);
                  resultado = v1+v2;
                  mostrar(resultado,operaçao,PC,np.ToString());                

                 }

//********************* multiplicação ***********
                if ( multiplicaçao >=0 ) 
                 {
                  string[] valor = operaçao.Split('*');
                  v1=(Convert.ToDouble(valor[0])*np);
                  v2=Convert.ToDouble(valor[1]);
                  resultado = v1*v2;
                  mostrar(resultado,operaçao,PC,np.ToString());                

                 }

//********************* Divisao ********************
                if ( divisao >=0)
                 {             
                  string[] valor = operaçao.Split('/');                
                  v1=(Convert.ToDouble(valor[0])*np);
                  v2=Convert.ToDouble(valor[1]);
                  resultado = v1/v2;                 
                  mostrar(resultado,operaçao,PC,np.ToString());                

                 }

// ********************* seno************************
                if ( seno >=0) 
                {
                 string[] valor = operaçao.Split('S');
                 v1=Convert.ToDouble(valor[1]);

                 resultado = Math.Sin(v1);
                 operaçao = operaçao.Replace("S","Seno ");

                 mostrar(resultado,operaçao,PC-4," ");
                }

//******************* Coseno ****************************
               if ( coseno >=0) 
               {
                string[] valor = operaçao.Split('C');                
                v1=Convert.ToDouble(valor[1]);
                resultado = Math.Cos(v1);
                operaçao = operaçao.Replace("C","Coseno ");
                mostrar(resultado,operaçao,PC-6," ");   
               }

//******************** potencia ***************************
               if ( potencia >=0)  
                 {
                  string[] valor = operaçao.Split('^');
                  v1=(Convert.ToDouble(valor[0])*np);
                  v2=Convert.ToDouble(valor[1]);
                  resultado = Math.Pow(v1,v2);
                 mostrar(resultado,operaçao,PC,np.ToString());                
                        
                }

//******************** RADICIAÇÃO ***************************
               if ( radi >=0)  
                 {
                  string[] valor = operaçao.Split('R');
                  v2=Convert.ToDouble(valor[1]);
                  resultado = Math.Sqrt(v2);
                  mostrar(resultado,operaçao,PC,np.ToString());                
                   
                 }
//********************* porcentagem *************************
               if (cento>=0)
                {    
                 string[] valor = operaçao.Split('%');
                 v1=(Convert.ToDouble(valor[0])*np);
                 v2=Convert.ToDouble(valor[1]);
                 resultado=v1*(v2/100);
                 mostrar(resultado,operaçao,PC,np.ToString());                
                
                }
                
// **************** ajuda ************************
               if ( ajuda >=0)  
                 {help();}
// **************** informação ************************
               if ( info >=0)  
                 {INFORMAÇÃO();}               
 // **************** Link ************************
               if ( link >=0)  
                 {
                   limpar_tela();
                  System.Diagnostics.Process.Start("explorer.exe", "https://marcelo11114.github.io/EtecCalc/" );
                  
                   
                   }               
            }
            catch
             {
               x="";operaçao="";
              print("                              ",12,0,5,3); 
              print("             ERRO!            ",12,0,5,4);
             }    
                          
              print("                                  ",0,8,3,5);           
              print("qualquer tecla voltar",0,8,6,5);
             Console.ReadKey(true);TT="S";             
             }while(TT != " ");
          Console.Clear();    
        } // fecha main

        static void print(String S, int COR_Caracter,int COR_Fundo, int X,int Y)
          {
            ConsoleColor CorC = (ConsoleColor)COR_Caracter;
            ConsoleColor CorF = (ConsoleColor)COR_Fundo;
            Console.ForegroundColor = CorC;
            Console.BackgroundColor = CorF;
            Console.SetCursorPosition(X, Y);
            Console.Write(S);
            Console.ResetColor();
          }//fecha print

          static void mostrar(Double S,String O,int x,string Sinal)
          {          
            print("                              ",0,0,5,3);
            print("                              ",0,0,5,4);
            if (Sinal=="-1") {Sinal="-";} else {Sinal="";}
            
            print($"{Sinal}{O}",10,0,x,3);
            int px=S.ToString().Length;
            print(S.ToString(),15,0,33-px,4);
          }
          static void help()
          {    
            limpar_tela();                                               
            print("             AJUDA            ",14,0,5,3);
            print("            *******           ",14,0,5,4);
            print("   Digite a operação matematica que     ",0,8, 0,7);
            print("  deseja e tecle = ou Barra de espaço   ",0,8, 0,8);
            print("        para executar a operação.       ",0,8, 0,9);
            print("               exemplos:                ",0,8, 0,11);
            print("2+2 (soma),  2*2 (vezes), 2/-2 (dividir)",0,8, 0,12);
            print("  2E2 (2 elevado a 2), s2 (seno de 2)   ",0,8, 0,13);
            print(" r23 (RAIZ2 DE 23), c23 (coseno de 23)  ",0,8, 0,14);
            print("       10%30 (10 por cento de 30)       ",0,8, 0,15);
          }
          static void INFORMAÇÃO()
          {                        
             
            limpar_tela();                    
            print("             SOBRE            "       ,14,0,5,3);   
            print("            *******           "       ,14,0,5,4);   
            print("Desenvolvido por                     " ,0,8, 1,7);
            print("Valdecir Marcelo De Zagiacomo RA11114" ,0,8, 1,8);             
            print("   Escola Tecnica Adolph Berenzin    " ,14,8,1,10);
            print("Curso informatica Nova Matriz - 2020 " ,14,8, 0,11);
            print("    Programação de Computadores 1    " ,0,8, 1,12);
            print("professores:                         " ,0,8, 1,13);
            print("            Ermogenes Palacio        " ,15,8, 1,14);
            print("                Diego Neri           " ,15,8, 1,15);

          }
          static void logoInicio()  
           {
             Console.Clear();
             for (int i = 0; i < 18; i++)
                  {
                  print("                                        ",8,8,0,i);
                  }
                  for (int i = 3; i < 14; i++)
                  {
                  print("                           ",0,0,6,i);
                  }
            print("  CALCULADORA",14,0,12,03);
            print("  **"            ,12,0, 12,05);
            print("  *** "          ,12,0, 12,06);
            print("  ** **"         ,12,0, 12,07);
            print("  **   **  "     ,12,0, 12,08); 
            print(" **************" ,12,0, 12,09);
            print(" **      **    *",12,0, 12,10);
            print("**         ****" ,12,0, 12,11);
            print("ETEC Adopho Berezin ",14,0,11,12);          
            Thread.Sleep(2000);
            
           }
          static void teclado()
          {
           int x=3,y=6,n=0,X,Y;    
           for (int i = 6; i < 16; i++)
                {
                print("                                   ",0,0,2,i);
                }

           n=1;
           for( Y=0;Y<9;Y=Y+3){
              for (X=0; X<12;X=X+4)
              {
                tecla(n.ToString(),X+x,Y+y,15,0);
                n=n+1;
              }//nextX            
            }//nextY
           tecla(" +  ",17,6,15,1);tecla(" -  "  ,22, 6,15,1);tecla(" *  ",27, 6,15,1);tecla(" /  ",32, 6,15,1);
           tecla("E ^ ",17,9,15,1);tecla("Raiz"  ,22, 9,15,1);tecla("sin ",27, 9,15,1);tecla("cos ",32, 9,15,1);                                             
           tecla("0",15,12,15,0)  ;tecla(" ,  "  ,22,12,15,1);tecla(" %  ",27,12,15,1);tecla("=SPC" ,32,12,10,1);
         }//teclado
           static void acender_tecla(string x)
            {
                 if (x=="1") {tecla("1" ,3,6,5,0);Thread.Sleep(100);tecla("1" ,3, 6,15,0);}
                 if (x=="2") {tecla("2" ,7,6,5,0);Thread.Sleep(100);tecla("2" ,7, 6,15,0);}
                 if (x=="3") {tecla("3",11,6,5,0);Thread.Sleep(100);tecla("3" ,11,6,15,0);}
                 if (x=="4") {tecla("4", 3,9,5,0);Thread.Sleep(100);tecla("4" ,3, 9,15,0);}
                 if (x=="5") {tecla("5", 7,9,5,0);Thread.Sleep(100);tecla("5" ,7, 9,15,0);}
                 if (x=="6") {tecla("6",11,9,5,0);Thread.Sleep(100);tecla("6" ,11,9,15,0);}
                 if (x=="7") {tecla("7", 3,12,5,0);Thread.Sleep(100);tecla("7", 3,12,15,0);}
                 if (x=="8") {tecla("8", 7,12,5,0);Thread.Sleep(100);tecla("8", 7,12,15,0);}
                 if (x=="9") {tecla("9",11,12,5,0);Thread.Sleep(100);tecla("9",11,12,15,0);}
                 if (x=="0") {tecla("0",15,12,5,0);Thread.Sleep(100);tecla("0",15,12,15,0);}
                 if (x=="+") {tecla(" +  ",17,6,5,1);Thread.Sleep(100);tecla(" +  ",17,6,15,1);}
                 if (x=="-") {tecla(" -  ",22,6,5,1);Thread.Sleep(100);tecla(" -  ",22,6,15,1);}
                 if (x=="*") {tecla(" *  ",27,6,5,1);Thread.Sleep(100);tecla(" *  ",27,6,15,1);}
                 if (x=="/") {tecla(" /  ",32,6,5,1);Thread.Sleep(100);tecla(" /  ",32,6,15,1);}
                 if (x=="E") {tecla("E ^ ",17,9,5,1);Thread.Sleep(100);tecla("E ^ ",17,9,15,1);}
                 if (x=="R") {tecla("Raiz",22,9,5,1);Thread.Sleep(100);tecla("Raiz",22,9,15,1);}         
                 if (x=="S") {tecla("Sin ",27,9,5,1);Thread.Sleep(100);tecla("Sin ",27,9,15,1);}
                 if (x=="C") {tecla("Cos ",32,9,5,1);Thread.Sleep(100);tecla("Cos ",32,9,15,1);}
                 if (x==",") {tecla(" ,  ",22,12,5,1);Thread.Sleep(100);tecla(" ,  ",22,12,15,1);}
                 if (x=="%") {tecla(" %  ",27,12,5,1);Thread.Sleep(100);tecla(" %  ",27,12,15,1);}
                 if (x=="=") {tecla("=  " ,32,12,5,1);Thread.Sleep(100);tecla("=SPC" ,32,12,10,1);}
              }//acender tecla
          static void tecla (string C, int Px,int Py,int S, int tipo)
           {
             if (tipo==0){
                 print ("   "    ,0,S,Px,Py+1);
                 print($" {C} "  ,0,S,Px,Py+2);
                         }
             if (tipo==1){
                print ("    "    ,0,S,Px,Py+1);
                print( C ,0,S,Px,Py+2);
                         }          
           }//tecla
           static void limpar_tela ()
           {
             for (int i = 4; i < 18; i++)
              {
            print("                                        ",8,8,0,i);
              }    
           } //LIMPAR TELA      
          
    }//CLASS
}//NAME