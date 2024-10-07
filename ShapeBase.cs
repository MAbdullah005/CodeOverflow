/*using System;
using System.Collections;
using System.Diagnostics;
namespace application1
{
    public class Canvas
    {
        public void drawshape(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.Draw();
             }
            }
        }
        public  class Circle:Shape
            {
            public  override void Draw()
            {
                Console.WriteLine("draw a circle");
            }
        }
    public class Asds:Circle
    {
        public override void Draw()
        {
            Console.WriteLine("ssafa");
        }
    }
        public class Retangle:Shape
        {
            public override void Draw()
            {
                Console.WriteLine("draw a retangle");
            }
        }
    public class Trinagle:Shape
    {
        public override void Draw()
        {
            Console.WriteLine("draw a triangle");
        }
    }
   public abstract class Shape
    {

            public int width{ set; get; }
            public int height { set; get; }
        public abstract  void Draw();
    }
    public class Program
    {
        static void Main()
        {
            var shape = new List<Shape>();
            shape.Add(new Circle());
            shape.Add(new Retangle());
            shape.Add(new Trinagle());
            Canvas canvas = new Canvas();
             canvas.drawshape(shape);
           
            

        }
    }
}


 data base dbmigrator

using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
namespace application1
{ 
    public abstract class Dbconnection
    {
       protected string? connecting_string;
        protected TimeSpan? timeout=TimeSpan.FromSeconds(5);
        public Dbconnection(string a)
        {
            if (a == null)
                throw new ArgumentNullException("null not accpeted ");
            connecting_string = a;
        }
        public abstract void open(TimeSpan t);
        public abstract void close();
    }
    public class Sqlconnection:Dbconnection
    {
        public Sqlconnection(string a) : base(a)
        {
            
        }
        public override void open(TimeSpan t)
        {
            if (t > timeout)
                throw new Exception("time is out not Sql DataBase not open");         
            Console.WriteLine(connecting_string+" Open a Sql DataBase "+t);
        }
        public override void close()
        {
            Console.WriteLine("Close a Sql DataBase");
        }
    }
    public class Oracalconnection : Dbconnection
    {
        public Oracalconnection(string a) : base(a)
        {
             
        }
        public override void open(TimeSpan t)
        {
            if (t > timeout)
                throw new Exception("time is out not Oracal DataBase not open");
             Console.WriteLine(connecting_string+" open the Oracl DataBase "+t);
        }
        public override void close()
        {
            Console.WriteLine("Close a Oracal DataBase");
        }
    }

    public class Program
    {
        static void Main()
        {
           Oracalconnection oracalconnection=new Oracalconnection("connecting string");
            oracalconnection.open(TimeSpan.FromSeconds(5));
            oracalconnection.close();
        }
    }
}

   correct them

using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;
using System.Threading;
namespace application1
{ 
    public abstract class Dbconnection
    {
       protected string? connecting_string { set; get; }
        protected TimeSpan? timeout=TimeSpan.FromSeconds(5);
        public Dbconnection(string a)
        {
            if (a == null)
                throw new ArgumentNullException("null not accpeted ");
            connecting_string = a;
        }
        public abstract void open(TimeSpan t);
        public abstract void close();
    }
    public class Sqlconnection:Dbconnection
    {
        public Sqlconnection(string a) : base(a)
        {
            
        }
        public override void open(TimeSpan t)
        {
            if (t > timeout)
                throw new Exception("time is out not Sql DataBase not open");         
            Console.WriteLine(connecting_string+" Open a Sql DataBase "+t);
        }
        public override void close()
        {
            Console.WriteLine("Close a Sql DataBase");
        }
    }
    public class Oracalconnection : Dbconnection
    {
        public Oracalconnection(string a) : base(a)
        {
             
        }
        public override void open(TimeSpan t)
        {
            if (t > timeout)
                throw new Exception("time is out not Oracal DataBase not open");
             Console.WriteLine(connecting_string+" open the Oracl DataBase "+t);
        }
        public override void close()
        {
            Console.WriteLine("Close a Oracal DataBase");
        }
    }
    public class Dbcommand1 : Dbconnection
    {
        public string instuction
        {
            get  {  return instuction; }
            set
            {
                if(value== null)
                    throw new ArgumentNullException("Instruction is null Not eecuted Task");
                instuction = value;
            }
        }
        public Dbcommand1(string i) : base(i)
        {
            instuction = i;
        }
        public void execute(Dbconnection dbconnection)
        {
            dbconnection.open(TimeSpan.FromSeconds(3));
            dbconnection.close();
        }
        public override void close()
        {
            throw new NotImplementedException();
        }

        public override void open(TimeSpan t)
        {
            throw new NotImplementedException();
        }

    }


    public class Program
    {
        static void Main()
        {
            Console.WriteLine("enter a instruction");
            var instuction = Console.ReadLine()!;
            Dbcommand1 dbcommand1 = new Dbcommand1(instuction);
            dbcommand1.execute(new Oracalconnection("connecintg string"));
        }
    }
}

 .......................

 // use extensibilty mean not to change code instead create new class for new functionalty

using System;
namespace application1
{
    public interface Iloger
    {
        void Logerror(string message);
        void Loginfo(string message);

    }
    public class consoleLoger : Iloger
    {
        public void Logerror(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void Loginfo(string message)
        {
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine(message);
        }
    }
    public class Dbmigrator
    {
        public Dbmigrator(Iloger iloger)
        {
            this.Iloger = iloger;
        }

        public readonly Iloger Iloger;

        public void migrate()
        {
            Iloger.Logerror("migration started at {0} "+ DateTime.Now);
            Iloger.Loginfo("migration finshed at {0} " + DateTime.Now);
        }
    }
    public class Fileloger:Iloger
    {
        private readonly string path;

        public Fileloger(string path)
        {
            this.path = path;
        }
        public void Logerror(string message)
        {
            log(message, "Error :");
        }
        public void Loginfo(string message)
        {
            log(message, "Info :");
        }
        public void log(string message,string messegtype)
        {
            using (var streamwriter = new StreamWriter(path,true))
            {
                streamwriter.WriteLine(messegtype + message);
            }
        }
    }
    public class Program
    {
        static void Main()
        {
            Dbmigrator dbmigrator = new Dbmigrator(new Fileloger(@"D:\file.txt.txt"));
            dbmigrator.migrate();
        }
    }
}

 ............................



using System;
namespace application1
{
    public interface Inotification
    {
        void send(Messeg messeg);
    }
    public class Mailanotifaction : Inotification
    {
        public void send(Messeg messeg)
        {
            Console.WriteLine("sending mail...");
        }
    }
    public class Smsnotifaction : Inotification
    {
        public void send(Messeg messeg)
        {
            Console.WriteLine("sending sms...");
        }
    }
    public class Messeg
    {
        public Messeg()
        {
            
        }
    }
    public class Mailservies
    {
        public void Send()
        {
            Console.WriteLine("sending main...");
        }
    }
    public class Videoencoder
    {
       private readonly IList<Inotification> _notifactionchannal;
        public Videoencoder()
        {
            _notifactionchannal = new List<Inotification>();   
        }
        public void encode()
        {
         foreach(var notifaction in  _notifactionchannal)
            {
                notifaction.send(new Messeg());
            }
        }
        public void registrationchannal(Inotification inotification)
        {
            _notifactionchannal.Add(inotification);
        }
    }
    public class Program
    {
        static void Main()
        {
            Videoencoder videoencoder = new Videoencoder();
            videoencoder.registrationchannal(new Mailanotifaction());
         
            videoencoder.encode();
        }
    }
}

 

Delegate


using System;
namespace application1
{
    public class Photo
    {
        public static Photo load(string a)
        {
            {
                return new Photo();
            }
        }
        public void save()
        {

        }
    }
    public class Photoprocesser
    {

        public void process(string path,Action<Photo> photofilterhandler)
        {
            
            var photo = Photo.load(path);
            photofilterhandler(photo);
            photo.save();   
        }
    }
    public class Photofilter
    {
        public void applybright(Photo photo)
        {
            Console.WriteLine("apply brigtness ");
        }
        public void applycontracs(Photo photo)
        {
            Console.WriteLine("apply contras");
        }
        public void resize(Photo photo)
        {
            Console.WriteLine("resize photo");
        }
    }
    public class Program
    {
        static void Main()
        {
            var photo=new Photoprocesser();
            var photofilter=new Photofilter();
           Action<Photo> filterhandler = photofilter.applybright;
            filterhandler += photofilter.applycontracs;
            filterhandler += photofilter.resize;
            filterhandler += removeredeye;
             photo.process("asdsa",filterhandler);
        }
        static void removeredeye(Photo photo)
        {
            Console.WriteLine("remove red eye");
        }
    }
}

lamdaexpre

using System;
namespace application1
{
    public class Book
    {
        public string? title;
        public int price;
    }
    public class Bookrepositris:Book
    {
        public List<Book> getbook()
        {
            return new List<Book>
            {
                new Book() {title="Title 1",price=2},
                new Book()  {title="Title 1",price=1},
                new Book()  {title="Title 1",price=12}
            };
        }
    }
    public class Program
    {
        static void Main()
        {
            var books = new Bookrepositris().getbook();
            var cheperrbook=books.FindAll(a=>a.price<10);
            foreach(var book in cheperrbook)
            {
                Console.WriteLine(book.title);  
            }
        }
    }
}
  


  events

using System;
namespace application1
{
    public class Video
    {
        public string? titile { get; set; }
    }
    public class Videoeventsargs : EventArgs
    {
        public Video video1 { get; set; }
    }
    public class Videoecoder
    {
        public delegate void Videoecoderhandler(object source, Videoeventsargs e);
        public event Videoecoderhandler Videoecoded;
        public void ecode(Video video)
        {
            Console.WriteLine("ecoding video");
            Thread.Sleep(3000);
            OnVideoecoded(video);
        }
        protected virtual void OnVideoecoded(Video video)
        {
            if (Videoecoded != null)
                Videoecoded(this,new Videoeventsargs() { video1=video});
            else
                Console.WriteLine("null");
        }
    }
    public class Program
    {
        static void Main()
        {
            
            var video = new Video() { titile = "video 1" };
            var videoecoder = new Videoecoder();
            var mailserver = new Mainserver();
            var smsserver=new Messageserver();
            videoecoder.Videoecoded += mailserver.onvideoecoder;
            videoecoder.Videoecoded += smsserver.onvidercoder;
            videoecoder.ecode(video);
        }
        public class Mainserver
        {
            public void onvideoecoder(object source, Videoeventsargs e)
            {
                Console.WriteLine("mail send"+e.video1.titile);
            }
        }
        public class Messageserver
        {
            public void onvidercoder(object source, Videoeventsargs e)
            {
                Console.WriteLine("sms send"+e.video1);
            }
        }
    }
}


sol

using System;
using System.Runtime.InteropServices.Marshalling;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace inter
{
    public class Array
    {
        private int[] items;
        private int count=0;
        public Array(int length)
        {
            items = new int[length];
        }
        public void insert(int i)
        {
            if (count == items.Length)
            {
                int[] newitem=new int[count*2];
                for(int  j=0; j<items.Length; j++)
                {
                    newitem[j] = items[j];
                }
                items = newitem;
            }
                items[count] = i;
                count++;
        }
        public void revove(int index)
        {
            if (index >= count)
            {
                Console.WriteLine("index out of range");
            }
            else
            {
                for (int j = index; j < count-1; j++)
                {
                    items[j] = items[j+1];
                }
                count--;
            }
        }
        public int indexof(int item)
        {
            for(int i=0;i<count;i++)
            {
                if(item==items[i])
                {
                    return i;
                }
            }
            return -1;
        }
        public int large()
        {
            int largenum = items[0];
             for(int i=1;i<count;i++)
            {
                if (items[i]>largenum)
                {
                    largenum= items[i];
                }
            }
            return largenum;
        }
        public void reverse()
        {
            int[] newitem=new int[items.Length*2];
            int j = 0;
            for(int i=count-1;i>=0;i--)
            {
                newitem[j]= items[i];
                j++;
            }
            items = newitem;
        }
        public void insertat(int index, int item)
        {
            int[] newitem=new int[items.Length*2];
            int j = 0;
           for(int i=0;i<count;i++)
            {
               if(index!=i)
                {
                    newitem[j] = items[i];
                    j++;
                }
               else
                {
                    newitem[j] = item;
                    j++;
                    count++;
                    i--;
                    index = -1;
                }
            }
            items = newitem;
        }
        public void print()
        {
            for (int i = 0;i<count; i++)
            {
                System.Console.WriteLine(items[i]);
            }
        }
    }
     class Program
    {
        static void Main()
        {
           Array array =new Array(length:3);
            array.insert(0);
            array.insert(1);
            array.insert(2);
            array.insert(3);
            array.insert(4); 
            array.insert(5);
            array.insert(6);
            array.insert(7);
            array.insert(8);
            array.insert(9);
            array.insert(10);
            array.insertat(4,100);
            array.insertat(5, 200);
            array.print();
            Console.WriteLine("large num  "+array.large());
          
        }
    }
}

Linklist non

using System;
using System.Runtime.InteropServices.Marshalling;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace inter
{
    public class Node
    {
        public int? value;
        public Node? next;
    }
   public class Linklist
    {
        private Node? head;
        private Node? tail;
        public Linklist()
        {
            head = null;
            tail = null;
        }
        public void addfist(int val)
        {
            Node node = new Node();
            node.value=val;
            node.next = null;
            if(head != null)
            {
                node.next = head;
                head = node;
            }
            else
            {
                head=tail=node;
            }
        }
        public void addlast(int val) 
        {
            Node node=new Node();
            node.value=val;
            node.next = null;
            if(tail!=null)
            {
               tail.next= node;
               tail = node;
            }
            else
            {
                tail = node;
            }
        }
        public void deletefast()
        {
            Node node = new Node();
            node = head;
            
        }
        public void print()
        {
            Node node = new Node();
            node = head!;
            while(node!=null)
            {
                Console.WriteLine(node.value);
                node = node.next!;
            }
        }
    }
     class Program
    {
        static void Main()
        {
            Linklist linklist = new Linklist();
            linklist.addfist(1);
            linklist.addfist(2);
            linklist.addfist(3);
            linklist.addfist(4);
            linklist.addfist(5);
            linklist.addlast(10);
            linklist.addlast(11);
            linklist.addlast(12);
            linklist.addlast(13);
            linklist.print();
        }
    }
}



 */