using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello
{
    public class BoardsAR
    {
        public string BoardARId { get; set; }
    }

    public class BoardsRenameHistory
    {
        public int BoardHistoryId { get; set; }
        public string Name { get; set; }
        public string BoardARId { get; set; }
        public DateTime RenameDate { get; set; }
    }
}
