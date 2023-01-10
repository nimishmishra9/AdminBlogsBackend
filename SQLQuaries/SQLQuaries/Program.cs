class SQL_queries
{
    public class mGeneral
    {
        public static void Main()
        {
            List<student> students = new List<student>()
         {
             new student(){id=1,name="Nimsh",skills=new List<string>(){"Java","VB","SQL"} },
             new student(){id=2,name="Rakhi",skills=new List<string>(){"PHP","VB","SQL"} },
             new student(){id=3,name="Deepu",skills=new List<string>(){"ASP.Net","VB","SQL"} },
             new student(){id=4,name="Shashank",skills=new List<string>(){"PLSQL","VB","SQL"} },
         };

            List<Address> address = new List<Address>()
            {
                new Address(){ addrees_id=1,addrees_name="Test colony" },
                 new Address(){ addrees_id=2,addrees_name="Test colony One" },
                  new Address(){ addrees_id=3,addrees_name="Test colony Two" }
            };
            List<Details> details = new List<Details>()
            {
             new Details(){detailId=1,UserGender="Male"},
             new Details(){detailId=2,UserGender="Female"},
             new Details(){detailId=4,UserGender="Male"},
            };

            var qs = students.GroupJoin(address, student => student.id, address =>
            address.addrees_id, (stu, add) => new { stu, add }).
                SelectMany(x => x.add.DefaultIfEmpty(), (student, Add) => new
                { student.stu,Add}).ToList();
                
            
         
        }
    }

    public class student
    {
     public int id { get; set; }
     public string name { get; set; }
     public string address { get; set; }
     public List<string> skills { get; set; }
    }

    public class Address
    {
     public int addrees_id { get; set; }
     public string addrees_name { get; set; }
    }
    public class Details
    {
       public int detailId { get; set; }
       public string UserGender { get; set; }
    }
} 
