using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello
{
    public class CardAR
    {
        public string BoardColumnARId { get; set; }
    }

    public class CardContentChangeHistory
    {
        public int Id { get; set; }
        public string CardId { get; set; }
        public string CardContent { get; set; }
        public DateTime RenameDate { get; set; }
    }

    public class CardMoveHistory
    {
        public int Id { get; set; }
        public string CardId { get; set; }
        public DateTime MoveDate { get; set; }
        public string ToBoardColumnId { get; set; }
    }
}
