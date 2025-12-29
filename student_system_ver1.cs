using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp1
{

    internal class Program
    {
        static void Main(string[] args)
        {
        //    int[] arr;
            Student_system student_system = new Student_system();
            Console.WriteLine("歡迎使用學生管理系統");
            string myline = "------------------";
            while (true)
            {
                Console.WriteLine(myline);
                Console.WriteLine("1.新增學生");
                Console.WriteLine("2.刪除學生");
                Console.WriteLine("3.顯示全部資料");
                Console.WriteLine("4.更新學生資料");
                Console.WriteLine("5.離開");
                Console.WriteLine(myline);
                string choice_method_s;
                choice_method_s=Console.ReadLine(); //輸入英文會錯
                int choice_method=Convert.ToInt32(choice_method_s); //string->int
                if (choice_method == 5)
                {
                    Console.WriteLine("離開");
                    Console.WriteLine(myline);
                    break;
                }
                switch (choice_method)
                {
                    case 1://新增
                        student_system.Student_add();
                        break;
                    case 2://刪除
                        student_system.Student_remove();
                        break;
                    case 3://顯示
                        student_system.Student_show();
                        break;
                    case 4://更新
                        student_system.Student_update();
                        break;
                    default:
                        Console.WriteLine("\"請輸入限有功能數字選項\"");   //反斜線表示雙引號 : 符號控制碼
                        Console.WriteLine(myline);
                        break;
                }
                Console.WriteLine();
            }
        }
        public struct Student
        {
            public int s_id;
            public string s_name;
            public double s_score;
        }
        public class Student_system
        {
        //    private Vector<Student> student=new Vector<Student>();
            private Student[] std=new Student[100];
        //    private int s_id;
        //    private string s_name;
        //    private double s_score;
            private string s_read;
            private string myline = "------------------";
            private int std_i=0;
            public void Student_add()
            {
                new Student();
                Console.WriteLine("輸入學生ID:");
                s_read = Console.ReadLine();
                std[std_i].s_id = Convert.ToInt32(s_read);
                //    s_id = Convert.ToInt32(s_read);
                //
                Console.WriteLine("輸入學生名稱:");
                s_read = Console.ReadLine();
                std[std_i].s_name = s_read;
                //s_name = s_read;
                //
                Console.WriteLine("輸入學生成績:");
                s_read = Console.ReadLine();
                std[std_i].s_score = Convert.ToDouble(s_read);
                //s_score = Convert.ToDouble(s_read);
                //
                Console.WriteLine("新增學生成功");
                Console.WriteLine(myline);
                std_i++;
            }
            public void Student_remove() {
                Console.WriteLine("輸入學生ID:");

                s_read = Console.ReadLine();
                int now_student_id = Convert.ToInt32(s_read);
                bool now_flag = true;
                int now_i=100;
                while (now_flag)
                {
                    for (now_i = 0; now_i < std.Length; now_i++)
                    {
                        if (std[now_i].s_id == now_student_id)
                        {
                            Console.WriteLine("確實有這名學生");
                            now_flag = false;
                            break;
                        }
                    }
                    if (now_flag == true)
                    {
                        Console.WriteLine("沒有這名學生，請重新輸入");
                        s_read = Console.ReadLine();
                        now_student_id = Convert.ToInt32(s_read); 
                    }
                }
                string flag_check;
                
                Console.WriteLine("確定要刪除嗎? Y/N");
                flag_check = Console.ReadLine();
                if (flag_check == "Y")
                {
                    std[now_i].s_id = 0;
                    std[now_i].s_name = null;
                    std[now_i].s_score = 0;
                    Console.WriteLine("刪除學生成功");
                }
                else if (flag_check == "N")
                {
                    Console.WriteLine("取消刪除動作");
                }
                else
                {
                    Console.WriteLine("無效輸入");
                }
                Console.WriteLine(myline);

            }
            public void Student_show()
            {
                Console.WriteLine("顯示全部資料");
                for (int i = 0; i < std.Length; i++)
                {
                    if (std[i].s_name!=null)
                    {
                        Console.WriteLine(std[i].s_id);

                        Console.WriteLine(std[i].s_name);

                        Console.WriteLine(std[i].s_score);

                        Console.WriteLine(myline);
                    }
                }
                Console.WriteLine(myline);
                }

            public void Student_update()
            {
                Console.WriteLine("更新學生資料");
                s_read = Console.ReadLine();
                int now_student_id = Convert.ToInt32(s_read);
                bool now_flag = true;
                int now_i = 100;
                while (now_flag)
                {
                    for (now_i = 0; now_i < std.Length; now_i++)
                    {
                        if (std[now_i].s_id == now_student_id)
                        {
                            Console.WriteLine("確實有這名學生");
                            now_flag = false;
                            break;
                        }
                    }
                    if (now_flag == true)
                    {
                        Console.WriteLine("沒有這名學生，請重新輸入");
                    }
                }
                Console.WriteLine("\"\"請修改\"\":");

                Console.WriteLine("輸入學生ID:");
                s_read = Console.ReadLine();
                std[now_i].s_id = Convert.ToInt32(s_read);
                //    s_id = Convert.ToInt32(s_read);
                //
                Console.WriteLine("輸入學生名稱:");
                s_read = Console.ReadLine();
                std[now_i].s_name = s_read;
                //s_name = s_read;
                //
                Console.WriteLine("輸入學生成績:");
                s_read = Console.ReadLine();
                std[now_i].s_score = Convert.ToDouble(s_read);
                //s_score = Convert.ToDouble(s_read);
                //
                Console.WriteLine("修改學生成功");
                Console.WriteLine(myline);
            }

        }
    }
}

/*
 撞牆:
    不會用建構子
    沒辦法用vector型態去創學生列表

無法用vector
 
解決:
    struct內部要宣告public
    先用靜態配置array
 */