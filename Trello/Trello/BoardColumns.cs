using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello
{
    public class BoardColumnsAR
    {
        public string BoardColumnARId { get; set; }
    }

    public class BoardColumnsRenameHistory
    {
        public int Id { get; set; }
        public string BoardColumnId { get; set; }
        public string Name { get; set; }
        public DateTime RenameDate { get; set; }
        public string ColumnArId { get; set; }
    }
}
