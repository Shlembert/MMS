    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Content12
    {
        [JsonProperty("mlkw1cn")]
        public Mlkw1Cn Mlkw1Cn { get; set; }
		
		[JsonProperty("ojzrta")]
        public Ojzrta Ojzrta { get; set; }
		
		[JsonProperty("sjox_i9qs1")]
        public SjoxI9Qs1 SjoxI9Qs1 { get; set; }
		
		[JsonProperty("u1kn")]
        public U1kn U1kn { get; set; }
    }

    public partial class Mlkw1Cn
    {
        [JsonProperty("Mommy long legs")]
        public Dictionary<string, Dictionary<string, string>> MommyLongLegs { get; set; }

        [JsonProperty("Princess")]
        public Dictionary<string, Dictionary<string, string>> Princess { get; set; }

        [JsonProperty("Mermaid")]
        public Dictionary<string, Dictionary<string, string>> Mermaid { get; set; }

        [JsonProperty("Cute")]
        public Dictionary<string, Dictionary<string, string>> Cute { get; set; }

        [JsonProperty("Anime")]
        public Dictionary<string, Dictionary<string, string>> Anime { get; set; }

        [JsonProperty("Pink")]
        public Dictionary<string, Dictionary<string, string>> Pink { get; set; }

        [JsonProperty("Superheroes")]
        public Dictionary<string, Dictionary<string, string>> Superheroes { get; set; }

        [JsonProperty("Girls")]
        public Dictionary<string, Dictionary<string, string>> Girls { get; set; }
    }
	
	public partial class Ojzrta
    {
        [JsonProperty("Princess")]
        public Dictionary<string, Dictionary<string, string>> Princess { get; set; }

        [JsonProperty("amusement park")]
        public Dictionary<string, Dictionary<string, string>> AmusementPark { get; set; }

        [JsonProperty("Parkour")]
        public Dictionary<string, Dictionary<string, string>> Parkour { get; set; }

        [JsonProperty("School")]
        public Dictionary<string, Dictionary<string, string>> School { get; set; }

        [JsonProperty("modern mansions")]
        public Dictionary<string, Dictionary<string, string>> ModernMansions { get; set; }

        [JsonProperty("pink house")]
        public Dictionary<string, Dictionary<string, string>> PinkHouse { get; set; }

        [JsonProperty("City")]
        public Dictionary<string, Dictionary<string, string>> City { get; set; }
    }
	
	public partial class SjoxI9Qs1
    {
        [JsonProperty("SEEDS")]
        public Dictionary<string, Dictionary<string, string>> Seeds { get; set; }
    }
	
	public partial class U1kn
    {
        [JsonProperty("Anime")]
        public Dictionary<string, Dictionary<string, string>> Anime { get; set; }

        [JsonProperty("princess")]
        public Dictionary<string, Dictionary<string, string>> Princess { get; set; }

        [JsonProperty("Mermaid")]
        public Dictionary<string, Dictionary<string, string>> Mermaid { get; set; }

        [JsonProperty("evil girl")]
        public Dictionary<string, Dictionary<string, string>> EvilGirl { get; set; }
		
		[JsonProperty("wolf girls")]
        public Dictionary<string, Dictionary<string, string>> WolfGirls { get; set; }

        [JsonProperty("Zombie girl")]
        public Dictionary<string, Dictionary<string, string>> ZombieGirl { get; set; }

        [JsonProperty("wonder woman")]
        public Dictionary<string, Dictionary<string, string>> WonderWoman { get; set; }

        [JsonProperty("girls")]
        public Dictionary<string, Dictionary<string, string>> Girls { get; set; }

        [JsonProperty("princess0")]
        public Dictionary<string, Dictionary<string, string>> Princess0 { get; set; }
		
		[JsonProperty("Wings")]
        public Dictionary<string, Dictionary<string, string>> Wings { get; set; }

        [JsonProperty("Angel")]
        public Dictionary<string, Dictionary<string, string>> Angel { get; set; }
    }
