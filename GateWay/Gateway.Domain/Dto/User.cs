﻿using System;

namespace Gateway.Domain.Dto
{
    public partial class User
    {
        public int id { get; set; }
        public string user_login { get; set; }
        public string password_login { get; set; }
        public Nullable<bool> isEditor { get; set; }
    }
}