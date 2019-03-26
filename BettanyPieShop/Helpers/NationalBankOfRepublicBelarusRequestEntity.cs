using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BethanysPieShop.Helpers
{


    public class NationalBankOfRepublicBelarusRequestEntity
    {
        [JsonProperty("Cur_ID")]
        public long CurId { get; set; }

        [JsonProperty("Date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("Cur_Abbreviation")]
        public string CurAbbreviation { get; set; }

        [JsonProperty("Cur_Scale")]
        public long CurScale { get; set; }

        [JsonProperty("Cur_Name")]
        public string CurName { get; set; }

        [JsonProperty("Cur_OfficialRate")]
        public decimal CurOfficialRate { get; set; }

        public static NationalBankOfRepublicBelarusRequestEntity FromJson(string json) => JsonConvert.DeserializeObject<NationalBankOfRepublicBelarusRequestEntity>(json, Settings);
        public static string ToJson( NationalBankOfRepublicBelarusRequestEntity self) => JsonConvert.SerializeObject(self, Settings);
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

}

