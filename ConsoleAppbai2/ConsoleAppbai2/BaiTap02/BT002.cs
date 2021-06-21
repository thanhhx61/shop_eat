using ConsoleAppbai2.Ultilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppbai2.BaiTap02
{
    public class BT002
    {
        public void Option()
        {
            Console.WriteLine("--------MENU--------");
            Console.WriteLine("1. dat ban");
            Console.WriteLine("2. cap nhat them thuc an");
            Console.WriteLine("3. show cac ban trong quan");
            Console.WriteLine("4. tinh tien");
            Console.WriteLine("---------------------");
        }

        #region Menu
        public void Menu()
        {
            Helper helper = new Helper();
            List<Dish> listDish = new List<Dish>();
            List<Order> listOrder = new List<Order>();
            List<Table> ListTable = new List<Table>();
            DateTime timeOder = DateTime.Now;

            int choice = 0;
            do
            {
                Option();
                choice = Int32.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Ban co muon dat ban trc khong");
                            string YesNo = Console.ReadLine();
                            timeOder = DateTime.Now;
                            if (YesNo == "Y" || YesNo == "y")
                            {
                                Console.WriteLine("Thoi gian dat ban");
                                timeOder = DateTime.Parse(Console.ReadLine());
                            }

                            // Order
                            Console.WriteLine("Nhap Id ban");
                            int idTable = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Nhap mon an");
                            string name = Console.ReadLine();

                            Console.WriteLine("So luong mon an");
                            int number = Int32.Parse(Console.ReadLine());

                            Order order = new Order();
                            order = helper.AddOrder(idTable, name, number);

                            listOrder.Add(order);
                            break;
                        }
                    case 2:
                        {

                            Console.WriteLine("Nhap Id ban");
                            int idTable = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Nhap mon an");
                            string name = Console.ReadLine();

                            Console.WriteLine("nhap so luong mon");
                            int number = Int32.Parse(Console.ReadLine());

                            bool check = false;

                            // check ton tai id table
                            foreach (var or in listOrder)
                            {
                                if (idTable == or.IdTable)
                                {

                                    foreach (var dis in or.Dishs)
                                    {
                                        if (name == dis.name)
                                        {
                                            dis.number += number;
                                            check = true; ;
                                        }
                                    }

                                    if (check == false)
                                    {
                                        helper.UpDateOrder(or, name, number);
                                    }
                                }
                            }
                            break;
                        }
                    case 3:
                        {

                            helper.Print(listOrder);
                            break;
                        }
                    case 4:
                        {
                            Order order = new Order();
                            Console.WriteLine("Nhap Id ban");
                            int idTable = Int32.Parse(Console.ReadLine());

                            foreach (var orderBill in listOrder)
                            {
                                if (idTable == orderBill.IdTable)
                                {
                                    order = orderBill;
                                }
                            }                         
                            helper.BillOrder(order, timeOder);
                            break;
                        }
                }
            } while (choice != 5);
        }
        #endregion
    }
}
