﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ModelsApi
{
    
    public class AlbumApi : ApiBaseType
    {   
        public string Name { get; set; }
        public string Image { get; set; }

    }
    
}
