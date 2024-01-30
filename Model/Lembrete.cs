using SQLite;

namespace Lembrador.Model
{
    [Table("Lembretes")]
    public class Lembrete
    {
        [Column("Lembrete")]
        public string TxtLembrete { get; set; }

        public static explicit operator Lembrete(string v)
        {
            throw new NotImplementedException();
        }
    }
}