// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace consume_json_api
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class ListingData
    {
        [JsonProperty("Activities")]
        public Activity[] Activities { get; set; }
    }

    public partial class Activity
    {
        [JsonProperty("DataID")]
        public long DataId { get; set; }

        [JsonProperty("Divisi")]
        public object Divisi { get; set; }

        [JsonProperty("EfekEmiten_EBA")]
        public object EfekEmitenEba { get; set; }

        [JsonProperty("EfekEmiten_ETF")]
        public object EfekEmitenEtf { get; set; }

        [JsonProperty("EfekEmiten_Obligasi")]
        public object EfekEmitenObligasi { get; set; }

        [JsonProperty("EfekEmiten_Saham")]
        public object EfekEmitenSaham { get; set; }

        [JsonProperty("EfekEmiten_SPEI")]
        public object EfekEmitenSpei { get; set; }

        [JsonProperty("EfekType")]
        public string EfekType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("JenisEmiten")]
        public object JenisEmiten { get; set; }

        [JsonProperty("KodeDivisi")]
        public object KodeDivisi { get; set; }

        [JsonProperty("KodeEmiten")]
        public string KodeEmiten { get; set; }

        [JsonProperty("NamaEmiten")]
        public string NamaEmiten { get; set; }

        [JsonProperty("PapanPencatatan")]
        public string PapanPencatatan { get; set; }

        [JsonProperty("RawXML")]
        public object RawXml { get; set; }

        [JsonProperty("RencanaStatus")]
        public string RencanaStatus { get; set; }

        [JsonProperty("SahamIPOValue")]
        public double SahamIpoValue { get; set; }

        [JsonProperty("TanggalPencatatan")]
        public DateTime TanggalPencatatan { get; set; }

        [JsonProperty("Delisting")]
        public DateTime Delisting { get; set; }
    }

    public partial class ListingData
    {
        public static ListingData FromJson(string json) => JsonConvert.DeserializeObject<ListingData>(json,ListingDataConverter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ListingData self) => JsonConvert.SerializeObject(self, ListingDataConverter.Settings);
    }
}
