using Newtonsoft.Json;
using System;

namespace Analogy.DataProviders
{
    [Serializable]
    [JsonObject]
    public class GithubReleaseEntry
    {
        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("assets_url")]
        public string AssetsUrl { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("tag_name")]
        public string TagName { get; set; }
        [JsonProperty("target_commitish")]
        public string Branch { get; set; }
        [JsonProperty("name")]
        public string Title { get; set; }
        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("author")]
        public GithubUser Author { get; set; }

        [JsonProperty("prerelease")]
        public bool PreRelease { get; set; }

        [JsonProperty("created_at")]
        public DateTime Created { get; set; }
        [JsonProperty("published_at")]
        public DateTime Published { get; set; }
        [JsonProperty("assets")]
        public GithubAsset[] Assets { get; set; }
        [JsonProperty("tarball_url")]
        public string tarball_url { get; set; }
        [JsonProperty("zipball_url")]
        public string zipball_url { get; set; }
        [JsonProperty("body")]
        public string Content { get; set; }

        public override string ToString()
        {
            return $"{TagName + Environment.NewLine}{nameof(Title)}: {Title}, {nameof(Content)}: {Content + Environment.NewLine}";
        }
    }
    [Serializable]
    [JsonObject]
    public class GithubUser
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("avatar_url")]
        public string avatarUrl { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
    }

    [Serializable]
    [JsonObject]
    public class GithubAsset
    {
        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("content_type")]
        public string ContentType { get; set; }
        [JsonProperty("size")]
        public long Size { get; set; }
        [JsonProperty("download_count")]
        public int Downloads { get; set; }
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }
        [JsonProperty("updated_at")]
        public DateTime Updated { get; set; }
        [JsonProperty("browser_download_url")]
        public string BrowserDownloadUrl { get; set; }

        public override string ToString() => $"Asset Name: {Name}, URL: {URL}, Size: {Size}, Downloads: {Downloads}, Created: {Created}";
    }
}
