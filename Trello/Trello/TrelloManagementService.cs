using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello
{
    public class TrelloManagementService
    {
        public static string ConnectionStringToDb =
          @"Data Source=DESKTOP-TG7GK4E;" +
          @"Initial Catalog=TrelloDb;Integrated Security=True";



        public void OpenBoard(string boardId, string boardName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string insertOnAggregationRootSql = $"INSERT INTO BoardsAR (BoardARId) VALUES ('{boardId}')";

                string BoardsRenameHistory = $"INSERT INTO BoardsRenameHistory " +
                    $"(Name, BoardARId, RenameDate) VALUES " +
                    $"('{boardName}','{boardId}','{DateTime.Now}')";

                using (SqlCommand insertOnAggregationRootCommand = new SqlCommand(insertOnAggregationRootSql, connection))
                {
                    insertOnAggregationRootCommand.ExecuteNonQuery();
                }

                using (SqlCommand insertOnRenameHistoryCommand = new SqlCommand(BoardsRenameHistory, connection))
                {
                    insertOnRenameHistoryCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


        public void RenameBoard(string boardId, string boardNewName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string BoardsRenameHistory = $"INSERT INTO BoardsRenameHistory " +
                    $"(Name, BoardARId, RenameDate) VALUES " +
                    $"('{boardNewName}','{boardId}','{DateTime.Now}')";
                
                using (SqlCommand insertOnRenameHistoryCommand =
                    new SqlCommand(BoardsRenameHistory, connection))
                {
                    insertOnRenameHistoryCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public BoardsRenameHistory GetBoardByName(string boardName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);
            BoardsRenameHistory board = new BoardsRenameHistory();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string GetBoardByName = $"SELECT * FROM BoardsRenameHistory WHERE Name = '{boardName}'";
                
                using (SqlCommand sqlCommand =
                    new SqlCommand(GetBoardByName, connection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        board.Name = reader.GetString(1);
                        board.BoardARId = reader.GetString(2);
                        board.RenameDate = reader.GetDateTime(3);
                    }
                }

                connection.Close();
                return board;
            }
        }

        public BoardsRenameHistory GetBoardById(string id)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);
            BoardsRenameHistory board = new BoardsRenameHistory();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string GetBoardByName = $"SELECT * FROM BoardsRenameHistory WHERE BoardARId = '{id}'";


                using (SqlCommand sqlCommand =
                    new SqlCommand(GetBoardByName, connection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        board.Name = reader.GetString(1);
                        board.BoardARId = reader.GetString(2);
                        board.RenameDate = reader.GetDateTime(3);
                    }
                }

                connection.Close();
                return board;
            }
        }

        public void AddBoardColumn(string boardId, string boardColumnId, string boardColumnName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string insertOnBoardColumnsAR = $"INSERT INTO ColumnArId (BoardColumnARId) VALUES ('{boardColumnId}')";

                string insertOnBoardColumnsRenameHistory = $"INSERT INTO BoardColumnsRenameHistory " +
                    $"(BoardColumnId, Name, RenameDate, ColumnArId) VALUES " +
                    $"('{boardId}','{boardColumnName}','{DateTime.Now}','{boardColumnId}')";

                using (SqlCommand insertOnAggregationRootCommand = new SqlCommand(insertOnBoardColumnsAR, connection))
                {
                    insertOnAggregationRootCommand.ExecuteNonQuery();
                }

                using (SqlCommand insertOnBoardColumnsRenameHistoryCommand = new SqlCommand(insertOnBoardColumnsRenameHistory, connection))
                {
                    insertOnBoardColumnsRenameHistoryCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void RenameBoardColumn(string columnId, string columnNewName, string boardId)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string insertOnBoardColumnsRenameHistory = $"INSERT INTO BoardColumnsRenameHistory " +
                    $"(BoardColumnId, Name,ColumnArId, RenameDate) VALUES " +
                    $"('{boardId}','{columnNewName}','{columnId}','{DateTime.Now}')";

                using (SqlCommand insertOnBoardColumnsRenameHistoryCommand = new SqlCommand(insertOnBoardColumnsRenameHistory, connection))
                {
                    insertOnBoardColumnsRenameHistoryCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void AddCard(string columnId, string cardId, string cardContent)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string insertOnCardsAr = $"INSERT INTO CardAR(CardARId) VALUES('{cardId}')";

                string insertOnCardsRenameHistory = $"INSERT INTO CardContentChangeHistory " +
                    $"(CardId, CardContent, RenameDate) VALUES " +
                    $"('{cardId}','{cardContent}','{DateTime.Now}')";

                string insertOnMoveCard = $"INSERT INTO CardMoveHistory " +
                    $"(CardId, MoveDate, ToBoardColumnId) VALUES " +
                    $"('{cardId}','{DateTime.Now}','{columnId}')";


                using (SqlCommand RootCommand = new SqlCommand(insertOnCardsAr, connection))
                {
                    RootCommand.ExecuteNonQuery();
                }

                using (SqlCommand HistoryCommand = new SqlCommand(insertOnCardsRenameHistory, connection))
                {
                    HistoryCommand.ExecuteNonQuery();
                }

                using (SqlCommand MoveCommand = new SqlCommand(insertOnMoveCard, connection))
                {
                    MoveCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void RenameCard(string cardId, string newCardContent)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string insertOnCardsRenameHistory = $"INSERT INTO CardContentChangeHistory " +
                    $"(CardId, CardContent, RenameDate) VALUES " +
                    $"('{cardId}','{newCardContent}','{DateTime.Now}')";

                using (SqlCommand HistoryCommand = new SqlCommand(insertOnCardsRenameHistory, connection))
                {
                    HistoryCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void MoveCard(string cardId, string newBoardColumnId)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string insertOnMoveCard = $"INSERT INTO CardMoveHistory " +
                    $"(CardId, MoveDate, ToBoardColumnId) VALUES " +
                    $"('{cardId}','{DateTime.Now}','{newBoardColumnId}')";

                using (SqlCommand MoveCommand = new SqlCommand(insertOnMoveCard, connection))
                {
                    MoveCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public BoardColumnsRenameHistory GetBoardColumn(string boardColumnId)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);
            BoardColumnsRenameHistory column = new BoardColumnsRenameHistory();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string getColumnByID = $"SELECT * FROM BoardColumnsRenameHistory WHERE ColumnArId = '{boardColumnId}'";
                using (SqlCommand sqlCommand = new SqlCommand(getColumnByID, connection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        column.BoardColumnId = reader.GetString(1);
                        column.Name = reader.GetString(2);
                        column.RenameDate = reader.GetDateTime(3);
                        column.ColumnArId = reader.GetString(4);
                    }
                }

                connection.Close();
                return column;
            }

        }

        public CardContentChangeHistory GetCardById(string cardId)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);
            CardContentChangeHistory card = new CardContentChangeHistory();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string getCardById = $"SELECT * FROM CardContentChangeHistory WHERE CardId = '{cardId}'";

                using (SqlCommand sqlCommand = new SqlCommand(getCardById, connection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        card.CardId = reader.GetString(1);
                        card.CardContent = reader.GetString(2);
                        card.RenameDate = reader.GetDateTime(3);
                    }
                }

                connection.Close();
                return card;
            }
        }

        public IEnumerable<string> GetOldCardContent(string cardId)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);
            ICollection<string> oldContent = new List<String>();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string cardContentHistory = $"SELECT CardContent FROM CardContentChangeHistory WHERE CardId = '{cardId}'" +
                    $" AND RenameDate NOT IN (SELECT Max(RenameDate) FROM CardContentChangeHistory WHERE CardId = '{cardId}')";

                using (SqlCommand sqlCommand = new SqlCommand(cardContentHistory, connection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        oldContent.Add(reader.GetString(0));
                    }
                }

                connection.Close();
                return oldContent;
            }
        }
        public IEnumerable<string> GetOldColumnsOfCard(string cardId)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStringToDb);
            ICollection<string> oldContent = new List<String>();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string cardColumnHistory = $"SELECT ToBoardColumnId FROM CardMoveHistory WHERE CardId = '{cardId}'" +
                    $" AND MoveDate NOT IN (SELECT Max(MoveDate) FROM CardMoveHistory WHERE CardId = '{cardId}')";

                using (SqlCommand sqlCommand = new SqlCommand(cardColumnHistory, connection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        oldContent.Add(reader.GetString(0));
                    }
                }

                connection.Close();
                return oldContent;
            }
        }
    }
}
