using System;
using Npgsql;

namespace datahandler {

    class DbDataAccess : DataAccessHandler
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        NpgsqlDataReader dr;

        public override void Connect()
        {
            string connstring = String.Format("Server={0};Port={1};" + 
                    "User Id={2};Password={3};Database={4};",
                    "serv", "port", "user", "pw", "db" );
            conn = new NpgsqlConnection(connstring);
            
            // TODO: Handle opening errors, etc...
            conn.Open();
        }

        public override void Select()
        {
            /*
             *  semestr:
             *  semestr_id | semestr |    rok   
             */
            cmd = new NpgsqlCommand("select * from semestr", conn);
            dr = cmd.ExecuteReader();            
        }

        public override void Process()
        {
            // sum ids...
            int sum = 0;
            while (dr.Read())
                sum += (int)dr[0];
            Console.WriteLine("Sum of 1st column: {0}", sum);
        }

        public override void Disconnect()
        {
            conn.Close();
        }
    }

}