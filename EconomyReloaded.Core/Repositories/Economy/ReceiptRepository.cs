using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factories.Economy;
using EconomyReloaded.Core.Models.Economy;

namespace EconomyReloaded.Core.Repositories.Economy
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly IDatabaseConnection _databaseConnection;
        private readonly IReceiptFactory _receiptFactory;

        public ReceiptRepository(IDatabaseConnection databaseConnection, IReceiptFactory receiptFactory)
        {
            _databaseConnection = databaseConnection;
            _receiptFactory = receiptFactory;
        }

        public IEnumerable<Receipt> GetReceiptsOnUserId(int userId)
        {
            if (!string.IsNullOrEmpty(_databaseConnection.ConnectionString))
            {
                try
                {
                    using (var connection = new SqlConnection(_databaseConnection.ConnectionString))
                    {
                        var receipts = new List<Receipt>();

                        connection.Open();
                        var command = new SqlCommand("SELECT [ReceiptId],[UserId],[ReceiptName],[TotalPrice],[ReceiptDate] FROM [dbo].[Receipt] WHERE UserId = @userId", connection);
                        command.Parameters.Add("userId", SqlDbType.Int).Value = userId;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var receipt = _receiptFactory.CreateReceipt(reader);
                                    receipts.Add(receipt);
                                }
                            }
                        }
                        return receipts;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public void Insert(Receipt receipt)
        {
            if (receipt!=null)
            {
                try
                {
                    using (var connection = new SqlConnection(_databaseConnection.ConnectionString))
                    {
                        connection.Open();
                        var command = new SqlCommand("INSERT INTO [dbo].[Receipt] ([UserId],[ReceiptName],[TotalPrice],[ReceiptDate]) VALUES(@userId,@receiptName,@totalPrice,@receiptDate)", connection);
                        command.Parameters.Add("userId", SqlDbType.Int).Value = receipt.UserId;
                        command.Parameters.Add("@receiptName", SqlDbType.VarChar).Value = receipt.ReceiptName;
                        command.Parameters.Add("@totalPrice", SqlDbType.Decimal).Value = receipt.TotalPrice;
                        command.Parameters.Add("@receiptDate", SqlDbType.Date).Value = receipt.ReceiptDate.Date;

                        var affectedRows = command.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
