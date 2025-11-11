#pragma warning disable SA1402
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
#if NET
using System.Net.Http.Json;
#endif
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.Extensions
{
    public partial class GeolocationServiceUC : XtraUserControl
    {
        public HttpClient Client { get; set; }
        private Dictionary<string, GeoLocation> Results = new(StringComparer.InvariantCultureIgnoreCase);
        public GeolocationServiceUC()
        {
            InitializeComponent();
        }

        private async void sbtnQuery_Click(object sender, EventArgs e)
        {
            if (Results.TryGetValue(textEdit1.Text, out var location))
            {
                LoadLocation(location);
            }
            else
            {
                string url = $"http://ip-api.com/json/{textEdit1.Text}";
                var result = await Client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    GeoLocation loc = System.Text.Json.JsonSerializer.Deserialize<GeoLocation>(json);
                    Results.Add(textEdit1.Text, loc);
                    LoadLocation(loc);
                }
            }
        }

        private void LoadLocation(GeoLocation location)
        {
            teQuery.Text = location.Query;
            teStatus.Text = location.Status;
            teCountry.Text = location.Country;
            teCountryCode.Text = location.CountryCode;
            teRegion.Text = location.Region;
            teRegionName.Text = location.RegionName;
            teCity.Text = location.City;
            teZip.Text = location.Zip;
            teLat.Text = location.Lat.ToString();
            teLon.Text = location.Lon.ToString();
            teTimeZone.Text = location.Timezone;
            teISP.Text = location.Isp;
            teOrg.Text = location.Org;
            teAs.Text = location.AsName;
        }

        private void GeolocationServiceUC_Load(object sender, EventArgs e)
        {
            Client = new HttpClient();
        }
    }

    public class GeoLocation
    {
        [JsonPropertyName("query")] public string Query { get; set; }
        [JsonPropertyName("status")] public string Status { get; set; }
        [JsonPropertyName("country")] public string Country { get; set; }
        [JsonPropertyName("countryCode")] public string CountryCode { get; set; }
        [JsonPropertyName("region")] public string Region { get; set; }
        [JsonPropertyName("regionName")] public string RegionName { get; set; }
        [JsonPropertyName("city")] public string City { get; set; }
        [JsonPropertyName("zip")] public string Zip { get; set; }
        [JsonPropertyName("lat")] public float Lat { get; set; }
        [JsonPropertyName("lon")] public float Lon { get; set; }
        [JsonPropertyName("timezone")] public string Timezone { get; set; }
        [JsonPropertyName("isp")] public string Isp { get; set; }
        [JsonPropertyName("org")] public string Org { get; set; }
        [JsonPropertyName("as")] public string AsName { get; set; }
    }
}