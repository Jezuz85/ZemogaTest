﻿using System;

namespace Writter.Domain.Entities
{
    public partial class Post_User
    {
        public int id { get; set; }
        public Nullable<int> id_editor { get; set; }
        public int id_writter { get; set; }
        public int id_post { get; set; }
    }
}