using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello
{
    class Program
    {
        static void Main(string[] args)
        {
            TrelloManagementService tms = new TrelloManagementService();

            ////OpenBoard
            //tms.OpenBoard("101", "qwe");
            //tms.OpenBoard("102", "asd");
            //tms.OpenBoard("103", "ewq");
            //tms.OpenBoard("104", "dsa");


            ////RenameBoard
            //tms.RenameBoard("101", "qwerty");


            ////GetBoardByName
            //Console.WriteLine("GetBoardByName: asd");
            //BoardsRenameHistory getBoardByName = tms.GetBoardByName("asd");
            //Console.WriteLine("BoardName\t BoardId\t BoardRenameDate");
            //Console.WriteLine(getBoardByName.Name + "\t\t" + getBoardByName.BoardARId + "\t\t" + getBoardByName.RenameDate + "\n\n");


            ////GetBoardById
            //Console.WriteLine("GetBoardById: 101");
            //BoardsRenameHistory getBoardById = tms.GetBoardById("101");
            //Console.WriteLine("BoardName\t BoardId\t BoardRenameDate");
            //Console.WriteLine(getBoardById.Name + "\t\t" + getBoardById.BoardARId + "\t\t" + getBoardById.RenameDate);


            ////AddBoardColumn 
            //tms.AddBoardColumn("101", "21", "fgghd");
            //tms.AddBoardColumn("102", "31", "adhf");
            //tms.AddBoardColumn("103", "41", "kjhyg");


            ////RenameColumn
            //tms.RenameBoardColumn("41", "14", "103");


            ////AddCard
            //tms.AddCard("21", "201", "fgdcx");
            //tms.AddCard("31", "202", "ikjf");
            //tms.AddCard("41", "203", "tyeiv");


            ////RenameCard
            //tms.RenameCard("202", "mlkkhuj");


            ////MoveCard
            //tms.MoveCard("203", "21");


            ////GetBoardColumn
            //BoardColumnsRenameHistory getColumn = tms.GetBoardColumn("31");
            //Console.WriteLine("GetBoardColumnById: 31");
            //Console.WriteLine("ColumnId\t ColumnName\t ColumnRenameDate\t BoardID");
            //Console.WriteLine(getColumn.ColumnArId + "\t\t" + getColumn.Name + "\t" + getColumn.RenameDate + "\t" + getColumn.BoardColumnId);


            ////GetCardById
            //CardContentChangeHistory getCard = tms.GetCardById("203");
            //Console.WriteLine("GetCardById: 203");
            //Console.WriteLine("cardId\t\t cardContent\t contentChangeDate");
            //Console.WriteLine(getCard.CardId + "\t" + getCard.CardContent + "\t\t" + getCard.RenameDate);


            ////GetOldCardContent
            //Console.WriteLine("GetOldCardContent(202)");
            //IEnumerable<string> history = tms.GetOldCardContent("202"); ;
            //foreach (var item in history)
            //{
            //    Console.WriteLine(item);
            //}


            ////GetOldColumnsOfCard
            //Console.WriteLine("GetOldColumnsOfCard");
            //IEnumerable<string> oldCol = tms.GetOldColumnsOfCard("203"); ;
            //foreach (var item in oldCol)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
