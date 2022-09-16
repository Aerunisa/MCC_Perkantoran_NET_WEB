using System;

namespace MCC
{
    class ProgramPerkantoran
    {

        static void Main(string[] args)
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
