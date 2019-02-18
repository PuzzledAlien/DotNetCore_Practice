//=====================================================

//Copyright (C) 2016-2019 Fanjia

//All rights reserved

//CLR版 本:    4.0.30319.42000

//创建时间:     2019/2/18 16:46:33

//创 建 人:   徐晓航

//======================================================

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    class MyService : IMyService
    {
        private readonly IConfiguration _configuration;
        public MyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SayMyWords()
        {
            var section = _configuration.GetSection("MyWords");
            Console.WriteLine(section.Value);
        }
    }
}
