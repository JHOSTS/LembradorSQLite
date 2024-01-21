using SQLite;

namespace Lembrador.Model
{
    [Table("Lembrete")]
    public class Lembrete
    {
        [Column("Lembretes")]
        public string TxtLembrete { get; set; }
    }
}