using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ArtGallery.Models
{
    public class DBManager
    {
        private static string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kaloyan.Mednikarov\source\repos\ArtGallery\ArtGallery\App_Data\ArtGalleryDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework";
        private SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
        private SqlCommand sqlCommand = new SqlCommand();

        public void InsertArtwork(Artwork obj)
        {

            sqlCommand.CommandText = "Insert into [dbo].[Artworks] (Name, Author, Price, Category_Id, Size,Status,ImagePath) " +
                "values('" + obj.Name + "','" 
                + obj.Author + "'," 
                + obj.Price + ","
                + obj.Category_Id + ",'"
                + obj.Size + "','"
                + obj.Status + "','"
                + obj.ImagePath
                + "')";

            sqlCommand.Connection = sqlConnection;
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception es)
            {
                throw es;
            }
        }
    }
}