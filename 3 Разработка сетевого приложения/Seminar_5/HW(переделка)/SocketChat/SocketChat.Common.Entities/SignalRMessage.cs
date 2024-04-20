using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketChat.Common.Entities
{
    [Table("messages")]
    public partial class SignalRMessage
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("message")]
        public string? MessageText { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }

        
    }

    
}
