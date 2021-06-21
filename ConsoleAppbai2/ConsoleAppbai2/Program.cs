using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ConsoleAppbai2.Ultilities;
using ConsoleAppbai2.BaiTap02;

namespace ConsoleAppbai2
{
    class Program
    {              
        static void Main(string[] args)
        {
            // show menu
            BT002 bt002 = new BT002();
            bt002.Menu();
        }
     }
}
    
