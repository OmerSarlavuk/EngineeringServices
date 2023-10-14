using Infrastructure.Model;

namespace EngineeringServices.Model.Dtos.Person
{
    public class PersonPostDto : IDto
    {
        public int EngineeringId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhotoPath { get; set; }

        public int Hour { get; set; }           //
        public int Day { get; set; }
        public int Wage { get; set; }
        public string? Rank { get; set; }       //

        public int Age { get; set; }
        public string? University { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? OpenAddress { get; set; }
        public string? Gender { get; set; }

        //IsActive değerini default olarak true ayarla person/ınfo/wınfo
        //bu kayıt yapıldıktan sonra buradan gelecek olan personıd ye göre ınfo ve wınfo tablolarındaki
        //personıd e setle ve diğer colonları null olarak doldur...
        //engineeringıd ye göre engineering tablosunda bir sorgu at ve o idye sahip bir elemanın
        //name değerine şu an atılacak getdto daki name değerine setle.
    }
}
