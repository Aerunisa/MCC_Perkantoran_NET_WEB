using System;
using System.Data.SqlClient;
using MCC.Model;

namespace MCC
{
    class ProgramPerkantoran
    {
        SqlConnection sqlConnection;
        string connectionString =
                "Data Source=AERUNISA;Initial Catalog=MCC1PERKANTORAN;User ID= AERUNISA; Password = AERUNISA";
        static void Main(string[] args)
        {
            ProgramPerkantoran Program = new ProgramPerkantoran();
            //Program.GetDataDetail();
            //Program.GetData();
            //Program.GetById(2);
            /* Pegawai pegawai = new Pegawai()
             {
                 PegawaiName = "Ani",
                 DeptID = 2,
                 PositionID = 7,
                 PegPhoneNum = "+6285887173252",
                 PegAddres = "Jalan Kali dirumah mulu",
                 EmailPegawai = "Pegawai12@mail.com",
                 Salary = 5

             };
             Program.Insert(pegawai);*/
            /* Salary salary = new Salary()
             {
                 SalaryID = 14,
                 SalaryAmount = 5000000
             };
             Program.Update(salary);*/
            Pegawai pegawai = new Pegawai()
            {
                IDPegawai=12

            };
            Program.Delete(pegawai);
            //Program.HRProgram();

        }


        void GetData()
        {
            string query = "SELECT * FROM Department";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - " 
                                + sqlDataReader[1] + " - " + sqlDataReader[2]
                                + " - " + sqlDataReader[3]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
        void GetDataDetail()
        {
            string query = "SELECT Salary.SalaryAmount , Pegawai.PegawaiName , Position.Position ," +
                "Department.DeptName FROM Pegawai JOIN Salary " +
                " On Pegawai.Salary = Salary.SalaryID JOIN Position " +
                " On Pegawai.PositionID = Position.PositionID JOIN Department " +
                " On Pegawai.DeptID = Department.DeptID ";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {

                            Console.WriteLine("Pegawai : " + sqlDataReader[1]); 
                            Console.WriteLine("Salary : " + sqlDataReader[0]);
                            Console.WriteLine("Jabatan : " + sqlDataReader[2]);
                            Console.WriteLine("Department : " + sqlDataReader[3]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void GetById(int DeptID)
        {
            string query = "SELECT * FROM Department WHERE DeptID = @id";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = DeptID;

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[0] + " - "
                                + sqlDataReader[1] + " - " + sqlDataReader[2]
                                + " - " + sqlDataReader[3]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        void Insert(Pegawai pegawai)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@name";
                ParaName.Value = pegawai.PegawaiName;

                SqlParameter ParaDept = new SqlParameter();
                ParaDept.ParameterName = "@deptid";
                ParaDept.Value = pegawai.DeptID;

                SqlParameter ParaPost = new SqlParameter();
                ParaPost.ParameterName = "@postId";
                ParaPost.Value = pegawai.PositionID;

                SqlParameter ParaPhone = new SqlParameter();
                ParaPhone.ParameterName = "@phone";
                ParaPhone.Value = pegawai.PegPhoneNum;

                SqlParameter ParaAddres = new SqlParameter();
                ParaAddres.ParameterName = "@address";
                ParaAddres.Value = pegawai.PegAddres;

                SqlParameter ParaEmail = new SqlParameter();
                ParaEmail.ParameterName = "@email";
                ParaEmail.Value = pegawai.EmailPegawai;

                SqlParameter ParaSalary = new SqlParameter();
                ParaSalary.ParameterName = "@Salary";
                ParaSalary.Value = pegawai.Salary;

                sqlCommand.Parameters.Add(ParaName);
                sqlCommand.Parameters.Add(ParaDept);
                sqlCommand.Parameters.Add(ParaPost);
                sqlCommand.Parameters.Add(ParaPhone);
                sqlCommand.Parameters.Add(ParaAddres);
                sqlCommand.Parameters.Add(ParaEmail);
                sqlCommand.Parameters.Add(ParaSalary);

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Pegawai " +
                        "(PegawaiName, DeptID, PositionID, PegPhoneNum, PegAddres, EmailPegawai, Salary) " +
                        "VALUES (@name, @deptid, @postId, @phone, @address, @email ,  @Salary)";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        void Update(Salary salary)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@id";
                sqlParameter.Value = salary.SalaryID;

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@salaryAmount";
                sqlParameter2.Value = salary.SalaryAmount;

                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter2);
                try
                {
                    sqlCommand.CommandText = "UPDATE Salary SET SalaryAmount =@salaryAmount WHERE SalaryID = @id";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }

            }
        }

        void Delete(Pegawai pegawai)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@id";
                ParaName.Value = pegawai.IDPegawai;
                sqlCommand.Parameters.Add(ParaName);

                try
                {
                    sqlCommand.CommandText = "DELETE FROM Pegawai WHERE IDPegawai =@id";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }


        void HRProgram()
        {
            ProgramHR programHR = new ProgramHR();
            for (; ; )
            {
                Console.WriteLine("Welcome to Program HR!");
                Console.WriteLine("---------------------");
                Console.WriteLine("Please Choice ");
                Console.WriteLine("1 - Perhitungan Gaji {0}2 - Penugasan {0}3 - Calculator Sederhana", Environment.NewLine);
                Console.Write("Enter Choice(1-3):");
                var userInput = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();
                switch (userInput)
                {
                    case 1:
                        GetUserInputGaji(programHR);
                        var getOperationCount = new double[]{
                                       programHR.CountingGaji()
                                };
                        Console.WriteLine(getOperationCount[userInput - 1]);
                        Console.ReadKey();
                        break;
                    case 2:
                        int jumlah;
                        Console.Write("Masukkan jumlah Pegawai yang ingin di Assign : ");
                        jumlah = int.Parse(Console.ReadLine());
                        int[] angka = new int[jumlah];  // ukuran array sesuai inputan pada variabel jumlah

                        Console.WriteLine("");

                        for (int a = 1; a <= angka.Length; a++)
                        {
                            Console.Write("Masukkan nama Pegawai " + a + " : ");
                            string sa = Console.ReadLine();
                        }

                        Console.Write("Press any key to continue . . . ");
                        Console.ReadKey(true);
                        break;
                    case 3:

                        for (; ; )
                        {
                            Console.WriteLine("Welcome to basic calculator! Enter a number. {0}1 - Addition{0}2 - Substraction{0}3 - Multiplication{0}4 - Division", Environment.NewLine);
                            var inputCal = int.Parse(Console.ReadKey().KeyChar.ToString());
                            Console.WriteLine();
                            GetUserInputCal(programHR);
                            var getOperationSUB = new double[]{
                                                       programHR.Counting(),
                                                       programHR.Subtraction(),
                                                       programHR.Multiplication(),
                                                       programHR.Division()
                                        };
                            Console.WriteLine(getOperationSUB[inputCal - 1]);
                            Console.ReadKey();
                            Console.Write("Apakah Anda ingin melanjutkan? [Ya/Tidak]: ");
                            string pilih = Console.ReadLine();

                            if (pilih.ToLower() == "tidak")
                            {
                                break;
                            }
                        }
                        break;
                }
                Console.Write("Apakah Anda ingin melanjutkan? [Ya/Tidak]: ");
                string pilihan = Console.ReadLine();

                if (pilihan.ToLower() == "tidak")
                {
                    break;
                }
            }
        }

        static void GetUserInputGaji(ProgramHR programHR)
        {
            Console.WriteLine("Masukkan Jumlah Absen ");
            programHR.jumlahAbsen = double.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Jumlah Gaji Utama");
            programHR.gajiUtama = double.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Jumlah Lembur");
            programHR.lembur = double.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Jumlah Bonus");
            programHR.bonus = double.Parse(Console.ReadLine());
        }
        static void GetUserInputCal(ProgramHR programHR)
        {
            Console.WriteLine("Masukkan Angka ");
            programHR.angka = double.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Angka");
            programHR.angka2 = double.Parse(Console.ReadLine());
            
        }
        // yangn non void ada di kelas methode ya

    }
}
