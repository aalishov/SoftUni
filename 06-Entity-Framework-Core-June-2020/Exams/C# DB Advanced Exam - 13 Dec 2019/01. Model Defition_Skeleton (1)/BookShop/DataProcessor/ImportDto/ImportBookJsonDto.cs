﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportBookJsonDto
    {
        [JsonProperty("Id")]
        public int? Id { get; set; }
    }
}
