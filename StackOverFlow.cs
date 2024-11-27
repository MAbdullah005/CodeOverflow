using System;
using System.Collections.Generic;
using System.Runtime;
namespace FundamentalOfC_
{
    public class StackFlow
    {
        
        private int VoteUp;
        private int VoteDown;
        private string Tittle;
        private string Description;
        private string DT;
        public StackFlow()
        {
            VoteUp = 0;
            VoteDown = 0;
            Tittle = "";
            Description = "";
            DT = "";
        }
      public int voteUp
        {
            get { return VoteUp; }
            set { VoteUp = value; }
        }
        public int voteDown
        { 
            get { return VoteDown; }
            set { VoteDown = value; } 
        }
        public string tittle
        {
            get { return Tittle; }
            set { Tittle = value; }
        }
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }
        public string dt
        {
            get { return DT; }
            set { DT = value; }
        }

    }
    class Program
    {
        static void Main()
        {
            var Stack=new StackFlow();
            int up=0;
            int down=0;
                Console.WriteLine("Enter your Choice :");
                Console.WriteLine("1: For Vote Up ");
                Console.WriteLine("2: For Vote Down ");
                Console.WriteLine("3: For Display the Post Tittle ");
                Console.WriteLine("4: For Display the Description of the Post ");
                Console.WriteLine("5: For Displat the Time When Post Is Uploated On Stack ");
                Console.WriteLine("6: Display All the Data About Post on Stack ");
            while (true)
            {
                var Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        Console.WriteLine("The Vote Is Up ");
                        up++;
                        Stack.voteUp=up;
                        break;
                    case 2:
                        Console.WriteLine("The Vote Is Down ");
                        down++;
                        Stack.voteDown = down;
                        break;
                    case 3:
                        Console.WriteLine("Enter the Tittle ");
                        var Tit=Console.ReadLine();

                        Stack.tittle = Tit;
                    
                        break;
                    case 4:
                        Stack.description = "This Post Is About Stack Over Flow ";
                        Console.WriteLine("Enter The Description ");
                        var Descrip=Console.ReadLine();
                        Stack.description = Descrip;
                        break;
                    case 5:
                        Console.WriteLine("Enter Time Of the Post In HH:mm:ss");
                        var time=Console.ReadLine();
                        Stack.dt = time;
                        break;
                    case 6:
                        Console.WriteLine("Here is The Information About Post ");
                        Console.WriteLine("This Post Vote Up are "+Stack.voteUp);
                        Console.WriteLine("This Post Vote Down Are "+Stack.voteDown);
                        Console.WriteLine("The Post Tittle are "+Stack.tittle);
                        Console.WriteLine("This Post Description are "+Stack.description);
                        Console.WriteLine("This Post Time are "+Stack.dt);
                        break;
                        
                    default:
                        Console.WriteLine("Your Enter Worng Choice ");
                        break;




                }
                if(Choice==6)
                {
                    break;
                }
            }

            }
            

        }
    }
